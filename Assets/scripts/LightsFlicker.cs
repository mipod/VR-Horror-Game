using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour {

    private float _minFlickerSpeed = 0.1f;
    private float _maxFlickerSpeed = 1.0f;
    private Light _light;
   

	// Use this for initialization
	void Start ()
	{
	    _light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

	    if (_light.enabled)
	    {
	        if (Random.value > 0.9)
	        {
	            _light.enabled = false;
	            var timer = 0f;
	            while (timer < 100f)
	            {
	                timer = Time.deltaTime;
	            }
	            _light.enabled = true;
	        }
	    }
    }
}
