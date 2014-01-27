using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {

	public bool canSwim;
	public float SwimForce=500;
	public float SwimResist=90;
	bool inWater=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0)
		{
			if (!inWater)
			{
				inWater = true;
				Statics.charProgression.PlaySound(4,true);
			}

			Statics.charProgression.ChangeSound(1,-1,0.5f);
			Statics.charProgression.ChangeSound(2,0.25f,0.5f);



			if(!canSwim)
			{
				rigidbody2D.AddForce(new Vector2(0f, 65f));
				Statics.charProgression.waterBreeded ++;
				gameObject.GetComponent<PlayerControl>().enabled = false;
				//gameObject.GetComponent<Animator>().SetInteger("state",5);
			}
			else
			{
				rigidbody2D.AddForce(new Vector2(0f, SwimResist));
				gameObject.GetComponent<PlayerControl>().enabled = true;
			}

			if(Input.GetButtonDown("Jump"))
			{
				Debug.Log("nada");
				Statics.charProgression.PlaySound(5,true);
				rigidbody2D.AddForce(new Vector2(0f, SwimForce));
			}
			if(Input.GetButtonDown("Down"))
			{
				Statics.charProgression.PlaySound(5,true);
				rigidbody2D.AddForce(new Vector2(0f, -SwimForce/2));
			}
		}
		else if(Statics.charManager.isMatter &&  transform.position.y > 0)
		{
			if (inWater)
			{
				inWater = false;
				Statics.charProgression.PlaySound(4,true);
			}
			gameObject.GetComponent<PlayerControl>().enabled = true;
			Statics.charProgression.ChangeSound(1,0.25f,0.5f);
			Statics.charProgression.ChangeSound(2,-1,0.5f);			
		}
	}
}
