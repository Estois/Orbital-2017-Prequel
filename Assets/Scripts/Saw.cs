using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
	AudioSource audio;

	float sawSpeed = 300f;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		audio.enabled = true;
		audio.Play ();
	}

	void Update ()
	{
		transform.Rotate (0, 0, sawSpeed * Time.deltaTime);
	}
}
