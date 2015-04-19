using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    Image t;
    public float smooth = 0.1f;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<Image>();
    }

    void Update()
    {
        t.color = Color.Lerp(t.color, new Color(0, 0, 0, 0), smooth); 
    }
}
