using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
