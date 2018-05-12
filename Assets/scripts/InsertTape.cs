using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertTape : MonoBehaviour
{

    public GameObject Tape;
    public GameObject Tv;
    private Rigidbody _tapeRigidbody;
    private Tvscript _tvScript;

	// Use this for initialization
	void Start ()
	{
	    _tapeRigidbody = Tape.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _tvScript = Tv.GetComponent<Tvscript>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("tape"))
        {
            _tapeRigidbody.useGravity = false;
            _tapeRigidbody.isKinematic = true;
            _tvScript.TapeIn = true;

        }
    }
}
