using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	public bool jump = false;				// Condition for whether the player should jump.
	public bool canJump = true;
	public bool wallHitR = false;
	public bool wallHitL = false;
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	public Transform wallCheckL;
	public Transform wallCheckR;
	public bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	public bool isMoving;
	public float distance;
	public bool swim;

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();

	}
	void Start()
	{
	
	}
	
	void Update()
	{
		wallCheckR.localPosition = new Vector3(gameObject.transform.localPosition.x + 0.5f,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
		wallCheckL.localPosition = new Vector3(gameObject.transform.localPosition.x - 0.5f,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		wallHitL = Physics2D.Linecast(transform.position, wallCheckL.position, 1 << LayerMask.NameToLayer("Ground"));
		wallHitR = Physics2D.Linecast(transform.position, wallCheckR.position, 1 << LayerMask.NameToLayer("Ground"));
		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}
		gameObject.rigidbody2D.gravityScale = 3;
	}	
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(h));
		if (h != 0)
		{
			distance +=   Mathf.Abs(h) * moveForce;
			if (distance >= 100)
			{
				Statics.charProgression.stepsMade++;
				distance = 0;
			}
		}

		if (h == 0 && grounded && anim.GetInteger("state") != 0)
		{
			anim.SetInteger("state",0);
		}
		if (h != 0 && !jump)
		{
			anim.SetInteger("state",1);
		}
		if (GetComponent<FlyBehaviour>() != null)
		{
			if (!grounded && rigidbody2D.velocity.y < 0 )
			{
				anim.SetInteger("state",4);
			}
		}
		else
		{
			if (!jump && !grounded && rigidbody2D.velocity.y > 0)
			{
				anim.SetInteger("state",3);
			}
			else if (!jump && !grounded && rigidbody2D.velocity.y < 0)
			{
				anim.SetInteger("state",4);
			}
		}

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...

		if (!swim)
		{
			if(h * rigidbody2D.velocity.x < maxSpeed)
				// ... add a force to the player.
			{
				if (wallHitL && h < 0)
				{
					h = 0;
				}
				if (wallHitR && h > 0)
				{
					h = 0;
				}
				rigidbody2D.AddForce(Vector2.right * h * moveForce);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				bool rightArrow = Input.GetKeyDown(KeyCode.RightArrow);
				bool leftArrow = Input.GetKeyDown(KeyCode.LeftArrow);
				int direction=0;
				if (leftArrow)
				{
					direction = -1;
				}
				if (rightArrow)
				{
					direction = 1;
				}				
				if (wallHitL && leftArrow)
				{
					direction = 0;
				}
				if (wallHitR && rightArrow)
				{
					direction = 0;
				}
				rigidbody2D.AddForce(Vector2.right * moveForce * direction);
			}
		}	
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
		
		// If the player should jump...
		if(jump && canJump)
		{
			// Set the Jump animator trigger parameter.
			//anim.SetTrigger("Jump");
			
			// Play a random jump audio clip.
			//int i = Random.Range(0, jumpClips.Length);
			//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
			
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			anim.SetInteger("state",2);
			if (!Statics.charManager.canSwim)
			{
				Statics.charProgression.PlaySound(3,true);
			}
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
			Statics.charProgression.jumpsMade ++;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	

}
