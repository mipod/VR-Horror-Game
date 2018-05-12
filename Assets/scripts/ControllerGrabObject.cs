using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{
    private SteamVR_TrackedObject _trackedObj;

	// Local instance of the object that has collided with the controller
    private GameObject _collidingObject;
	// Local instance of the object that is attatched to the controler
    private GameObject _objectInHand;

	// FUnction that returns what controller is recieving the input command
    private SteamVR_Controller.Device
        Controller
    {
        get { return SteamVR_Controller.Input((int) _trackedObj.index); }
    }

    void Awake()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

	// Checks if the coliding object contains a rigid body
    private void SetCollidingObject(Collider col)
    {
        if (_collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
		// Asigns the coliding object to the local variable
        _collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!_collidingObject)
        {
            return;
        }
        _collidingObject = null;
    }

	// Function that conects the object to the controller
    private void GrabObject()
    {
        _objectInHand = _collidingObject;
        _collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = _objectInHand.GetComponent<Rigidbody>();
    }

	// Defines the fixed joint used to conect the controller to the object
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

	// When the object is released, removes the fixed joint and performs actions over the object's rigidbody
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            _objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            _objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        _objectInHand = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (_collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (_objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}