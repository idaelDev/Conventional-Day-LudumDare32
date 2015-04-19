using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int lifes = 3;
    public float timeToFreeze = 2f;
    Platformer2DUserControl puc;
    Gun gun;
    bool invincible;
    SpriteRenderer sr;
    public float clign = 0.1f;
    AudioSource audio;
    public AudioClip gameOverClip;
    public Camera cam;
    public SceneFadeInOut inout;
    Animator anim;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        puc = GetComponent<Platformer2DUserControl>();
        gun = GetComponentInChildren<Gun>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void LooseLife(bool freeze)
    {
        if (!invincible)
        {
            audio.pitch = 1 + Random.Range(-0.1f, 0.1f);
            audio.Play();
            if (freeze)
            {
                StartCoroutine(FreezeCorout());
            }
            else
            {
                lifes--;
                StartCoroutine(InvincibleCorout());
                StartCoroutine(Clignote());
            }
        }
    }

    void Update()
    {
        if (lifes <= 0)
            Dead();
    }

    public void Dead()
    {
        if(!audio.isPlaying)
        {
            audio.clip = gameOverClip;
            audio.Play();
        }
        puc.enabled = false;
        cam.GetComponent<Camera2DFollow>().enabled = false;
        cam.GetComponent<AudioSource>().Stop();
        inout.EndScene();
    }

    IEnumerator DeadCorout()
    {
        yield return new WaitForSeconds(2);
        inout.EndScene();
    }

    IEnumerator FreezeCorout()
    {
        anim.SetBool("Freeze", true);
        puc.enabled = false;
        gun.enabled = false;
        yield return new WaitForSeconds(timeToFreeze);
        puc.enabled = true;
        gun.enabled = true;
        anim.SetBool("Freeze", false);
        yield return 0;
    }

    IEnumerator InvincibleCorout()
    {
        invincible = true;
        yield return new WaitForSeconds(timeToFreeze);
        invincible = false;
        yield return 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            LooseLife(false);
        }
    }

    IEnumerator Clignote()
    {
        float timer = 0f;
        Color c = sr.color;
        while(timer < timeToFreeze)
        {
            sr.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(clign);
            sr.color = c;
            yield return new WaitForSeconds(clign);
            timer += 2 * clign;
        }
        yield return 0;
    }

}