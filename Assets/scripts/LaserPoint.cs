using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
	// Variable for the laser 
    public GameObject LaserPrefab;
	// Variable of the real world perimeter
	public Transform CameraRigTransform;
	// Variable for cicle model that will idicate where to teleport
    public GameObject TeleportReticlePrefab;
	// Variable that accounts for the size of the circle indicator
    public Vector3 TeleportReticleOffset;
	// Variable for the position insied the perimeter of the player
	public Transform HeadTransform;
	// Variable for the alowed teleporting area
    public LayerMask TeleoportMask;
	// Local controller variable
    private SteamVR_TrackedObject _trackedObj;
	// Local laser variable
    private GameObject _laser;
    private Transform _laserTransform;
    private Vector3 _hitPoint;
    private GameObject _reticle;
    private Transform _teleportReticleTransform;
    private bool _shouldTeleport;

    private SteamVR_Controller.Device
        Controller
    {
        get { return SteamVR_Controller.Input((int) _trackedObj.index); }
    }

    void Awake()
    {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit)
    {
        //Shows the laser
        _laser.SetActive(true);
        //Positions the laser between the controller and the point
        _laserTransform.position = Vector3.Lerp(_trackedObj.transform.position, _hitPoint, .5f);
        //Points the laser at the position
        _laserTransform.LookAt(_hitPoint);
        //Scales the laser
        _laserTransform.localScale = new Vector3(_laserTransform.localScale.x, _laserTransform.localScale.y, hit.distance);
    }

    // Use this for initialization
    void Start()
    {
        _laser = Instantiate(LaserPrefab);
        _laserTransform = _laser.transform;

        _reticle = Instantiate(TeleportReticlePrefab);
        _teleportReticleTransform = _reticle.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if the toutchpad is held down
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //creates raycast
            RaycastHit hit;

            //if something is hit store the point
            if (Physics.Raycast(_trackedObj.transform.position, transform.forward, out hit, 100, TeleoportMask))
            {
                _hitPoint = hit.point;
                ShowLaser(hit);
                _reticle.SetActive(true);
                _teleportReticleTransform.position = _hitPoint + TeleportReticleOffset;
                _shouldTeleport = true;
            }
        }
        // Hides the laser when totuch pad is released
        else
        {
            _laser.SetActive(false);
            _reticle.SetActive(false);
        }
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && _shouldTeleport)
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        _shouldTeleport = false;
        _reticle.SetActive(false);

        //Calculate difference between position of camera rig and players head
        Vector3 difference = CameraRigTransform.position - HeadTransform.position;
        //reset the y
        difference.y = 0;
        //Move the camera to the position of the hit point
        CameraRigTransform.position = _hitPoint + difference;
    }
}