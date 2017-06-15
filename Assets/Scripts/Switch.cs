using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

	AudioManager audioManager;

	[SerializeField]
	GameObject switchOn;
	[SerializeField]
	GameObject switchOff;

	public bool isOn = false;

	void Start ()
	{
		audioManager = AudioManager.instance;
		//set the switch to off sprite
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOff.GetComponent<SpriteRenderer> ().sprite;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//set the switch to on sprite when triggered
		gameObject.GetComponent<SpriteRenderer> ().sprite = switchOn.GetComponent<SpriteRenderer> ().sprite;
		//set isOn to true when triggered
		isOn = true;

		audioManager.PlaySound ("SwitchSound");
	}
}
