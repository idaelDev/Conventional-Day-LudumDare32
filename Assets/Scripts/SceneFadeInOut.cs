using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;
	private bool sceneStarting = true;
	private Image image;


	void Awake()
	{
		image = gameObject.GetComponent<Image>();
		image.color = Color.black;
	}

	void Update()
	{
		if(sceneStarting)
		{
			StartScene();
		}
	}

	void FadeToClear()
	{
		image.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	public void FadeToBlack()
	{
		image.color = Color.Lerp(image.color, Color.black, fadeSpeed * Time.deltaTime);
	}

	void StartScene()
	{
		FadeToClear();
		if(image.color.a <= 0.05f)
		{
			image.color = Color.clear;
			image.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene ()
	{
		// Make sure the texture is enabled.
		image.enabled = true;
		
		// Start fading towards black.
		FadeToBlack();
		
		// If the screen is almost black...
		if(image.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel(1);
	}

}
