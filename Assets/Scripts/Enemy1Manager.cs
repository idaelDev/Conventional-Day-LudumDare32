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
    Animator anim;

	// Use this for initialization
	void Awake () {
        sizeSprite = new Vector2(GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.x, GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.y);
        body = GetComponent<Rigidbody2D>();

        trigger = GetComponentInChildren<Collider2D>();

        speed *= -1;
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("speed", speed);
        //transform.Rotate(0, 180, 0);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(gameObject.GetComponent<Renderer>().isVisible)
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
           Vector3 checkHole;

            if (speed < 0)
                checkHole = new Vector2(transform.position.x - sizeSprite.x/2, transform.position.y);
            else
                checkHole = new Vector2(transform.position.x + sizeSprite.x/2, transform.position.y);

            RaycastHit2D hit = Physics2D.Raycast(checkHole, -Vector2.up, 2);
            
            Debug.DrawRay(checkHole, -Vector2.up*2);
            
            if (hit.collider == null)
            {
                Debug.Log("test");
                Reverse();
            }
            else
            {
                Debug.Log(hit.collider.name + " " + hit.distance);
            }
                
        }

        body.velocity = new Vector2(speed, body.velocity.y);
    }

    void Reverse()
    {
        //transform.Rotate(0, 180, 0);
        speed *= -1;
        anim.SetFloat("speed", speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //if(transform.position.y - other.transform.position.y < 1 )
                Reverse();
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Gelee")
        {
            Reverse();
        }
        else if(other.gameObject.tag == "Projectile")
        {
            other.GetComponent<Projectile>().Despawn();
            Freeze();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //if(transform.position.y - other.transform.position.y < 1 )
            Reverse();
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Gelee")
        {
            Reverse();
        }

    }
}
