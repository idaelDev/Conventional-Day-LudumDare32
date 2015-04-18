using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject projectile;
    public int nbProjectile = 3;
    public PlatformerCharacter2D p2D;
    public float gunForce = 10f;
    private GameObject[] projectiles;

	// Use this for initialization
	void Start () {
	    projectiles = new GameObject[nbProjectile];
        for(int i=0; i<nbProjectile; i++)
        {
            projectiles[i] = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            projectiles[i].SetActive(false);
        }

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
        for(int i=0; i<nbProjectile; i++)
        {
            if(!projectiles[i].activeSelf)
            {
                projectiles[i].SetActive(true);
                projectiles[i].transform.position = transform.position;
                projectiles[i].GetComponent<Projectile>().right = p2D.FacingRight;
                break;
            }
        }
    }
}
