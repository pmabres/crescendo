using UnityEngine;
using System.Collections;

public class CharacterProgression : MonoBehaviour {
	public int stepsMade=0;
	public int jumpsMade=0;
	public int waterBreeded=0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (jumpsMade > 10)
		{
			gameObject.GetComponent<CharacterManager>().canFly = true;
		}
		if (stepsMade >= 1 && gameObject.GetComponent<CharacterManager>().isLight)
		{
			gameObject.GetComponent<CharacterManager>().isEnergy = true;
			gameObject.GetComponent<CharacterManager>().isLight = false;
		}
		if (stepsMade >= 10 && gameObject.GetComponent<CharacterManager>().isEnergy)
		{
			gameObject.GetComponent<CharacterManager>().isEnergy = false;
			gameObject.GetComponent<CharacterManager>().isMatter = true;

		}
	}
}
