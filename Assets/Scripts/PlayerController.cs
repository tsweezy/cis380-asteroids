using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject flame;
    public float thrust = 0.5f;
    float forcePower;
    GameObject player;

    GameObject gameOver;
    public PolygonCollider2D playerCollider;
    private SpriteRenderer playerSprite;
    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        flame = GameObject.Find("Flame");
        flame.SetActive(false);

        player = GameObject.Find("Player");
        playerCollider = gameObject.GetComponent<PolygonCollider2D>();
        playerCollider.enabled = true;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* While holding 'A', set forcePower and rotate counter-clockwise */
        if (Input.GetKey(KeyCode.A))
        {
            forcePower = Time.deltaTime * thrust;
            rb.AddTorque(forcePower, ForceMode2D.Impulse);
        }

        /* While holding 'A', set forcePower and rotate clockwise */
        if (Input.GetKey(KeyCode.D))
        {
            forcePower = Time.deltaTime * thrust;
            rb.AddTorque(-forcePower, ForceMode2D.Impulse);
        }

        /* While holding 'W', make flame visbible, set forcePower, scale flame
           length to reflect forcePower */
        if (Input.GetKey(KeyCode.W))
        {
            forcePower = Time.deltaTime * thrust;
            flame.SetActive(true);

            /* If the flame's scale is below the maximum, position and scale
               flame with respect to player ship and forcePower respectively */
            if (flame.transform.localScale.y < 1.5f) {
                flame.transform.localPosition = new Vector2(flame.transform.localPosition.x, flame.transform.localPosition.y + forcePower / 10.0f);
                flame.transform.localScale = new Vector3(flame.transform.localScale.x + forcePower, flame.transform.localScale.y + forcePower, flame.transform.localScale.z);
            }
            
            /* Add force to ship */
            rb.AddRelativeForce(new Vector2(0, 0.005f), ForceMode2D.Impulse);

            /* Reset forcePower when letting go */
            if (Input.GetKeyUp(KeyCode.W))
                forcePower = 0f;
            
        /* When not pressing 'W', make flame invisible and reset transforms */
        } else {
            flame.SetActive(false);
            flame.transform.localScale = new Vector3(0.76f, 0.3333333f, 0);
            flame.transform.localPosition = new Vector2(-0.0036f, -0.034f);
        }

        /* When pressing 'Space', generate a projectile */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(Resources.Load("Projectile")) as GameObject;
            Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();

            /* Set transformations and force for projectile */
            projectileRigidBody.rotation = rb.rotation;
            projectile.transform.position = gameObject.transform.position;
            projectileRigidBody.AddRelativeForce(new Vector2(0, rb.velocity.magnitude + 5f), ForceMode2D.Impulse);

            /* Add opposite force to ship */
            rb.AddRelativeForce(new Vector2(0, -thrust / 5f), ForceMode2D.Impulse);
        }

        if(LivesController.lifeCount == 0) {
            GameOverController.gameOver = 1;
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Asteroid" && invincible != true) {
            LivesController.lifeCount = LivesController.lifeCount - 1;
            StartCoroutine(PauseCollider());
            player.transform.position = Vector2.zero;
        }
    }

    IEnumerator PauseCollider() {
        invincible = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0.0f;
        rb.rotation = 0.0f;
        playerSprite.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(2);
        invincible = false;
        playerSprite.color = new Color(1f, 1f, 1f, 1f);

    }
}
