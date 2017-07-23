using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    Animator anim;

    public float maxHealth;
    public float playerDamage;

    private float currHealth;
    private bool once = true;

    public float minSize;

    public GameObject zombiePrefab;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        currHealth = maxHealth;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
            currHealth -= playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            anim.SetBool("isDead", true);
            gameObject.tag = null;
            /*if (once && transform.localScale.y > minSize)
            {
                GameObject zombie1 = Instantiate(zombiePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
                GameObject zombie2 = Instantiate(zombiePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

                zombie1.GetComponent<BossHealth>().currHealth = 40;
                zombie1.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.x * 0.5f, transform.localScale.z);
                zombie2.GetComponent<BossHealth>().currHealth = 40;
                zombie2.transform.localScale = new Vector3(transform.localScale.y * 0.5f, transform.localScale.x * 0.5f, transform.localScale.z);
                once = false;
            }*/
            return;
        }
    }
}
