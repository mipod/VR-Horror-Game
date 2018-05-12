using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{

    public GameObject YesGameObject, NoGameObject, TextGameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            YesGameObject.SetActive(true);
            NoGameObject.SetActive(true);
            TextGameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
