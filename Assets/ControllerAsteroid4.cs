using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAsteroid4 : MonoBehaviour
{

    public GameObject asteroid;
    Rigidbody2D rb;
    float forcePower;
    private int frames = 0;

    public GameObject explode_effect;
    // Start is called before the first frame update
    void Start()
    {
        asteroid = GameObject.Find("Asteroid 4");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.forward * 0.10f);
    }

    // Update is called once per frame
    void Update()
    {
        frames++;

        if(frames % 900 == 0) {
            
        }
    }

     void FixedUpdate() {
        rb.velocity = new Vector3(-0.4f, -0.3f, 0);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Projectile") {
            ControllerScore.scoreCount += 1;
            Instantiate(explode_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
        }
    }

     void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
