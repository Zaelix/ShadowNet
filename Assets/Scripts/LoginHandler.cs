using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("UserCollection")]
public class LoginHandler : MonoBehaviour {

    [XmlArray("Users")]
    [XmlArrayItem("User")]
    public List<User> users = new List<User>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Register()
    {

    }
}
