using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InGameMenu : MonoBehaviour
{

    public GameObject ReturnGameObject;
    private bool _displayMenu = false;

    private SteamVR_TrackedObject _trackedObj;

    private SteamVR_Controller.Device
     Controller
    {
        get { return SteamVR_Controller.Input((int)_trackedObj.index); }
    }

    // Use this for initialization
    void Awake()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Update is called once per frame
    void Update () {
        if (Controller.GetPress(EVRButtonId.k_EButton_Grip))
        {
            if (_displayMenu)
            {
                _displayMenu = false;
                ReturnGameObject.SetActive(false);
            }
            else
            {
                _displayMenu = true;
                ReturnGameObject.SetActive(true);
            }
        }
	}
}
