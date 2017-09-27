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
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void ToggleMusic()
    {
        isMusicEnabled = canvas.GetComponentInChildren<Toggle>().isOn;
    }
}
