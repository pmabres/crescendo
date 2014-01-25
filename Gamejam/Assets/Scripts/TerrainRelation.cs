using UnityEngine;
using System.Collections;

public class TerrainRelation : MonoBehaviour 
{
	public GameObject Next;
	public GameObject Previous;
	public GameObject Player;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.name == "Background2")
		{
			/*float val = transform.position.x + transform.localScale.x;
			Debug.Log("Jugador: " + Player.transform.position.x);
			Debug.Log("ESCENARIO Inicio: " + transform.position.x);
			Debug.Log("ESCENARIO Fin: " + val);
			Debug.Log("ESCENARIO Ancho: " + renderer.bounds.size.x);*/
		}
		if (Player.transform.position.x >= transform.position.x && Player.transform.position.x <= renderer.bounds.size.x + transform.position.x)
		{		

			if (Next == null)
			{
				GameObject Current = Previous;
				while (Current.GetComponent<TerrainRelation>().Previous != null)
				{
					Current = Current.GetComponent<TerrainRelation>().Previous;
				}
				Current.transform.position = new Vector3(transform.position.x + renderer.bounds.size.x ,transform.position.y,transform.position.z);
				Next = Current;
				Current.GetComponent<TerrainRelation>().Next.GetComponent<TerrainRelation>().Previous = null;
				Current.GetComponent<TerrainRelation>().Next = null;
				Current.GetComponent<TerrainRelation>().Previous = gameObject;
			}
			if (Previous == null)
			{
				GameObject Current = Next;
				while (Current.GetComponent<TerrainRelation>().Next != null)
				{
					Current = Current.GetComponent<TerrainRelation>().Next;
				}
				Current.transform.position = new Vector3(transform.position.x - renderer.bounds.size.x ,transform.position.y,transform.position.z);
				Previous = Current;
				Current.GetComponent<TerrainRelation>().Previous.GetComponent<TerrainRelation>().Next = null;
				Current.GetComponent<TerrainRelation>().Previous = null;
				Current.GetComponent<TerrainRelation>().Next = gameObject;
			}
		}
	}
}
