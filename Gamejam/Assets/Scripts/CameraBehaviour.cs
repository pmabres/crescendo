using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public GameObject MainCharacter;
	private bool isZooming;
	private float zoomValue;
	private int zoomSign;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		//folllow
		gameObject.transform.position = new Vector3(MainCharacter.transform.position.x,MainCharacter.transform.position.y,gameObject.transform.position.z);
		if (isZooming)
		{
			if (camera.orthographicSize >= zoomValue + 2 * zoomSign)
			{
				isZooming = false;
				zoomValue = 0;
				zoomSign = 0;
			}
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize,zoomValue,Time.deltaTime * 2);
		}
	}
	public void CameraZoom(float value)
	{
		isZooming = true;
		if (camera.orthographicSize > value)
		{
			zoomSign = -1;
		}
		else
		{
			zoomSign = 1;
		}
		zoomValue = value;
	}
}
