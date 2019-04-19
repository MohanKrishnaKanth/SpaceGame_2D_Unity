using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    
    public static int cnt = 0;
    public static Vector2 pos;
    public GameObject biglaserborn;
   // bool a;
    public static bool b=false;

    public GameObject heart;
    
    public bool state = false;
    public GameObject bg;
    
    Vector2 d;
    public EnemyMovement en;
    public bool e = false;
   public  Vector2 f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        bg.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, Time.time * 0.49f);
        if (cnt==5)
        {
            Instantiate(biglaserborn, pos, Quaternion.identity);
            b = true;
            cnt = 0;
        }


      /*  if (state == false)
        {
            if (Health.healthvalue < 50 && e == true)
            {
                state = true;
                Instantiate(heart, f, Quaternion.identity);
            }
            e = false;
        }
        else
        {
            e = false;
        } */
    }



  

  


}



