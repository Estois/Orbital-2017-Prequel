﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	
	public Slider healthBar;
	public Text healthText;
	public GameObject DeathUI;
	public GameObject Switches;

	Animator anim;

	public float maxHealth = 100.0f;
	public float currHealth;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		healthBar.value = maxHealth;
		currHealth = healthBar.value;
	}

	void OnTriggerStay2D (Collider2D col)
	{

		/*if (col.gameObject.tag == "acid") {
			healthBar.value -= 0.2f;
			currHealth = healthBar.value;
		}

		if (col.gameObject.tag == "spike") {
			healthBar.value -= 100.0f;
			currHealth = healthBar.value;
		}

		if (col.gameObject.tag == "HealthBonus") {
			healthBar.value += 15.0f;
			currHealth = healthBar.value;
			Destroy (col.gameObject);
		}*/

	}

	void OnCollisionStay2D (Collision2D col)
	{
		/*if (col.gameObject.tag == "saw") {
			healthBar.value -= 1.0f;
			currHealth = healthBar.value;
		}

		if (col.gameObject.tag == "Zombie") {
			healthBar.value -= 2.0f;
			currHealth = healthBar.value;
		}*/
	}

	void Update ()
	{
		healthText.text = currHealth.ToString ("n0") + " %";

		if (currHealth <= 0) {
			//death animation activated
			anim.SetBool ("isDead", true);
			//stop all player movement
			GetComponent<PlayerController> ().enabled = false;
			//enable deathUI
			DeathUI.gameObject.SetActive (true);
			Switches.gameObject.SetActive (false);
		}
		Debug.Log ("Current Health: " + currHealth);
	}
}
