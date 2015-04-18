using UnityEngine;
using System.Collections;

public class Enemy1Manager : MonoBehaviour {

    public float speed = 2;
    public float gravity = 10;

    private bool goToLeft = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = Vector2.zero;
        if (goToLeft)
        {
            direction.x = -1;
        }
        else
            direction.x = 1;

        direction.x *= speed;

        transform.Translate(direction);
	}
}
