using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	private bool isZooming;
	private float zoomValue;
	private int zoomSign;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
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
