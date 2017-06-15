using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
	public AudioManager audioManager;

	float sawSpeed = 300f;

	void Start ()
	{
		audioManager = AudioManager.instance;
		playSawSound ();
	}

	void Update ()
	{
		transform.Rotate (0, 0, sawSpeed * Time.deltaTime);
	}

	public void playSawSound ()
	{
		audioManager.PlaySound ("SawSound");
	}
}
