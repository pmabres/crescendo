using UnityEngine;
using System.Collections;

public class FlyBehaviour : MonoBehaviour {
	public float flyStrength = 1000f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
		{
			rigidbody2D.AddForce(new Vector2(0f, flyStrength));
			//Player.rigidbody2D.AddForceAtPosition(new Vector2(0f,100f), Vector2.up);
		}
	}
}
