using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
	public GameObject MainCharacter;
	// Use this for initialization
	void Start () 
	{
		Statics.charProgression = MainCharacter.GetComponent<CharacterProgression>();
		Statics.charManager = MainCharacter.GetComponent<CharacterManager>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
