using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour {
	Animator an;
    float HorizontalExtent, VerticalExtent;
    public bool v=false;
    public Vector2 t;
    AudioSource a;

    void Start()
	{
		an = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
        VerticalExtent = Camera.main.orthographicSize;
        HorizontalExtent = VerticalExtent * Camera.main.aspect;
    }
    private void Update()
    {
        
        if(gameObject!=null)
        {
            if (transform.position.y > VerticalExtent || transform.position.y < -VerticalExtent)
                Destroy(gameObject);
          
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
      
        if (col.tag == "Player")
        {
            a.Play();
            an.SetInteger("astval", 1);
            Destroy(gameObject, 0.9f);
        }
        if(col.tag=="Bullet")
        {
            a.Play();
            an.SetInteger("astval", 1);
            Score.scorevalue += 1;
            GameController.cnt += 1;
            GameController.pos = transform.position;
            Destroy(col.gameObject);
            Destroy(gameObject, 0.9f);
        }
       
    }

    public void downmovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-HorizontalExtent, HorizontalExtent), Random.Range(-4, 0));
    }
    public void upmovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-HorizontalExtent, HorizontalExtent), Random.Range(4,0));
    }
   

}
