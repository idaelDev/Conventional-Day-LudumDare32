using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {


    public PlatformerCharacter2D p2D;
    public float gunForce = 10f;
    public ProjectilePool pool;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	   if(Input.GetButtonDown("Fire1"))
       {
           Fire();
       }
	}

    void Fire()
    {
        GameObject o = pool.GetProjectile();
        if(o != null)
        {
            o.transform.position = transform.position;
            o.GetComponent<Projectile>().right = p2D.FacingRight;
            o.GetComponent<Projectile>().pool = pool;
        }
    }
}
