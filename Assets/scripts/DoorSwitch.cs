using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    private Animator _anim;
    private AudioSource _audio;
    public bool SwithOn;
	// Use this for initialization
	void Start ()
	{
	    SwithOn = false;
	    _anim = GetComponent<Animator>();
	    _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            if (SwithOn)
            {
                _anim.SetBool("doorSwitchBool",false);
                SwithOn = false;
                _audio.Play();
            }
            else
            {
                _anim.SetBool("doorSwitchBool", true);
                SwithOn = true;
                _audio.Play();
            }
        }
    }
}
