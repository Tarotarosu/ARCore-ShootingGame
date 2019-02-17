using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public Text scoreText;
    public NewGameController ngc;

	// Use this for initialization
	void Start () {
        ngc = GameObject.Find("GameController").GetComponent<NewGameController>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score " + ngc.GetScore();
	}
}
