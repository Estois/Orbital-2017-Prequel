using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public int currentLevel;
	public int loadedData;

	void Start ()
	{
		currentLevel = SceneManager.GetActiveScene ().buildIndex;
	}

	public void Save ()
	{
		SaveLoadManager.Save (this);
	}

	public void Load ()
	{
		loadedData = SaveLoadManager.Load ();

		SceneManager.LoadScene (loadedData);
	}

}
