using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{

	public AudioSource source;
	public AudioClip hover;


	public void OnMouseOver ()
	{
		source.PlayOneShot (hover);
	}
		
}
