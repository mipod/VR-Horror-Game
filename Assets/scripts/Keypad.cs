using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Keypad : MonoBehaviour
{
    public GameObject SafeDoor;
    private bool _doorOpen = false;
    private Animator _anim;
    private AudioSource _audioSourceSafe;
    private List<int> _values;
    private ButtonFunction _buttonFunction1,
        _buttonFunction2,
        _buttonFunction3,
        _buttonFunction4,
        _buttonFunction5,
        _buttonFunction6,
        _buttonFunction7,
        _buttonFunction8,
        _buttonFunction9;

    // Use this for initialization
    void Start()
    {
        GameObject button1 = GameObject.Find("button1");
        GameObject button2 = GameObject.Find("button2");
        GameObject button3 = GameObject.Find("button3");
        GameObject button4 = GameObject.Find("button4");
        GameObject button5 = GameObject.Find("button5");
        GameObject button6 = GameObject.Find("button6");
        GameObject button7 = GameObject.Find("button7");
        GameObject button8 = GameObject.Find("button8");
        GameObject button9 = GameObject.Find("button9");

        _anim = SafeDoor.GetComponent<Animator>();
        _audioSourceSafe = SafeDoor.GetComponent<AudioSource>();
        

        _buttonFunction1 = button1.GetComponent<ButtonFunction>();
        _buttonFunction2 = button2.GetComponent<ButtonFunction>();
        _buttonFunction3 = button3.GetComponent<ButtonFunction>();
        _buttonFunction4 = button4.GetComponent<ButtonFunction>();
        _buttonFunction5 = button5.GetComponent<ButtonFunction>();
        _buttonFunction6 = button6.GetComponent<ButtonFunction>();
        _buttonFunction7 = button7.GetComponent<ButtonFunction>();
        _buttonFunction8 = button8.GetComponent<ButtonFunction>();
        _buttonFunction9 = button9.GetComponent<ButtonFunction>();

        _values = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressed();
    }

    public void ButtonPressed(int button, bool pressed)
    {
        switch (button)
        {
            case 1:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 2:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 3:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 4:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 5:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 6:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 7:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 8:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);
                break;

            case 9:
                if (pressed)
                    _values.Add(button);
                else
                    _values.Remove(button);

                break;
        }


    }

    private void CheckPressed()
    {
        if (_values.Count == 4 && !_doorOpen)
        {
            if (_values[0] == 4 && _values[1] == 6 && _values[2] == 2 && _values[3] == 5)
            {
                _audioSourceSafe.Play();
                _anim.SetBool("correctCode",true);
                _doorOpen = true;

            }
            else
            {
                ResetButtons();
                _values = new List<int>();
            }
        }
    }

    private void ResetButtons()
    {
        _buttonFunction1.WrongButtonPressed();
        _buttonFunction2.WrongButtonPressed();
        _buttonFunction3.WrongButtonPressed();
        _buttonFunction4.WrongButtonPressed();
        _buttonFunction5.WrongButtonPressed();
        _buttonFunction6.WrongButtonPressed();
        _buttonFunction7.WrongButtonPressed();
        _buttonFunction8.WrongButtonPressed();
        _buttonFunction9.WrongButtonPressed();
    }

}
