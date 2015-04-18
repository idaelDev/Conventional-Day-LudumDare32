using UnityEngine;
using System.Collections;

public class Enemy1Manager : MonoBehaviour {

    public float speed = 1;
    private Vector2 sizeSprite;
    public bool avoidHole = false;
    public GameObject gelee;
    private Rigidbody2D body;
    private float direction;
    private Collider2D trigger;

	// Use this for initialization
	void Awake () {
        sizeSprite = new Vector2(GetComponent<SpriteRenderer>().sprite.bounds.size.x,GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        body = GetComponent<Rigidbody2D>();

        trigger = GetComponentInChildren<Collider2D>();

        speed *= -1;
        transform.Rotate(0, 180, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(gameObject.GetComponent<Renderer>().isVisible)
            Move();
        
	}

    public void Freeze()
    {
        Instantiate(gelee, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Move()
    {
        if(avoidHole){
            Vector3 checkHoleLeft = new Vector3(transform.position.x - sizeSprite.x/2, transform.position.y, transform.position.z);
            Vector3 checkHoleRight =  new Vector3(transform.position.x + sizeSprite.x/2, transform.position.y, transform.position.z); 

            RaycastHit2D hit1 = Physics2D.Raycast(checkHoleLeft, -Vector2.up * 3);
            RaycastHit2D hit2 = Physics2D.Raycast(checkHoleRight, -Vector2.up * 3);

            if (hit1.collider == null || hit2.collider == null)
            {
                Reverse();
            }
                
        }


        body.velocity = new Vector2(speed, body.velocity.y);
    }

    void Reverse()
    {
        transform.Rotate(0, 180, 0);
        speed *= -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Enemy")
        {
            Reverse();
        }
        else if(other.gameObject.tag == "Projectile")
        {
            other.GetComponent<Projectile>().Despawn();
            Freeze();
        }
    }
}
