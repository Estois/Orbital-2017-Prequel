using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

	public static bool Attacking = false;

	private float attackTimer = 0;
	public float attackCd = 1f;


	public Collider2D attackTrigger;

	private Animator anim;

	void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update ()
	{
		if (Input.GetKey ("z") && !Attacking) {
			Attacking = true;
			attackTimer = attackCd;
			attackTrigger.enabled = true;
		}

		if (Attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				Attacking = false;
				attackTrigger.enabled = false;
			}
		}
	
		anim.SetBool ("Attacking", Attacking);
	}
}
