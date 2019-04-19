using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Transform front;
    GameObject pl;
    Vector2 dist;
    Quaternion rot;
    AudioSource a;
    Animator an;

    float HorizontalExtent, VerticalExtent;

    public bool z=false;
    float nextfire = 0f;
   public  GameObject enemybullet;
    public GameObject enemyshoot;
    public static int enemyhealth = 10;

    public static float angle;



    void Start ()
    {
        pl = GameObject.Find("Player");
 
        a = GetComponent<AudioSource>();
        an = GetComponent<Animator>();
        VerticalExtent = Camera.main.orthographicSize;
        HorizontalExtent = VerticalExtent * Camera.main.aspect;
        front = pl.GetComponent<Transform>();

    }


    void Update()
    {
        Vector2 v;
        v.x = Mathf.Clamp(transform.position.x, -HorizontalExtent, HorizontalExtent);
        v.y = Mathf.Clamp(transform.position.y, -VerticalExtent, VerticalExtent);
        transform.position = v;

         Vector3 dir = front.position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 270;

        //rot=transform.rotation;
        //rot = Quaternion.Euler(0, 0, -angle);
        //transform.rotation = rot;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
       


        if (pl != null)
          {
              if (Vector2.Distance(transform.position, front.position) >2.9f)
              {
                transform.position = Vector2.Lerp(transform.position, front.position , 1f/*smoothing value*/ * Time.deltaTime);
              }
           

            


        }

        if (Time.time>nextfire && pl!=null)
         {
            Quaternion rot = Quaternion.Euler(0, 0, -angle);
            Instantiate(enemybullet,enemyshoot.transform.position ,rot );
             nextfire = Time.time + 1f;
         }

    


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyhealth -= 1;
        }

        if (collision.gameObject.tag == "Bullet" && enemyhealth==0)
        {
            an.SetBool("es", true);
            Score.scorevalue += 10;
            a.Play();
            Destroy(gameObject,0.9f);
        }
     

        if (collision.gameObject.tag == "Biglaser")
        {
            z = true;
            Score.scorevalue += 10;
            a.Play();
            an.SetBool("es", true);
           // GameObject.Find("Gamecontroller").GetComponent<GameController>().e = true;
            //GameObject.Find("Gamecontroller").GetComponent<GameController>().f = transform.position;
            Destroy(collision.gameObject);
            Destroy(gameObject, 1f);
        }
    }



}
