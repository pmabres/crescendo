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

		if (stepsMade >= 10 && Statics.charManager.isLight)
		{
			Statics.charManager.isEnergy = true;
			Statics.charManager.isLight = false;
			if (Statics.charManager.isEnergy)
			{
				ChangeSound(0,0.25f,0.5f);
				Evol();
			}
		}
		if (stepsMade >= 20 && Statics.charManager.isEnergy)
		{
			Statics.charManager.isEnergy = false;
			Statics.charManager.isMatter = true;
			if (Statics.charManager.isMatter)
			{
				aSource[0].loop = false;

				ChangeSound(0,-1f,15f);
				ChangeSound(1,0.25f,0.5f);
				Evol();
			}
		}

		if (stepsMade >= 100 && Statics.charManager.isMatter && !Statics.charManager.canSee)
		{
			Statics.charManager.canSee = true;
			Evol();
		}

		if (stepsMade >= 200 && Statics.charManager.isMatter && !Statics.charManager.legs)
		{
			Statics.charManager.legs = true;
			Evol();
		}

		if (stepsMade >= 400 && !Statics.charManager.canSwim && !Statics.charManager.canFly && !Statics.charManager.tail && Statics.charManager.legs)
		{
			Statics.charManager.tail = true;
			Statics.charManager.canHit = true;
			Evol();
		}

		if (jumpsMade > 15 && !Statics.charManager.canSwim && !Statics.charManager.tail && !Statics.charManager.canFly && Statics.charManager.legs)
		{
			Statics.charManager.canFly = true;
			Evol();
		}

		if (waterBreeded >= 250 && !Statics.charManager.canFly && !Statics.charManager.tail && !Statics.charManager.canSwim && Statics.charManager.legs)
		{
			Statics.charManager.canSwim = true;
			Evol();
		}
	}
	public void Evol()
	{
		PlaySound(6,true);
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
