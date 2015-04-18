using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int lifes = 3;
    public float timeToFreeze = 2f;
    Platformer2DUserControl puc;
    Gun gun;
    bool invincible;

    void Start()
    {
        puc = GetComponent<Platformer2DUserControl>();
        gun = GetComponentInChildren<Gun>();
    }

    public void LooseLife(bool freeze)
    {
        if (!invincible)
        {
            lifes--;
            if (lifes == 0)
                Dead();
            StartCoroutine(InvincibleCorout());
            if(freeze)
                StartCoroutine(FreezeCorout());
        }
    }

    void Dead()
    {
        puc.enabled = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator FreezeCorout()
    {
        puc.enabled = false;
        gun.enabled = false;
        yield return new WaitForSeconds(timeToFreeze);
        puc.enabled = true;
        gun.enabled = true;
        yield return 0;
    }

    IEnumerator InvincibleCorout()
    {
        invincible = true;
        yield return new WaitForSeconds(timeToFreeze);
        invincible = false;
        yield return 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            LooseLife(false);
        }
    }

}
