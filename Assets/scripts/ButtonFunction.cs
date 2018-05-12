using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{

    public string AnimatBoolName;
    public int ButtonValue;

    private Animator _anim;
    private AudioSource _audio;
    private bool _pressed;
    private Keypad _keypadScript;


	// Use this for initialization
	void Start ()
	{
        GameObject keypad = GameObject.Find("keypad");
	    _keypadScript = keypad.GetComponent<Keypad>();
	    _audio = GetComponent<AudioSource>();
	    _anim = GetComponent<Animator>();
	    _pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            if (!_pressed)
            {
                _anim.SetBool(AnimatBoolName, true);
                _pressed = true;
                _audio.Play();
                _keypadScript.ButtonPressed(ButtonValue,_pressed);
            }
            else
            {
                _anim.SetBool(AnimatBoolName,false);
                _pressed = false;
                _keypadScript.ButtonPressed(ButtonValue, _pressed);
            }
        }
    }

    public void WrongButtonPressed()
    {
        if (_pressed)
        {
            _pressed = false;
            _anim.SetBool(AnimatBoolName, false);
        }
    }

}
