using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShadowCore : MonoBehaviour {
    public Canvas canvas;
    private bool isMusicEnabled = true;
    private AudioSource aSource;
    private GameObject[] panels;
    private GameObject[] buttons;

    public GameObject lmi;
    public GameObject loginMessageObj;
    public GameObject usernameInput;
    public GameObject passInput;

    string username;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
        panels = GameObject.FindGameObjectsWithTag("Panels");
        buttons = GameObject.FindGameObjectsWithTag("Buttons");

        // Hides panels and enables the login page
        HidePanels();
        HideButtons();
        ShowPanel("LoginPanel");
        lmi.GetComponent<LaughingManLogo>().MoveTo(new Vector3(0, 0, 90), 4f);
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void ToggleMusic()
    {
        isMusicEnabled = canvas.GetComponentInChildren<Toggle>().isOn;
    }

    private void HidePanels()
    {
        foreach (GameObject obj in panels)
        {
            obj.SetActive(false);
        }
    }

    private void HideButtons()
    {
        foreach (GameObject obj in buttons)
        {
            obj.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        foreach (GameObject obj in buttons)
        {
            obj.SetActive(true);
        }
    }

    public void ShowPanel(string panelName)
    {
        HidePanels();
        foreach (GameObject obj in panels)
        {
            if(obj.name == panelName)
            {
                obj.SetActive(true);
            }
        }
    }
    
    public void AttemptLogin()
    {
        if (usernameInput.GetComponent<InputField>().text != "" && passInput.GetComponent<InputField>().text != "")
        {
            username = usernameInput.GetComponent<InputField>().text;
            HidePanels();
            ShowButtons();
            lmi.GetComponent<LaughingManLogo>().MoveTo(new Vector3(-19, 10, 0), 1f);
        }
        else
        {
            loginMessageObj.GetComponent<Text>().text = "Invalid Login/Pass";
        }
    }
}
