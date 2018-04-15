using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour {

    private Player_Controller player;
    private Rigidbody2D rb2d; //controls speed

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<Player_Controller>();
        rb2d = GetComponentInParent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = collisionObject.transform;
            player.grounded = true;
        }
    }


    void OnCollisionStay2D (Collision2D collisionObject) //search in each frame
    { 
        if (collisionObject.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }

        if (collisionObject.gameObject.tag == "Platform")
        {
            player.transform.parent = collisionObject.transform;
            player.grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }

        if (collisionObject.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
