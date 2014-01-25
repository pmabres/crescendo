using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0)
		{
			rigidbody2D.AddForce(new Vector2(0f, 55f));
			if(Input.GetButtonDown("Jump"))
			{
				rigidbody2D.AddForce(new Vector2(0f, 1000f));
			}
		}
	}
}
