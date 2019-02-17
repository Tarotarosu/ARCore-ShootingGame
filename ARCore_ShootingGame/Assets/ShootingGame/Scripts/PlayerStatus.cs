using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int hp;
    public int maxHP = 10;
    private PlayerHPScript hpscript;
    public GameObject gameOver;


	// Use this for initialization
	void Start () {
        hp = maxHP;
        hpscript = GameObject.Find("Canvas").GetComponent<PlayerHPScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            GameOver();

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hp -= 1;
            hpscript.UpdateHPValue();
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

    public void GameOver()
    {
        if (!GameObject.Find("GameOverCanvas(Clone)"))
        {
            Instantiate(gameOver);
        }
        Invoke("QuitApp", 5);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}

