using UnityEngine;
using System.Collections;

public class Pierre : MonoBehaviour {

    private Vector3 direction = Vector3.zero;
    public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed);
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
	}

    public void SetDirection(Vector3 direction){
        this.direction = direction;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerLife>().LooseLife(false);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
