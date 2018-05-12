using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour
{

    private TextMesh _thisTextMesh;
    private bool _textBool;
	// Use this for initialization
	void Start ()
	{
        _thisTextMesh = GetComponent<TextMesh>();
	    _textBool = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        if (_textBool)
        {
            _thisTextMesh.fontSize = 30;
            _thisTextMesh.text = "Developed by " + System.Environment.NewLine + 
                " Daniel Mihai Gherman" + System.Environment.NewLine + 
                System.Environment.NewLine +
                " Made with " + System.Environment.NewLine + 
                " Unity3D, 3DS Max and Sustance Painter 2" +
                System.Environment.NewLine +
                " Music from De Wolfe Music";
            _textBool = false;
        }
        else
        {
            _thisTextMesh.fontSize = 35;
            _thisTextMesh.text = "About";
            _textBool = true;
        }
    }
}
