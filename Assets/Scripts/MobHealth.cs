using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour {

    Animator anim;

    public float maxHealth;
    public float playerDamage;

    private float currHealth;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        currHealth = maxHealth;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
            currHealth -= playerDamage;
    }

    // Update is called once per frame
    void Update () {
        if (currHealth <= 0)
          anim.SetBool("isDead", true);
    }
}
