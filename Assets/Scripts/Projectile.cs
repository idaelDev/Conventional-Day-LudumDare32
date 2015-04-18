using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 5f;
    public ProjectilePool pool;
    public float ttl = 2f;
    public bool right = true;

    private Rigidbody2D rigidbody;
    private float timer = 0f;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ttl)
        {
            ToGelee();
        }
    }

	// Update is called once per frame
	void FixedUpdate () {

        Vector3 direction = new Vector3(speed, 0, 0) * Time.deltaTime;
        if (!right)
            direction *= -1;
        rigidbody.MovePosition(transform.position + direction);
	}

    void ToGelee()
    {
        GameObject o = pool.GetGelee();
        o.GetComponent<AudioSource>().Play();
        o.transform.position = transform.position;
        Despawn();
    }

    public void Despawn()
    {
        timer = 0f;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Gelee")
        {
            right = !right;
        }
        else if (other.gameObject.tag == "Player")
        {
            Despawn();
            other.GetComponent<PlayerLife>().LooseLife(true);
        }
        else if(other.gameObject.tag == "Wall")
        {
            ToGelee();
        }
    }
}
