using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Player : MonoBehaviour 
{ 
    protected Joybutton joybutton;
    Rigidbody2D rb;
    Animator an;
   
    public float speed;
    public GameObject shooter;
    public Transform shot;
    GameObject canv;
    int n;
    public GameObject Biglaser;
  

    public float firerate = 0.5f;
    private float nextFire = 0f;
    Vector3 rot;
    GameObject pos;
    public GameObject []enemy;
    
  
    void Start()
    {
      
        joybutton = FindObjectOfType<Joybutton>();
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pos = GameObject.FindGameObjectWithTag("Respawn") ;
        canv = GameObject.Find("Canvas");
        InvokeRepeating("spawn", 6f, 15f);
    }



    public joystick joystick;


    void FixedUpdate()
    {

       if(joystick.pressed==true)
        {
            an.SetInteger("value", 1);
            Vector3 moveVector = joystick.GetComponent<joystick>().InputDirection;
            float angle = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
            rb.AddForce(pos.transform.position * 1.3f);
            an.SetInteger("value", 1);
        }

       else
        {
            an.SetInteger("value", 0);
        }

        shootinput();

        biglaser();

        chechkhealth();
        
    }



        /* 
          
          if(Input.GetKeyDown(KeyCode.W))
          {
            rb.AddForce(pos.transform.position * 2.5f);
            an.SetInteger("value", 1); 
          }
          
          
          else
          {
               an.SetInteger("valve",1);
          }
         
         * if (Input.GetKeyDown(KeyCode.Mouse0) && b==false) //&& Time.time > nextFire
         {
             //nextFire = Time.time + firerate;
             Instantiate(shooter, shot.position,transform.rotation);
         }



         if (Input.GetKey(KeyCode.A)) //&& OA == false && OC == false)
         {

             an.SetInteger("value", 1);
             rot.z += 3f;

             //q.eulerAngles = new Vector3(0,speed,);
             //t.Rotate(0,speed,0);
             // t.RotateAround(Vector3.zero, Vector3.back, 30 * Time.deltaTime);
             transform.rotation = Quaternion.Euler(rot);


         }
         else if (Input.GetKey(KeyCode.D)) //&& OD == false && OB == false)
         {
             an.SetInteger("value", 1);
             rot.z -= 3f;
             transform.rotation = Quaternion.Euler(rot);
             // t.RotateAround(Vector3.forward, Vector3.forward, 30 * Time.deltaTime);
         } 



       

        if (transform.position.y > 4.6f && b == false)
        {
            c = true;
            Vector2 newPos = transform.position;
            newPos.y *= -1;
            transform.position = newPos;
        }

        if (transform.position.y < -4.6f && c==false)
        {
            b = true;
            Vector2 newPos = transform.position;
            newPos.y *= -1;
            transform.position = newPos;
        }

       if (transform.position.x > 6.4f&& d==false)
        {
            e = true;
            Vector2 newPos = transform.position;
            newPos.x *= -1;
            transform.position = newPos;
        }

        if (transform.position.x < -6.4f&&e==false)
        {
            d = true;
            Vector2 newPos = transform.position;
            newPos.x *= -1;
            transform.position = newPos;
        } */
    void shootinput()
    {
        if (joybutton.pressed == true && GameController.b == false && Time.time > nextFire)
        {
            nextFire = Time.time + firerate;
            Instantiate(shooter, shot.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            GameObject.Find("Gamecontroller").GetComponent<GameController>().e = false;
            Destroy(collision.gameObject);
            Health.healthvalue += 10;
            GameObject.Find("Gamecontroller").GetComponent<GameController>().state = false;
        }

          /*else  if(collision.tag== "Enemy")
             {
                // a.Play();
                 an.SetBool("state", true);
                 Destroy(gameObject, 1f);
                 canv.transform.Find("Restart").gameObject.SetActive(true);

             } */

        else if(collision.tag == "Asteroid")
        {
            Health.healthvalue -= 3;
        }

       else if(collision.tag=="EnemyBullet")
        {
            Health.healthvalue -= 1;
        }

    }

    public void spawn()
    {
    

          int a = Random.Range(0, 4);
            switch ( a)
            { 
                case 0 :
                    {
                       Instantiate(enemy[Random.Range(0, 3)], new Vector2(5f, 0f), Quaternion.identity);
                        break;

                    }
                case 1:
                    {
                       Instantiate(enemy[Random.Range(0, 3)], new Vector2(0, -3.5f), Quaternion.identity);
                       break;
                    }

                case 2:
                    {
                       Instantiate(enemy[Random.Range(0, 3)], new Vector2(0, 3.5f), Quaternion.identity);
                       break;
                    }

               case 3:
                   {
                       Instantiate(enemy[Random.Range(0, 3)], new Vector2(-5f, 0f), Quaternion.identity);
                       break;
                   }

               case 4:
                   {
                    Instantiate(enemy[3], new Vector2(-5f, 0f), Quaternion.identity);
                       break;
                   }
            } 

    }

    void biglaser()
    {
        if (GameController.b == true)
        {
            if (joybutton.pressed == true)
            {
                Instantiate(Biglaser, shot.position, transform.rotation);
                GameController.b = false;

            }
        }
    }

    void chechkhealth()
    {
        if (Health.healthvalue <= 0)
        {

            Health.healthvalue = 0;
            canv.transform.Find("Restart").gameObject.SetActive(true);
            canv.transform.Find("pause").gameObject.SetActive(false);
            an.SetBool("state", true);
            Destroy(gameObject, 1f);

        }

    }

}
