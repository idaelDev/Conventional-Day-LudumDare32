using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    public Text text;
    public float smooth = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.color = Color.Lerp(text.color, new Color(1,1,1,1), smooth);
	}
}
