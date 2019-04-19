using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePlayerBorder : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 pos = collision.gameObject.transform.position;
            pos.x *= -0.7f;
            collision.gameObject.transform.position = pos;
        }
    }
}
