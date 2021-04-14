using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject explode_effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            ScoreController.scoreCount += 1;
            Instantiate(explode_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            // ignore collisions between boundaries and asteroids
            Physics2D.IgnoreCollision(other.collider, other.otherCollider, true);
        }  
    }

    void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
