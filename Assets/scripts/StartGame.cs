using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
    private bool loading;
   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Controller"))
        {
            if(!loading)
            loading = true;
            StartCoroutine(LoadSceneMode());
        }
    }

    IEnumerator LoadSceneMode()
    {
        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(1);

        while (!async.isDone)
        {
            yield return null;
        }
    }

}
