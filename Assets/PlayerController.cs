using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            Vector2 left = new Vector2(-5f, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Vector2 left = new Vector2(5f, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            Vector2 left = new Vector2(0, 5f);
            rb.AddForce(left, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Vector2 left = new Vector2(0, -5f);
            rb.AddForce(left, ForceMode2D.Impulse);
        }
    }
}
