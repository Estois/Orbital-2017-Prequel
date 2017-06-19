using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public void StartGame ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void ExitGame ()
	{
		Debug.Log ("QUIT");
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit ();
	}

}
