using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

	AudioSource audio;

	[SerializeField]
	GameObject switchOn;
	[SerializeField]
	GameObject switchOff;

	public bool isOn = false;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		audio.enabled = false;
		//set the switch to off sprite
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff.GetComponent<SpriteRenderer> ().sprite;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//set the switch to on sprite when triggered
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn.GetComponent<SpriteRenderer> ().sprite;
		//set isOn to true when triggered
		isOn = true;

		audio.enabled = true;
		audio.Play ();
	}
}
