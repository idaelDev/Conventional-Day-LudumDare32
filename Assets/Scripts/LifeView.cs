using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeView : MonoBehaviour {

    public GameObject player;

    private int nbCoeur;
    private Image[] coeurs;

	// Use this for initialization
	void Start () {
        coeurs = GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        nbCoeur = player.GetComponent<PlayerLife>().lifes;

           for(int i=nbCoeur;i<coeurs.Length;i++){
               coeurs[i].enabled = false;
           }
	}
}
