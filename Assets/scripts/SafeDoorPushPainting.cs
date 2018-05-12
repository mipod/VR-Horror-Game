using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDoorPushPainting : MonoBehaviour
{
    private Rigidbody _thisBody;

	// Use this for initialization
	void Start ()
	{
	    _thisBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided");
        Debug.Log(col);
        if (col.gameObject.CompareTag("safeDoor"))
        {
            Debug.Log("hit painting");
            _thisBody.AddForce(0,0,1f,ForceMode.Impulse);
        } 
    }
}

