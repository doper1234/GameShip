using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectileMovement : MonoBehaviour {


    public float velocity = 200;
    public GameObject explosion;
    private Rigidbody2D rb2d;
    private bool init = true;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.right * 10 * velocity);
        //rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
    }
	
	// Update is called once per frame
	void Update () {

        //if (init)
        //{
           // rb2d.AddForce(-transform.right * 1 * velocity);
        //    init = false;
        //}
        //else
        //    rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
        if (rb2d.velocity.x > velocity)
            rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        { Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
