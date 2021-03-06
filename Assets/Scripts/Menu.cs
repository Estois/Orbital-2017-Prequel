﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public static Menu menu;

	[SerializeField]
	GameObject PauseWindow;
	[SerializeField]
	GameObject OptionsWindow;
	[SerializeField]
	GameObject HelpWindow;
	[SerializeField]
	GameObject MenuUI;

	enum MenuStates
	{
		Playing,
		Pause,
		Options,
		Help
	}

	[SerializeField]
	MenuStates currentState;

	void Start ()
	{
		currentState = MenuStates.Playing;
	}

	void Update ()
	{

		if (Input.GetKeyDown ("escape") && currentState == MenuStates.Pause) {
			currentState = MenuStates.Playing;
		} else if (Input.GetKeyDown ("escape") && currentState == MenuStates.Playing) {
			currentState = MenuStates.Pause;
		}

		switch (currentState) {
		case MenuStates.Playing:
			currentState = MenuStates.Playing;
			PauseWindow.SetActive (false);
			OptionsWindow.SetActive (false);
			HelpWindow.SetActive (false);
			MenuUI.SetActive (false);
			Time.timeScale = 1f;
			break;

		case MenuStates.Pause:
			PauseWindow.SetActive (true);
			OptionsWindow.SetActive (false);
			HelpWindow.SetActive (false);
			MenuUI.SetActive (true);
			Time.timeScale = 0;
			break;

		case MenuStates.Options:
			PauseWindow.SetActive (false);
			OptionsWindow.SetActive (true);
			HelpWindow.SetActive (false);
			MenuUI.SetActive (true);
			Time.timeScale = 0;
			break;

		case MenuStates.Help:
			PauseWindow.SetActive (false);
			OptionsWindow.SetActive (false);
			HelpWindow.SetActive (true);
			MenuUI.SetActive (true);
			Time.timeScale = 0;
			break;
		}
	}


	public void Restart ()
	{

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}

	public void DisplayOptions ()
	{

		currentState = MenuStates.Options;

	}

	public void DisplayHelp ()
	{

		currentState = MenuStates.Help;

	}

	public void Resume ()
	{

		currentState = MenuStates.Playing;

	}

	public void Exit ()
	{

//		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();

	}

	public void BackButton ()
	{

		currentState = MenuStates.Pause;

	}

	public void MainMenuButton ()
	{
		SceneManager.LoadScene (0);
	}
		
}
