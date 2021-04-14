using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for now, we just spawn a new asteroid when we press 'Z', we should get this looped into a timed delay
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // instantiate new asteroid GameObject
            GameObject asteroid = Instantiate(Resources.Load("Asteroid")) as GameObject;
            Rigidbody2D asteroidRigidBody = asteroid.GetComponent<Rigidbody2D>();
            
            // set some randomized positional/velocity values
            asteroidRigidBody.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-5.5f, 5.5f));
            // TODO: maybe change position so they are spawned off-screen
            asteroidRigidBody.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            asteroidRigidBody.rotation = Random.Range(0f, 360f);
            asteroidRigidBody.angularVelocity = Random.Range(-12f, 12f);
        }
    }
}
