using UnityEngine;
using System.Collections;

/* this script provided by asset store package */
public class Projectile : MonoBehaviour
{
	public GameObject shoot_effect;
	public GameObject hit_effect;
	public GameObject firing_ship;
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start ()
	{
		firing_ship = GameObject.Find("Player");
		GameObject obj = (GameObject) Instantiate(shoot_effect, transform.position  - new Vector3(0,0,5), Quaternion.identity); //Spawn muzzle flash
		rb = GetComponent<Rigidbody2D>();
		obj.transform.parent = firing_ship.transform;
		Destroy(gameObject, 15f); //Bullet will despawn after 5 seconds
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if ( 	col.gameObject != firing_ship 
			&&	col.gameObject.tag != "Projectile"
			&&	!col.isTrigger
			&&	col.gameObject.tag != "Boundary")
		{
			col.attachedRigidbody.AddForce(rb.velocity);
			Instantiate(hit_effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
