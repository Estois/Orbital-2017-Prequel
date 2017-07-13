using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
	AudioSource audioSource;

	float sawSpeed = 300f;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.enabled = true;
		audioSource.Play ();
	}

	void Update ()
	{
		transform.Rotate (0, 0, sawSpeed * Time.deltaTime);
	}
}
