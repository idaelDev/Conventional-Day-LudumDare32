using UnityEngine;
using System.Collections;

public class Enemy1Manager : MonoBehaviour {

    public float speed = 1;
    private Vector2 sizeSprite;
    public bool avoidHole = false;

    private Rigidbody2D body;
    private float direction;
    private Collider2D trigger;
    private bool goLeft;

	// Use this for initialization
	void Awake () {
        sizeSprite = new Vector2(GetComponent<SpriteRenderer>().sprite.bounds.size.x,GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        body = GetComponent<Rigidbody2D>();

        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach(Collider2D coll in colliders){
            if(coll.isTrigger)
                trigger = coll;
        }

        speed *= -1;
        transform.Rotate(0, 180, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        
	}

    void Freeze()
    {
        speed = 0;
        trigger.enabled = false;
    }

    void Move()
    {
        body.velocity = new Vector2(speed, body.velocity.y);


        if(avoidHole){
            Vector3 checkHole;

            if (speed < 0)
                checkHole = new Vector3(transform.position.x - sizeSprite.x, transform.position.y, transform.position.z);
            else
                checkHole = new Vector3(transform.position.x + sizeSprite.x, transform.position.y, transform.position.z);

            RaycastHit2D hit = Physics2D.Raycast(checkHole, -Vector2.up * 3);

            if (hit.collider == null)
            {
                Reverse();
            }
                
        }
    }

    void Reverse()
    {
        transform.Rotate(0, 180, 0);
        speed *= -1;

        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Reverse();
        }
    }
}
