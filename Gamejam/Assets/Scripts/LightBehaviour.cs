using UnityEngine;
using System.Collections;

public class LightBehaviour : MonoBehaviour {

	private bool isChanging;
	private float intensity;
	private float zPosition;
	private int intensitySign;
	private int zPositionSign;
	private float timeChange;
	public bool isGlowing;
	public float lightIntensityE;
	public float lightOriginalIntensity;
	public float lightProposedIntensity;
	public float lightIntensityS;
	public float lightGlowInterval;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isChanging)
		{

			gameObject.light.intensity = Mathf.Lerp(gameObject.light.intensity,intensity,Time.deltaTime * timeChange);
			gameObject.transform.localPosition = new Vector3 (transform.localPosition.x,transform.localPosition.y, Mathf.Lerp(gameObject.transform.localPosition.z,zPosition,Time.deltaTime * timeChange));
		}
		if (isGlowing && !isChanging) LightGlow();
	}
	public void ChangeValue(float intensity,float timeChange)
	{	
		/*if (!isChanging)
		{
			if (intensity < light.intensity)
			{
				intensitySign = -1;
			}
			else
			{
				intensitySign = 1;
			}*/
			zPositionSign = 0;
			this.timeChange = timeChange;
			this.intensity = intensity;
		//}
		isChanging = true;
	}
	public void ChangeValue(float intensity, float z,float timeChange)
	{
		/*if (!isChanging)
		{
			if (intensity < light.intensity)
			{
				intensitySign = -1;
			}
			else
			{
				intensitySign = 1;
			}
			if (z < transform.localPosition.z)
			{
				zPositionSign = -1;
			}
			else
			{
				zPositionSign = 1;
			}*/
			this.timeChange = timeChange;
			this.intensity = intensity;
			
			zPosition = z;
		//}
		isChanging = true;
	}
	public void Glow(bool val,float glowPercentage,float glowInterval)
	{
		if (!isGlowing)
		{
			lightIntensityE = gameObject.light.intensity * glowPercentage;
			lightOriginalIntensity = gameObject.light.intensity;
			lightProposedIntensity = lightIntensityE;
			lightIntensityS = lightOriginalIntensity;
			lightGlowInterval = glowInterval;
		}
		isGlowing = val;
	}
	private void LightGlow()
	{

		if (lightIntensityS <= lightProposedIntensity)
		{
			lightIntensityE = lightOriginalIntensity +1;
		}
		else if (lightIntensityS >= lightOriginalIntensity)
		{
			lightIntensityE = lightProposedIntensity -1;
		}
		lightIntensityS = Mathf.Lerp(lightIntensityS,lightIntensityE,Time.deltaTime*lightGlowInterval);
		gameObject.light.intensity = lightIntensityS;
	}
}
