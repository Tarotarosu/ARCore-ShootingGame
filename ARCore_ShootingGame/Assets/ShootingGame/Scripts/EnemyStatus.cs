using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStatus : MonoBehaviour {

    public int hp;
    public int maxHP = 3;
    public Transform target;
    public float speed;
    private Vector3 vec;
    public GameObject explosion;
    private EnemyHPScript hpscript;
    public NewGameController ngc;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("CameraPosition").transform;
        hp = maxHP;
        hpscript = GetComponentInChildren<EnemyHPScript>();
        ngc = GameObject.Find("GameController").GetComponent<NewGameController>();

    }
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            hpscript.SetDisable();
            ngc.SetScore(1);
            
        }

    }
    void FixedUpdate()
    {

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            hp -= 1;
            hpscript.UpdateHPValue();
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            hpscript.SetDisable();
        }

    }
    public int GetHp()
    {
        return hp;
    }
    public int GetMaxHp()
    {
        return maxHP;
    }

}
