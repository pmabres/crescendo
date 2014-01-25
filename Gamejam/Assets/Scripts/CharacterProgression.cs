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
	}
}
