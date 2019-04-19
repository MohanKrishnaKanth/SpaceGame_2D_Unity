using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biglaserborn : MonoBehaviour {

   
    private void Start()
    {
        Destroy(gameObject, 5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            GameController.b = true;
            Destroy(gameObject);
        }
    }
}
