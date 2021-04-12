using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Controller : MonoBehaviour
{

    GameObject asteroid;
    Rigidbody2D rb;
    float forcePower;

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
     
        
    }

    void FixedUpdate() {
        rb.velocity = new Vector3(0.6f, -0.40f, 0);
    }

     void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
