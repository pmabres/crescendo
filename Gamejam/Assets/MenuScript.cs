using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public bool Stop = true;
	public GameObject main ;
	public GameObject cam;
	public GameObject Playon;
	public GameObject Playoff;
	public GameObject Exiton;
	public GameObject Exitoff;
	private bool playbutton=true;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) && Stop)
		{
			playbutton = !playbutton;
		}

		Playon.SetActive(playbutton);
		Exitoff.SetActive(playbutton);
		Playoff.SetActive(!playbutton);
		Exiton.SetActive(!playbutton);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Stop = true;
		}
		if (Input.GetKeyDown(KeyCode.Return) && Stop)
		{
			if (playbutton)
				Stop = false;
			else
				Application.Quit();
		}
		if (Stop)
		{
			cam.SetActive(true);
			main.SetActive(false);
		}
		else
		{
			cam.SetActive(false);
			main.SetActive(true);
		}
	
	}
}
