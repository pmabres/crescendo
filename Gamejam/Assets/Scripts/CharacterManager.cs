using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {
	public GameObject[] characters;
	public bool isLight;
	public bool isEnergy;
	public bool isMatter;
	public bool legs;
	public bool tail;
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
	public GameObject sky;
	private bool activateLight;
	private bool activateEnergy;
	private bool activateMatter;
	private GameObject currentCharacter;
	private int evolutionNumber;
	public SpecialEffectsHelper shelper;
	void Start () 
	{
		isLight = true;
		currentCharacter = characters[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () 
{		
		if (sky != null && currentCharacter != null)
		{
			sky.transform.position = currentCharacter.transform.position * 0.4f;
		}
		if (isLight)
		{
			isEnergy = false;
			isMatter = false;
			activateMatter = false;
			canFloat = true;
			activateEnergy = false;
			characters[0].SetActive(true);
			characters[1].SetActive(false);
			characters[2].SetActive(false);
			characters[3].SetActive(false);
			characters[4].SetActive(false);
			characters[5].SetActive(false);
			characters[6].SetActive(false);
			if (currentCharacter != null)
			{
				characters[0].transform.position = currentCharacter.transform.position;
			}

			currentCharacter = characters[0];
			gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[0];
			Camera.main.GetComponent<CameraBehaviour>().CameraZoom(1f);
			if (!activateLight) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(1.5f,-0.001f,5);
			gameObject.GetComponentInChildren<LightBehaviour>().Glow(false,0f,0);
			characters[0].GetComponent<FloatBehaviour>().speed = new Vector2(0.4f,0.4f);
			Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[0];
			activateLight = true;
			if (evolutionNumber != 1)
			{
				shelper.Explosion(currentCharacter.transform.position);
			}
			evolutionNumber = 1;

		}
		if (isEnergy)
		{
			activateLight = false;
			activateMatter = false;
			isLight = false;
			isMatter = false;
			canFloat = true;
			canWalk = false;

			characters[0].SetActive(true);
			characters[1].SetActive(false);
			characters[2].SetActive(false);
			characters[3].SetActive(false);
			characters[4].SetActive(false);
			characters[5].SetActive(false);
			characters[6].SetActive(false);
			characters[0].GetComponent<FloatBehaviour>().speed = new Vector2(1,1);
			characters[0].transform.position = currentCharacter.transform.position;
			currentCharacter = characters[0];
			gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[0];
			if (!activateEnergy) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(6f,-0.01f,5);
			gameObject.GetComponentInChildren<LightBehaviour>().Glow(true,0.5f,lightGlowSpeed);
			Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2);
			Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[0];
			activateEnergy = true;
			if (evolutionNumber != 2)
			{
				shelper.Explosion(currentCharacter.transform.position);
			}
			evolutionNumber = 2;

		}
		if (isMatter)
		{
			activateLight = false;
			activateEnergy = false;
			isEnergy = false;
			isLight = false;
			canFloat = false;
			canWalk = true;
			if (canFly)
			{
				characters[4].transform.position = currentCharacter.transform.position;
				currentCharacter = characters[4];
				characters[0].SetActive(false);
				characters[1].SetActive(false);
				characters[2].SetActive(false);
				characters[3].SetActive(false);
				characters[4].SetActive(true);
				characters[5].SetActive(false);
				characters[6].SetActive(false);
				//gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.5f,-10f,2);
				Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.8f);
				Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[4];
				gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[4];
				if (evolutionNumber != 3)
				{
					shelper.Explosion(currentCharacter.transform.position);
				}
				evolutionNumber = 3;
			}
			else if(canSwim)
			{
				characters[5].transform.position = currentCharacter.transform.position;
				currentCharacter = characters[5];
				characters[0].SetActive(false);
				characters[1].SetActive(false);
				characters[2].SetActive(false);
				characters[3].SetActive(false);
				characters[4].SetActive(false);
				characters[5].SetActive(true);
				characters[6].SetActive(false);
				//gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.5f,-10f,2);
				Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.8f);
				Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[5];
				gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[5];
				if (evolutionNumber != 4)
				{
					shelper.Explosion(currentCharacter.transform.position);
				}
				evolutionNumber = 4;
			}
			else
			{
				if (legs)
				{
					if (tail)
					{
						characters[6].transform.position = currentCharacter.transform.position;
						currentCharacter = characters[6];
						characters[0].SetActive(false);
						characters[1].SetActive(false);
						characters[2].SetActive(false);
						characters[3].SetActive(false);
						characters[4].SetActive(false);
						characters[5].SetActive(false);
						characters[6].SetActive(true);
						//gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.5f,-10f,2);
						Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.8f);
						Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[6];
						gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[6];
						if (evolutionNumber != 5)
						{
							shelper.Explosion(currentCharacter.transform.position);
						}
						evolutionNumber = 5;
					}
					else
					{
						characters[3].transform.position = currentCharacter.transform.position;
						currentCharacter = characters[3];
						characters[0].SetActive(false);
						characters[1].SetActive(false);
						characters[2].SetActive(false);
						characters[3].SetActive(true);
						characters[4].SetActive(false);
						characters[5].SetActive(false);
						characters[6].SetActive(false);
						//gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.5f,-10f,2);
						Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.8f);
						Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[3];
						gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[3];
						if (evolutionNumber != 6)
						{
							shelper.Explosion(new Vector3(currentCharacter.transform.position.x,currentCharacter.transform.position.y,-1));
						}
						evolutionNumber = 6;
					}
				}
				else
				{
					if(!canSee)
					{
						characters[1].transform.position = currentCharacter.transform.position;
						currentCharacter = characters[1];
						characters[0].SetActive (false);
						characters[1].SetActive (true);
						characters[2].SetActive(false);
						characters[3].SetActive(false);
						characters[4].SetActive(false);
						characters[5].SetActive(false);
						characters[6].SetActive(false);
						gameObject.GetComponentInChildren<LightBehaviour>().Glow(false,0f,0);
						if (!activateMatter) gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.01f,-10f,2);
						Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.2f);
						Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[1];
						gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[1];
						//gameObject.GetComponent<PlayerControl>().maxSpeed = 2;
						activateMatter = true;
						if (evolutionNumber != 7)
						{
							shelper.Explosion(currentCharacter.transform.position);
						}
						evolutionNumber = 7;
					}
					else
					{
						characters[2].transform.position = currentCharacter.transform.position;
						currentCharacter = characters[2];
						characters[0].SetActive(false);
						characters[1].SetActive(false);
						characters[2].SetActive(true);
						characters[3].SetActive(false);
						characters[4].SetActive(false);
						characters[5].SetActive(false);
						characters[6].SetActive(false);
						gameObject.GetComponentInChildren<LightBehaviour>().ChangeValue(0.5f,-10f,2);
						Camera.main.GetComponent<CameraBehaviour>().CameraZoom(2.6f);
						Camera.main.GetComponent<CameraBehaviour>().MainCharacter = characters[2];
						gameObject.GetComponentInChildren<LightBehaviour>().MainCharacter = characters[2];
						if (evolutionNumber != 8)
						{
							shelper.Explosion(currentCharacter.transform.position);
						}
						evolutionNumber = 8;
					}
				}
			}
		}
		else
		{
			characters[1].SetActive(false);
		}

		CheckFlags();
	}
	void CheckFlags()
	{
		if (currentCharacter.GetComponent<SpriteRenderer>() != null) currentCharacter.GetComponent<SpriteRenderer>().enabled = isMatter;
		if (currentCharacter.GetComponent<PlayerControl>() != null) currentCharacter.GetComponent<PlayerControl>().enabled = canWalk;
		if (currentCharacter.GetComponent<WaterBehaviour>() != null) currentCharacter.GetComponent<WaterBehaviour>().canSwim = canSwim;
		if (currentCharacter.GetComponent<FlyBehaviour>() != null) currentCharacter.GetComponent<FlyBehaviour>().enabled = canFly;
		if (currentCharacter.GetComponent<FloatBehaviour>() != null) currentCharacter.GetComponent<FloatBehaviour>().enabled = canFloat;
		
	}
}
