using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumofEnemy : MonoBehaviour {

    public Text noe;
    public GameObject[] tagObjects;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        tagObjects = GameObject.FindGameObjectsWithTag("enemy");
        noe.text = "Enemy " + tagObjects.Length + "/5";
	}
}
