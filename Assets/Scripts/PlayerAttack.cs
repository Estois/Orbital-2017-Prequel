using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

	private bool Attacking = false;

	private float attackTimer = 0;
	private float attackCd = 1.0f;


	public Collider2D attackTrigger;

	private Animator anim;

	void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && !Attacking) {
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
