using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMovement : MonoBehaviour {

    public float speed;
    Transform t;
    Rigidbody2D r;
    // Use this for initialization
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(0, speed);
        //r.gravityScale=0;
    }
}
