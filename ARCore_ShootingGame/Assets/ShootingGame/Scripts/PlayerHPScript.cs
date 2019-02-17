using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPScript : MonoBehaviour {

    public GameObject player;
    private PlayerStatus ps;
    private Slider hpSlider;

	// Use this for initialization
	void Start () {
        ps = player.GetComponent<PlayerStatus>();
        hpSlider = transform.Find("PlayerHPBar").GetComponent<Slider>();
        hpSlider.value = (float)ps.GetMaxHp() / (float)ps.GetMaxHp();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHPValue()
    {
        hpSlider.value = (float)ps.GetHp() / (float)ps.GetMaxHp();
    }
}
