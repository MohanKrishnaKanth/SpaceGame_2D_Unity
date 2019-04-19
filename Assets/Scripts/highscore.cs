using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscore : MonoBehaviour {
    public Text Highscore;
   
   
    // Use this for initialization
    void Start () {
        Highscore = GetComponent<Text>();
        Highscore.text = PlayerPrefs.GetInt("Highscore",0).ToString();
      
    }
	
	// Update is called once per frame
	void Update () {
        if (Score.scorevalue > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score.scorevalue);
            
        }
    }
}
