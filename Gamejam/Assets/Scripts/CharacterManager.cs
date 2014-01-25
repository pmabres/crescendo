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

	public float seeRange;
	public float walkSpeed;
	public float lightGlowSpeed=5;
	private float lightIntensityS;
	private float lightIntensityE;
	private float lightOriginalIntensity;
	private float proposedLightIntensity;
	void Start () 
	{
		lightIntensityS = gameObject.GetComponentInChildren<Light>().intensity;
		lightOriginalIntensity = lightIntensityS;
		proposedLightIntensity = lightIntensityS * 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (isLight)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<PlayerControl>().maxSpeed = 1;
			isEnergy = false;
			isMatter = false;
		}
		if (isEnergy)
		{
			isLight = false;
			isMatter = false;		
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			if (lightIntensityS <= proposedLightIntensity)
			{
				lightIntensityE = lightOriginalIntensity +1;
			}
			else if (lightIntensityS >= lightOriginalIntensity)
			{
				lightIntensityE = proposedLightIntensity -1;
			}
			gameObject.GetComponent<PlayerControl>().maxSpeed = 2;
			lightIntensityS = Mathf.Lerp(lightIntensityS,lightIntensityE,Time.deltaTime*lightGlowSpeed);
			gameObject.GetComponentInChildren<Light>().intensity = lightIntensityS;
		}
		if (isMatter)
		{
			isEnergy = false;
			isLight = false;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		if (canSee)
		{
		}
		if (canWalk)
		{
		}
		if (canSwim)
		{
			gameObject.GetComponent<WaterBehaviour>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<WaterBehaviour>().enabled = false;
		}
		if (canFly)
		{
			gameObject.GetComponent<FlyBehaviour>().enabled = true;
		}
		else
		{
			gameObject.GetComponent<FlyBehaviour>().enabled = false;
		}
		
	}
}
