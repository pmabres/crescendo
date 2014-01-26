using UnityEngine;
using System.Collections;

public class CharacterProgression : MonoBehaviour {
	public int stepsMade=0;
	public int jumpsMade=0;
	public int waterBreeded=0;
	AudioSource[] aSource;
	// Use this for initialization
	void Start () 
	{
		aSource = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (stepsMade >= 1 && Statics.charManager.isLight)
		{
			Statics.charManager.isEnergy = true;
			Statics.charManager.isLight = false;
			if (Statics.charManager.isEnergy)
			{
				ChangeSound(0,0.25f,0.5f);
			}
		}
		if (stepsMade >= 10 && Statics.charManager.isEnergy)
		{
			Statics.charManager.isEnergy = false;
			Statics.charManager.isMatter = true;
			if (Statics.charManager.isMatter)
			{
				aSource[0].loop = false;

				ChangeSound(0,-1f,15f);
				ChangeSound(1,0.25f,0.5f);
				PlaySound(6,true);
			}
		}

		if (stepsMade >= 50 && Statics.charManager.isMatter)
		{
			Statics.charManager.canSee = true;
		}

		if (stepsMade >= 90 && Statics.charManager.isMatter)
		{
			Statics.charManager.legs = true;
		}

		if (stepsMade >= 160 && !Statics.charManager.canSwim && !Statics.charManager.canFly && Statics.charManager.legs)
		{
			Statics.charManager.tail = true;
			Statics.charManager.canHit = true;
		}

		if (jumpsMade > 10 && !Statics.charManager.canSwim && !Statics.charManager.tail && Statics.charManager.legs)
		{
			Statics.charManager.canFly = true;
		}

		if (waterBreeded >= 250 && !Statics.charManager.canFly && !Statics.charManager.tail && Statics.charManager.legs)
		{
			Statics.charManager.canSwim = true;
		}
	}
	public void ChangeSound(int SourceIndex, float Volume, float TimeMultiplier)
	{
		aSource[SourceIndex].volume = Mathf.Lerp (aSource[SourceIndex].volume, Volume, Time.deltaTime * TimeMultiplier);
	}
	public void PlaySound(int SourceIndex, bool Play)
	{
		if (Play) 
		{
			aSource [SourceIndex].Play ();
		}
		else
		{
			aSource [SourceIndex].Stop ();
		}
	}
}
