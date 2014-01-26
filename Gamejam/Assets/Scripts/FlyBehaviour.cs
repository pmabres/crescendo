using UnityEngine;
using System.Collections;

public class FlyBehaviour : MonoBehaviour {
	public float flyStrength = 500f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
		{
			Statics.charProgression.PlaySound(7,true);
			rigidbody2D.AddForce(new Vector2(0f, flyStrength));
			gameObject.GetComponent<Animator>().SetInteger("state",5);
			//Player.rigidbody2D.AddForceAtPosition(new Vector2(0f,100f), Vector2.up);
		}
	}
}
