using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

	Animator anim;

	float maxHealth = 60;
	float currHealth;


	void Start ()
	{
		anim = gameObject.GetComponent<Animator> ();
		currHealth = maxHealth;

	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.tag == "Sword") {
			currHealth -= 5;
		}
	}

	void Update ()
	{
		if (currHealth <= 0) {
			anim.SetBool ("isDead", true);
		}
		Debug.Log ("Current Health: " + currHealth);
	}

}
