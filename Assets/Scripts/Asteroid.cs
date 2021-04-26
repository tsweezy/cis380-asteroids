using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explode_effect;
    private GameObject target;
    private Rigidbody2D rb;
    private bool enteredScreen = false;
    private float timeInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        timeInstantiated = Time.timeSinceLevelLoad;
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Push asteroid roughly toward the player's position and give it a random rotation
        Vector2 direction = target.transform.position - transform.position;
        rb.AddRelativeForce(new Vector2(direction.normalized.x + Random.Range(-1f, 1f), direction.normalized.y + Random.Range(-1f, 1f)), ForceMode2D.Impulse);
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
        Vector3 asteroidPosition = gameObject.transform.position;
        if (other.gameObject.tag == "Projectile")
        {
            switch(gameObject.name) {
                // small asteroids
                case "Asteroid0(Clone)":
                case "Asteroid1(Clone)":
                case "Asteroid2(Clone)":
                    ControllerScore.scoreCount += 10;
                    break;
                // medium asteroids
                case "Asteroid3(Clone)":
                case "Asteroid4(Clone)":
                    ControllerScore.scoreCount += 5;
                    Instantiate(Resources.Load("Asteroid0"), new Vector3(asteroidPosition.x - 1f, asteroidPosition.y - 1f), Quaternion.identity);
                    Instantiate(Resources.Load("Asteroid1"), new Vector3(asteroidPosition.x, asteroidPosition.y + 1f), Quaternion.identity);
                    Instantiate(Resources.Load("Asteroid2"), new Vector3(asteroidPosition.x + 1f, asteroidPosition.y), Quaternion.identity);
                    break;
                // large asteroids
                case "Asteroid5(Clone)":
                    ControllerScore.scoreCount += 1;
                    Instantiate(Resources.Load("Asteroid3"), new Vector3(asteroidPosition.x, asteroidPosition.y + 1f), Quaternion.identity);
                    Instantiate(Resources.Load("Asteroid4"), new Vector3(asteroidPosition.x + 1f, asteroidPosition.y), Quaternion.identity);
                    break;
            }
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
