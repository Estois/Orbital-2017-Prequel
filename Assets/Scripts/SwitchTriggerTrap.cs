using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggerTrap : MonoBehaviour
{

	AudioSource audioSource;

	public GameObject[] spike;

	[SerializeField]
	GameObject switchOn;
	[SerializeField]
	GameObject switchOff;

	public bool isOn = false;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.enabled = false;
		//set the switch to off sprite
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff.GetComponent<SpriteRenderer> ().sprite;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//set the switch to on sprite when triggered
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn.GetComponent<SpriteRenderer> ().sprite;
		//set isOn to true when triggered
		isOn = true;

		audioSource.enabled = true;
		audioSource.Play ();

		spike = GameObject.FindGameObjectsWithTag ("MovingSpike");
		for (int i = 0; i < spike.Length; i++) {
			spike [i].gameObject.SetActive (true);
		}

	}
}
