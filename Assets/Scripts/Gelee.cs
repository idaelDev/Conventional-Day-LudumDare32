using UnityEngine;
using System.Collections;

public class Gelee : MonoBehaviour {

    Rigidbody2D rb;
    AudioSource audio;
    public bool temp = false;
    public float ttl = 15f;
    public float timer = 0f;

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        audio.mute = false;
        if(!GetComponent<Renderer>().isVisible)
        {
            audio.mute = true;
        }

        if (temp)
        {
            timer += Time.deltaTime;
            if (timer >= ttl)
            {
                timer = 0f;
                gameObject.SetActive(false);
            }
        }
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
