using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
	//name of sorting layer
	public string sortLayerName;

	void Start ()
	{
		//get each of the sprite that are a child of the game object that the script is attached to
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
			//set those sprites sorting layer names to the one we have specified
			sr.GetComponent<Renderer> ().sortingLayerName = sortLayerName;
		}
	}
}
