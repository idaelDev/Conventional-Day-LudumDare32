using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private bool activeExplosion = false;
    private AudioSource[] sounds;
    private AudioLowPassFilter passBas;
    private Image imgBlank;

	// Use this for initialization
	void Start () {
        sounds = GetComponents<AudioSource>();
        imgBlank = GetComponentInChildren<Image>();
        passBas = GetComponent<AudioLowPassFilter>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (activeExplosion)
        {
            passBas.enabled = true;
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Play();
            }

            imgBlank.color = new Color(imgBlank.color.r, imgBlank.color.g, imgBlank.color.b, 1.0f);
            activeExplosion = false;
            GetComponent<Collider2D>().enabled = false;
            //retirer le blanc + coupe-haut progressivement
        }
        imgBlank
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            activeExplosion = true;
        }

    }
}
