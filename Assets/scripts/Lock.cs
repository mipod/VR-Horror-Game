using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Rigidbody Lid;
    public GameObject LockGameObject;
    private Rigidbody _lockRigidbody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col){

        if (col.gameObject.CompareTag("key"))
        {
            if (!LockGameObject.GetComponent<Rigidbody>())
            {
                _lockRigidbody = LockGameObject.AddComponent<Rigidbody>();
                _lockRigidbody.useGravity = true;
                Lid.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
