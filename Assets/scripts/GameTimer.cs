using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public bool GameRunning;

    private float _timeer = 600f;
    private TextMesh _thisText;
    private int _minutes, _seconds;
    public GameObject GameOver;
    public GameObject leftGameObject;
    public GameObject rightGameObject;
    public GameObject YouseeGameObject;
    private LaserPoint _leftController;
    private LaserPoint _rightController;
    // Use this for initialization
    void Start ()
	{
	    _thisText = GetComponent<TextMesh>();
	    GameRunning = true;
        Debug.Log(leftGameObject);
	    _leftController = leftGameObject.GetComponent<LaserPoint>();
        _rightController = rightGameObject.GetComponent<LaserPoint>();

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (GameRunning)
	    {
	        _timeer -= Time.deltaTime;

	        if (_timeer > 0)
	        {


	            _minutes = Mathf.RoundToInt(_timeer) / 60;
	            _seconds = Mathf.RoundToInt(_timeer) % 60;

	            if (_seconds < 10)
	                _thisText.text = "0" + _minutes + ":0" + _seconds;
	            else
	                _thisText.text = "0" + _minutes + ":" + _seconds;
	        }
	        else
	        {
	            RenderSettings.fog = true;
	            if (RenderSettings.fogDensity < 1.5)
	                RenderSettings.fogDensity += 0.001f;
	            else
	            {
	                GameOver.SetActive(true);
	                this.gameObject.SetActive(false);
	                _leftController.enabled = false;
	                _rightController.enabled = false;
	                StartCoroutine(Wait());
	            }
	            if (Math.Abs(RenderSettings.fogDensity - 0.5f) < 0.02f)
	            {
	                YouseeGameObject.SetActive(false);
	            }

	        }
	    }
	    else
	    {
            // Freezes time when the game is won
            _minutes = Mathf.RoundToInt(_timeer) / 60;
            _seconds = Mathf.RoundToInt(_timeer) % 60;

            if (_seconds < 10)
                _thisText.text = "0" + _minutes + ":0" + _seconds;
            else
                _thisText.text = "0" + _minutes + ":" + _seconds;
        }
	}


     private IEnumerator Wait()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(0);
    }

}


