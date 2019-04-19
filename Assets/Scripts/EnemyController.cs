using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    float HorizontalExtent, VerticalExtent;
    public Asteroid asteroidprefab;
    private Asteroid AsteroidInstance; 
    public float spawnrate = 2f;
    float nextspawn = 0;
 
  
    void Start()
    {
        VerticalExtent = Camera.main.orthographicSize;
        HorizontalExtent = VerticalExtent * Camera.main.aspect;

    }
    void FixedUpdate()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            StartCoroutine(createdown());
            StartCoroutine(createup());

        }
    }

    IEnumerator createup()
    {
        yield return new WaitForSeconds(1);
        Vector2 y = new Vector2(Random.Range(-HorizontalExtent, HorizontalExtent), VerticalExtent);
        AsteroidInstance = Instantiate(asteroidprefab, y, Quaternion.identity) as Asteroid;
        AsteroidInstance.downmovement();
    }
    IEnumerator createdown()
    {
        yield return new WaitForSeconds(1);
        Vector2 y = new Vector2(Random.Range(-HorizontalExtent, HorizontalExtent), -VerticalExtent);
        AsteroidInstance = Instantiate(asteroidprefab, y, Quaternion.identity) as Asteroid;
        AsteroidInstance.upmovement();
    }



}
