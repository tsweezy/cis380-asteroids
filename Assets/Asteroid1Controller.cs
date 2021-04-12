using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Controller : MonoBehaviour
{

    GameObject asteroid;
    Rigidbody2D rb;
    float forcePower;

    float positionCloneY = 6.00f;
    float positionCloneX = -12.0f;

    private int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        asteroid = GameObject.Find("Asteroid 1");
        rb = GetComponent<Rigidbody2D>();
        //forcePower = Time.deltaTime * 0.10f;
        //rb.AddTorque(forcePower, ForceMode2D.Impulse);
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
        rb.velocity = new Vector3(0.85f, -0.60f, 0);
    }

     void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
