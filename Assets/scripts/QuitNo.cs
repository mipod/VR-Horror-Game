using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitNo : MonoBehaviour
{

    public GameObject YesGameObject, TextGameObject, OriginalTextGameObject;

    void OnTriggerEnter(Collider col)
    {
        YesGameObject.SetActive(false);
        TextGameObject.SetActive(false);
        OriginalTextGameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
