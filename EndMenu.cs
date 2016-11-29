using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {

	private GameController gC;
	private bool paused;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gC = gameControllerObject.GetComponent<GameController> ();
		}
	}

	public void ReturnMainMenu ()
	{
		SceneManager.LoadScene ("Main Menu");
	}

	public void HighScore(){
		SceneManager.LoadScene ("High Score");
	}

	public void RestartScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void PauseGame()
	{
		//if clicked then either pause or unpause depending on its current state
		paused = !paused;

		if (paused) {
			//time stops
			Time.timeScale = 0;
			gC.mainMenuButton.SetActive (true);
		} else {
			Time.timeScale = 1;
		}

		if (!paused) {
			gC.mainMenuButton.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
