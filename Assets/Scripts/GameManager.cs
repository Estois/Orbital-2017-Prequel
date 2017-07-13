using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	GameObject[] switches;
	[SerializeField]
	GameObject exitDoor;

	int noOfSwitches = 0;
	[SerializeField]
	Text switchCount;

	public static GameManager instance;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void LoadLastSave (int x)
	{
		SceneManager.LoadScene (x);
	}

	public int GetCurrentLevel ()
	{
		return SceneManager.GetActiveScene ().buildIndex;
	}

	void Start ()
	{
		GetNoOfSwitches ();
	}

	public void LoadNextLevel (int x)
	{
		SceneManager.LoadScene (x);
	}

	public int GetNoOfSwitches ()
	{
		int x = 0;

		for (int i = 0; i < switches.Length; i++) {
			if (switches [i].GetComponent<Switch> ().isOn == false) {
				x++;
			} else if (switches [i].GetComponent<Switch> ().isOn == true) {
				noOfSwitches--;
			}
		}
		noOfSwitches = x;

		return noOfSwitches;
	}

	public void GetExitDoorState ()
	{
		if (noOfSwitches <= 0) {
			exitDoor.GetComponent<Door> ().SetDoorState (3);
		}
	}

	void Update ()
	{
		switchCount.text = GetNoOfSwitches ().ToString ();
		GetExitDoorState ();
	}

}
