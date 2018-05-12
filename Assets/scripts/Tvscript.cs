using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tvscript : MonoBehaviour
{

    public Material TvOff;
    public Material Static;
    public Material Saw;
    public GameObject DisplayTimer;
    public GameObject TvLight;
    public GameObject StaticPic;
    public GameObject YouSeeMore;
    public bool TapeIn;
    public AudioClip tvClip;

    private float _timer;
    private Material[] _currentMaterials;
    private Renderer _current;
    private bool _tvStatic, _tvOff, _tvSaw;
    private AudioSource _sounds;
	// Use this for initialization
	void Start ()
	{
	    _tvOff = true;
	    _tvStatic = false;
	    _tvSaw = false;
	    _current = GetComponent<Renderer>();
	    _sounds = GetComponent<AudioSource>();
	    _currentMaterials = _current.materials;
	    TapeIn = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _timer += Time.deltaTime;

	    if (_timer > 5 && _timer <6 && !_tvStatic)
	    {
            StaticPic.SetActive(true);
            TvLight.SetActive(true);
            _sounds.Play();
            _currentMaterials = _current.materials;
	        _currentMaterials[1] = Static;
            _tvOff = false;
            _tvStatic = true;
            YouSeeMore.SetActive(true);
	        _current.sharedMaterials = _currentMaterials;
        }

	    else if (TapeIn && !_tvSaw)
	    {
            _sounds.Stop();
	        _sounds.clip = tvClip;
	        _sounds.volume = 0.7f;
            _sounds.Play();
	        _sounds.loop = false;
            _currentMaterials = _current.materials;
            _currentMaterials[1] = Saw;
            _current.sharedMaterials = _currentMaterials;
            _tvOff = false;
            _tvSaw = true;
        }

	   else if (_tvSaw && _tvStatic && !_sounds.isPlaying )
	    {
            _currentMaterials = _current.materials;
            _currentMaterials[1] = TvOff;
            _current.sharedMaterials = _currentMaterials;
            DisplayTimer.SetActive(true);
            _tvOff = true;
            _tvStatic = false;
        }
	}
}
