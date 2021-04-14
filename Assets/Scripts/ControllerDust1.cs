using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDust1 : MonoBehaviour
{

    
    public GameObject cloud;
    Rigidbody2D rb;
    float forcePower;
    private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GameObject.Find("DustCloud 1");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if(frames % 400 == 0) {

            rb.AddForce(transform.forward * 0.10f);
            rb.velocity = new Vector3(0.9f, 0.0f, 0);
        }
    }
}