using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	public bool isLight;
	public bool isEnergy;
	public bool isMatter;
	public bool canSee;
	public bool canWalk;
	public bool canSwim;
	public bool canFly;
	public bool canHit;
	public bool canClimb;
	public bool canFloat;
	public bool test;
	public float seeRange;
	public float walkSpeed;
	public float lightGlowSpeed=5;
	private bool activateLight;
	private bool activateEnergy;
	private bool activateMatter;
	void Start () 
	{
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (isLight)
		{
			isEnergy = false;
			isMatter = false;
			activateMatter = false;
			canFloat = true;
			activateEnergy = false;
			Camera.main.GetComponent<CameraBehaviour>().CameraZoom(3.34f);
			if (!activateLight) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(8,-0.01f,5);
			gameObject.GetComponentInChildren<LightBehaviour>().Glow(false,0f,0);
			gameObject.GetComponent<FloatBehaviour>().speed = new Vector2(0.4f,0.4f);
			activateLight = true;

		}
		if (isEnergy)
		{
			activateLight = false;
			activateMatter = false;
			isLight = false;
			isMatter = false;
			canFloat = true;
			canWalk = false;
			gameObject.GetComponent<FloatBehaviour>().speed = new Vector2(1,1);
			if (!activateEnergy) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(3,-1f,5);
			gameObject.GetComponentInChildren<LightBehaviour>().Glow(true,0.5f,lightGlowSpeed);
			Camera.main.GetComponent<CameraBehaviour>().CameraZoom(7);
			activateEnergy = true;

		}
		if (isMatter)
		{
			activateLight = false;
			activateEnergy = false;
			isEnergy = false;
			isLight = false;
			canFloat = false;
			canWalk = true;
			gameObject.GetComponentInChildren<LightBehaviour>().Glow(false,0f,0);
			if (!activateMatter) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(1,-10f,2);
			Camera.main.GetComponent<CameraBehaviour>().CameraZoom(15);
			gameObject.GetComponent<PlayerControl>().maxSpeed = 2;
			activateMatter = true;
		}
		CheckFlags();
	}
	void CheckFlags()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = isMatter;
		gameObject.GetComponent<PlayerControl>().enabled = canWalk;
		gameObject.GetComponent<WaterBehaviour>().enabled = canSwim;
		gameObject.GetComponent<FlyBehaviour>().enabled = canFly;
		gameObject.GetComponent<FloatBehaviour>().enabled = canFloat;
	}
}
