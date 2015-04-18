using UnityEngine;
using System.Collections;

public class Gelee : MonoBehaviour {

    Rigidbody2D rb;
    AudioSource audio;

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (!audio.isPlaying)
        {
            audio.pitch = 1 + Random.Range(-0.1f, 0.1f);
            audio.Play();
        }
        rb.isKinematic = true;
    }
}
