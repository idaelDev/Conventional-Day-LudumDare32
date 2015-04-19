using UnityEngine;
using System.Collections;

public class ColliderParameter : MonoBehaviour
{
    public PhysicsMaterial2D mat;

    // Use this for initialization
    void Start()
    {
        GameObject[] box = GameObject.FindGameObjectsWithTag("Wall");
        for(int i=0; i< box.Length; i++)
        {
            BoxCollider2D b = box[i].GetComponent<BoxCollider2D>();
            if(b != null)
            {
                b.sharedMaterial = mat;
            }
        }
    }
}
