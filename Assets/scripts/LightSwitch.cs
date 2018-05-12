using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private bool _lightsOn;
    private bool _lightsOnOnce;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject LightTube1;
    public GameObject LightTube2;
    public GameObject LightTube3;
    public GameObject LightTube4;
    public GameObject Number4;
    public GameObject Number5;
    public GameObject Number6;
    public GameObject Number2;

    public Material LightOn;
    public Material LightOff;

    private static Animator _anim;
    private AudioSource _audio;
    private Renderer _rendLightTube1;
    private Renderer _rendLightTube2;
    private Renderer _rendLightTube3;
    private Renderer _rendLightTube4;

    // Use this for initialization
    void Start()
    {
        _lightsOn = false;
        _lightsOnOnce = false;
        _anim = GetComponentInParent<Animator>();
        _audio = GetComponent<AudioSource>();
        _rendLightTube1 = LightTube1.GetComponent<Renderer>();
        _rendLightTube2 = LightTube2.GetComponent<Renderer>();
        _rendLightTube3 = LightTube3.GetComponent<Renderer>();
        _rendLightTube4 = LightTube4.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            if (!_lightsOn)
            {
                _audio.Play();
                Light1.SetActive(true);
                Light2.SetActive(true);
                _lightsOn = true;
                _lightsOnOnce = true;
                _anim.SetBool("lightsOn", true);
                _rendLightTube1.material = LightOn;
                _rendLightTube2.material = LightOn;
                _rendLightTube3.material = LightOn;
                _rendLightTube4.material = LightOn;
                Number2.SetActive(false);
                Number4.SetActive(false);
                Number6.SetActive(false);
                Number5.SetActive(false);
            }

            else
            {
                _audio.Play();
                Light1.SetActive(false);
                Light2.SetActive(false);
                _lightsOn = false;
                _anim.SetBool("lightsOn", false);
                _rendLightTube1.material = LightOff;
                _rendLightTube2.material = LightOff;
                _rendLightTube3.material = LightOff;
                _rendLightTube4.material = LightOff;
                if (_lightsOnOnce)
                {
                    //display numbers
                    Number2.SetActive(true);
                    Number4.SetActive(true);
                    Number6.SetActive(true);
                    Number5.SetActive(true);
                }
            }
        }
    }
}