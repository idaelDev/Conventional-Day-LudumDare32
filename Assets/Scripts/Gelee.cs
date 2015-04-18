using UnityEngine;
using System.Collections;

public class Gelee : MonoBehaviour {

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
    {
        rb.isKinematic = true;
    }
}
