using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPScript : MonoBehaviour {

    private EnemyStatus es;
    private Slider hpSlider;
	// Use this for initialization
	void Start () {
        es = transform.root.GetComponent<EnemyStatus>();
        hpSlider = transform.Find("HPbar").GetComponent<Slider>();
        hpSlider.value = (float)es.GetMaxHp() / (float)es.GetMaxHp();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Camera.main.transform.rotation;
	}

    public void SetDisable()
    {
        gameObject.SetActive(false);
    }
    public void UpdateHPValue()
    {
        hpSlider.value = (float)es.GetHp() / (float)es.GetMaxHp();
    }
}
