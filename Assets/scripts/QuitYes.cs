using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitYes : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Application.Quit();
    }
}
