using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFader : MonoBehaviour {

    public Text text;
	public float wait = 0f;
    public float smooth = 1f;
	public bool pressToQuit = false;

	private bool activeFade = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (StartFade ());
	}
	
	// Update is called once per frame
	void Update () {
		if (activeFade) {

			text.color = Color.Lerp (text.color, new Color (1, 1, 1, 1), smooth);

			if(pressToQuit && Input.anyKeyDown){
				Application.Quit();
			}
		}
	}

	IEnumerator StartFade(){
		yield return new WaitForSeconds(wait);
		activeFade = true;
	}
}
