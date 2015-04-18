using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas cvsControls;
    public Canvas cvsMain;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    public void Play()
    {
        Application.LoadLevel(1);
    }

    public void Controls()
    {
        cvsMain.enabled = false;
        cvsControls.enabled = true;
    }

    public void ReturnControls()
    {
        cvsControls.enabled = false;
        cvsMain.enabled = true;
    }

    //*
    public void Quit()
    {
        Application.Quit();
    }
     //*/
}
