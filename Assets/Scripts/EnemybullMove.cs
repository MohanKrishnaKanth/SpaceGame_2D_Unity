using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemybullMove : MonoBehaviour {
    Vector2 p;
    float speed = 2f;
    float HorizontalExtent, VerticalExtent;

    void Start ()
    {
        VerticalExtent = Camera.main.orthographicSize;
        HorizontalExtent = VerticalExtent * Camera.main.aspect;
        p = GameObject.Find("Player").GetComponent<Transform>().position;
        GetComponent<Rigidbody2D>().velocity = p * speed;
      
    }

    private void Update()
    {
        if(transform.position.x>HorizontalExtent||transform.position.x<-HorizontalExtent|| transform.position.y>VerticalExtent||transform.position.y<-VerticalExtent)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
