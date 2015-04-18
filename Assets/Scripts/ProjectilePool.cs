using UnityEngine;
using System.Collections;

public class ProjectilePool : MonoBehaviour {

    public GameObject projectile;
    public int nbProjectile = 3;
    private GameObject[] projectiles;

    public GameObject gelee;
    public int nbGelee = 3;
    private GameObject[] gelees;
    private int geleeCount = 0;

	// Use this for initialization
	void Start () {
        projectiles = new GameObject[nbProjectile];
        for (int i = 0; i < nbProjectile; i++)
        {
            projectiles[i] = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            projectiles[i].SetActive(false);
        }
        gelees = new GameObject[nbGelee];
        for (int i = 0; i < nbGelee; i++)
        {
            gelees[i] = Instantiate(gelee, transform.position, Quaternion.identity) as GameObject;
            gelees[i].SetActive(false);
        }
	}

    public GameObject GetProjectile()
    {
        for (int i = 0; i < nbProjectile; i++)
        {
            if (!projectiles[i].activeSelf)
            {
                projectiles[i].SetActive(true);
                return projectiles[i];
            }
        }
        return null;
    }

    public GameObject GetGelee()
    {
        geleeCount++;
        if (geleeCount >= nbGelee)
            geleeCount = 0;
        gelees[geleeCount].SetActive(true);
        gelees[geleeCount].GetComponent<Rigidbody2D>().isKinematic = false;
        return gelees[geleeCount];
    }

}
