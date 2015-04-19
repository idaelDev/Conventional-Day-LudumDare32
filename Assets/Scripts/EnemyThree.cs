using UnityEngine;
using System.Collections;

public class EnemyThree : MonoBehaviour {

    public GameObject gelee;
    private Rigidbody2D body;
    private Collider2D trigger;
    private GameObject player;

    public GameObject pierre;
    public float speedAttack;

	// Use this for initialization
	void Awake () {
        body = GetComponent<Rigidbody2D>();
        trigger = GetComponentInChildren<Collider2D>();

        player = GameObject.Find("Player");
        if (player == null)
            Debug.LogError("Le joueur doit s'appeller 'Player' !");

        StartCoroutine(Shoot());

        //transform.Rotate(0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedAttack);
            if (gameObject.GetComponent<Renderer>().isVisible)
            {
                Vector3 directionPierre = player.transform.position - transform.position;
                directionPierre.Normalize();

                GameObject petitePierre = (GameObject)GameObject.Instantiate(pierre, transform.position, Quaternion.identity);
                petitePierre.GetComponent<Pierre>().SetDirection(directionPierre);
            }
        }
    }

    public void Freeze()
    {
        Instantiate(gelee, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            other.GetComponent<Projectile>().Despawn();
            Freeze();
        }
    }
}
