using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
	AudioManager audioManager;

	float sawSpeed = 300f;

	void Start ()
	{
		audioManager = AudioManager.instance;
		audioManager.PlaySound ("SawSound");
	}

	void Update ()
	{
		transform.Rotate (0, 0, sawSpeed * Time.deltaTime);
	}
}
