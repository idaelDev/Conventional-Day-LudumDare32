using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private bool activeExplosion = false;
    private AudioSource[] sounds;
    private AudioLowPassFilter passBas;
    private Image[] imgs;
    private float calm;
    public float beforeCalm = 8;
    public AudioSource music;
    public float timeToWait = 10f;
    public GameObject player;

    public GameObject corpse;
    private Image fumee;
    private Image imgBlank;

	// Use this for initialization
	void Start () {
        sounds = GetComponents<AudioSource>();
        imgs = GetComponentsInChildren<Image>();

        for (int i = 0; i < imgs.Length; i++)
        {
            if (imgs[i].name == "Fumee")
                fumee = imgs[i];
            else if (imgs[i].name == "Blanc")
                imgBlank = imgs[i];
        }

        passBas = GetComponent<AudioLowPassFilter>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (activeExplosion)
        {
            StartCoroutine(LoadEnd());
            passBas.enabled = true;
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Play();
            }

            imgBlank.color = new Color(imgBlank.color.r, imgBlank.color.g, imgBlank.color.b, 1.0f);
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            corpse.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            SpriteRenderer[] cadavre = corpse.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteCadavre in cadavre)
            {
                spriteCadavre.enabled = true;
            }
            fumee.enabled = true;
            player.GetComponent<Platformer2DUserControl>().enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponentInChildren<Gun>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(TempestBeforeCalm());
           
            activeExplosion = false;
        }
        

        if (calm > Time.time)
        {
            float alpha = Mathf.Lerp(0.0f,1.0f,(calm - Time.time) / beforeCalm);
            float coupeHaut = Mathf.Lerp(3000, 1000, (calm - Time.time) / beforeCalm);
            Debug.Log(coupeHaut);
            //retirer le blanc + coupe-haut progressivement


            imgBlank.color = new Color(imgBlank.color.r, imgBlank.color.g, imgBlank.color.b, alpha);
            passBas.cutoffFrequency = coupeHaut;
        }

	}

    IEnumerator TempestBeforeCalm(){
        yield return new WaitForSeconds(2f);
        calm = Time.time + beforeCalm;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            music.Stop();
            activeExplosion = true;
        }

    }

    IEnumerator LoadEnd()
    {
        yield return new WaitForSeconds(timeToWait);
        Application.LoadLevel(2);
    }
}
