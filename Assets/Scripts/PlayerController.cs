using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5f;
	//speed of player

	bool facingRight = true;
	//direction of the sprite facing

	Animator anim;
	// reference to animator

	bool grounded = false;
	public Transform groundCheck;
	//transform at player's foot to see if he is touching the ground
	float groundRadius = 0.2f;
	//how big the circle is going to be when we check distance to the ground

	public float jumpForce = 320f;
	//jump force
	public LayerMask whatIsGround;
	// what layer is considered the ground

	void Start ()
	{
		anim = GetComponent<Animator> ();
		//make sure player is not dead
		anim.SetBool ("isDead", false);
	}

	void FixedUpdate () //used for physics editing
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); //returns a boolean (depending if the ground transform hit the whatIsGround with the groundRadius

		anim.SetBool ("Ground", grounded); //tell animator we are grounded

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		float move = Input.GetAxis ("Horizontal"); //get direction of movement
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * speed, GetComponent<Rigidbody2D> ().velocity.y); //add velocity to the Rigidbody of the player in the move direction multiplied with our speed

		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Update ()
	{

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false); //not on the ground (after jumping)
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce)); //add jump force to y-axis of the rigidbody
		}
	}

	void Flip ()
	{
		facingRight = !facingRight; //facing opposite direction
		Vector3 theScale = transform.localScale;

		//flip on x-axis
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
