using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explode_effect;
    private Rigidbody2D rb;
    private bool enteredScreen = false;
    private float timeInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = Time.timeSinceLevelLoad;
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.rotation = Random.Range(0f, 360f);
        rb.angularVelocity = Random.Range(-12f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        // give 5 seconds for asteroids to enter the screen before destruction
        if ((Time.timeSinceLevelLoad - timeInstantiated>= 5f) && !enteredScreen)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            ControllerScore.scoreCount += 1;
            Instantiate(explode_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        enteredScreen = true;
    }

    void OnBecameInvisible()
    {
        // destroy if asteroid has entered and left the screen
        if (enteredScreen)
            Destroy(gameObject);
    }
}
