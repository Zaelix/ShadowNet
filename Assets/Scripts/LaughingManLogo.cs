﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingManLogo : MonoBehaviour {
    public Transform text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.transform.Rotate(new Vector3(0, 0, 0.3f));
	}
}
