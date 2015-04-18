using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public int lifes = 3;
    public float timeToFreeze = 2f;
    Platformer2DUserControl puc;
    Gun gun;

    void Start()
    {
        puc = GetComponent<Platformer2DUserControl>();
        gun = GetComponentInChildren<Gun>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            LooseLife();
    }

    public void LooseLife()
    {
        StartCoroutine(Freeze());
        lifes--;
        if (lifes == 0)
            Dead();
    }

    void Dead()
    {
        puc.enabled = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator Freeze()
    {
        puc.enabled = false;
        gun.enabled = false;
        yield return new WaitForSeconds(timeToFreeze);
        puc.enabled = true;
        gun.enabled = true;
        yield return 0;
    }

}
