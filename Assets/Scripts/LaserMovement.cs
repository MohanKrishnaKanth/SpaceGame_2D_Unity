using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

    float HorizontalExtent, VerticalExtent;
    GameObject posObj;
    Vector2 bull;

    void Start () 
	{
        VerticalExtent = Camera.main.orthographicSize;
        HorizontalExtent = VerticalExtent * Camera.main.aspect;
        posObj = GameObject.FindGameObjectWithTag("Respawn");
         bull = posObj.transform.position;
        

    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bull, 0.2f);
        if (transform.position.x > HorizontalExtent || transform.position.x < -HorizontalExtent || transform.position.y > VerticalExtent || transform.position.y < -VerticalExtent)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
