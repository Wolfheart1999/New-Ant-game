using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidbody2D;

    public float speed = 10;
    private bool facingRight = true;

    public float jumpForce;

	// Use this for initialization
	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Time.deltaTime * (speed * horizontal), 0, 0);
        
        if (myRigidbody2D.velocity.y < 0)
        {
        }

        Flip(horizontal);
        _Input();
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            SpriteRenderer flipX = GetComponent<SpriteRenderer>();
            flipX.flipX = !facingRight;
        }
    }

    void _Input ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && myRigidbody2D.velocity.y == 0)
        {
            Jump();
        }
    }

    void Jump()
    {
        myRigidbody2D.AddForce(new Vector2(0, jumpForce));
    }
}
