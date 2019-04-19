using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private void Start()
    {
        Destroy(gameObject, 6f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" )
        {
            Health.healthvalue += 10;
            GameObject.Find("Gamecontroller").GetComponent<GameController>().state = false;
            Destroy(gameObject);
        }
    }
}
