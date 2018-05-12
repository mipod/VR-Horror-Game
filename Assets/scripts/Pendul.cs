using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendul : MonoBehaviour
{
    private Rigidbody _rigid;
	// Use this for initialization
	void Start ()
	{
        _rigid = GetComponent<Rigidbody>();
        _rigid.AddForce(0,0,0.5f,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
