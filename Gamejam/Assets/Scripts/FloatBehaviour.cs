using UnityEngine;
using System.Collections;

public class FloatBehaviour : MonoBehaviour {

	public Vector2 speed;
	private float distance;
	// Use this for initialization
	void Start ()
	{
		
	}

	private Vector2 movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		gameObject.rigidbody2D.gravityScale = 0;
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(h));
		if (inputX != 0)
		{
			distance +=  Mathf.Abs(inputX) * speed.x;
			if (distance >= 30)
			{
				if (Statics.charProgression != null)
				{
					Statics.charProgression.stepsMade++;
				}

				distance = 0;
			}
		}

		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}
}
