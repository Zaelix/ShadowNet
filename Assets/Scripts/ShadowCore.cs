using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowCore : MonoBehaviour {
    public Canvas canvas;
    private bool isMusicEnabled = true;
    private AudioSource aSource;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        //aSource.mute = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isMusicEnabled)
        {
            //aSource.mute = false;
        }
        else
        {
            //aSource.mute = true;
        }
    }

    private void ToggleMusic()
    {
        isMusicEnabled = canvas.GetComponentInChildren<Toggle>().isOn;
    }
}
