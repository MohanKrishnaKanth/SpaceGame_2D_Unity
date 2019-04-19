using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 pos = collision.gameObject.transform.position;
            pos.y *= -0.7f;
            collision.gameObject.transform.position = pos;
        }
    }
}
