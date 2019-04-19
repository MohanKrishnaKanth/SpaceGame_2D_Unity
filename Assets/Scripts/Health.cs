using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
   public static int healthvalue = 100;
    Text health;
	// Use this for initialization
	void Start () {
        health = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        
        health.text = "Health : " + healthvalue;
	}
}
