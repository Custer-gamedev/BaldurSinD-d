using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStrength : MonoBehaviour
{
	public Light _light;
	private void Start()
	{
		_light = this.GetComponent<Light>();
	}

	private void Update()
	{
		float weeLight = Random.Range(5f, 6f);
		_light.intensity = weeLight;
	}
}
