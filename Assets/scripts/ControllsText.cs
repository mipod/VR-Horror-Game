using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsText : MonoBehaviour
{

    public GameObject[] TextGameObjects;
    private bool txtDisplayed;

	// Use this for initialization
	void Start ()
	{
	    txtDisplayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Controller")) return;
        if (txtDisplayed)
        {
            foreach (var iGameObject in TextGameObjects)
            {
                iGameObject.SetActive(false);
                txtDisplayed = false;
            }
        }
        else
        {
            foreach (var iGameObject in TextGameObjects)
            {
                iGameObject.SetActive(true);
                txtDisplayed = true;
            }
        }
    }
}
