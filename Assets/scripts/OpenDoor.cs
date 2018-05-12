using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private int _count;
    private bool _fuse1;
    private bool _fuse2;
    private bool _fuse3;
    public GameObject Door;
    public GameObject OutsideLight;
    public GameObject TimmerGameObject;
    public GameObject Billy;
    public AudioSource DoorAudioSource;
    private Animator _anim;
    private DoorSwitch _doorSwitchScript;
    private GameTimer _gameTimmerScript;
	// Use this for initialization
	void Start ()
	{
	    _count = 0;
	    _anim = Door.GetComponent<Animator>();

        GameObject doorSwitch = GameObject.Find("switch");
	    _doorSwitchScript = doorSwitch.GetComponent<DoorSwitch>();

	    _gameTimmerScript = TimmerGameObject.GetComponent<GameTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        // If all 3 fuses are place do an action

       
        if (_count == 3 && _doorSwitchScript.SwithOn )
        {
            DoorAudioSource.Play();
            _anim.SetBool("openDoor",true);
            OutsideLight.SetActive(true);
            Billy.SetActive(true);
            _gameTimmerScript.GameRunning = false;
            StartCoroutine(Wait());
        }

    }

    void OnCollisionEnter(Collision col)
    {
        //Detects if an object has been placed in the fusebox
        if (col.gameObject.CompareTag("Fuse1") && !_fuse1)
        {
            _count++;
            Debug.Log(_count);
            _fuse1 = true;
        }
        if (col.gameObject.CompareTag("Fuse2") && !_fuse2)
        {
            _count++;
            _fuse2 = true;
            Debug.Log(_count);
        }
        if (col.gameObject.CompareTag("Fuse3") && !_fuse3)
        {
            _count++;
            _fuse3 = true;
            Debug.Log(_count);
        }
   
    }

    void OnCollisionExit(Collision col)
    {
        //Detects if an object has been taken from the fusebox
        if (col.gameObject.CompareTag("Fuse1") && _fuse1)
        {
            _count--;

            _fuse1 = false;
            Debug.Log(_count);
        }
        if (col.gameObject.CompareTag("Fuse2") && _fuse2)
        {
            _count--;
            _fuse2 = false;
            Debug.Log(_count);
        }
        if (col.gameObject.CompareTag("Fuse3") && _fuse3)
        {
            _count--;
            _fuse3 = false;
            Debug.Log(_count);
        }
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
