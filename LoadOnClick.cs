using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour
{
	public Text finalScoreDisp;
	private int playerFinalScore;

	void Update()
	{
		playerFinalScore = FinalScore.finalScore;
		finalScoreDisp.text = "Score: " + playerFinalScore;
	}

	public void LoadScene (int level)
	{
		if (level == 1)
			SceneManager.LoadScene ("Level 1");

		if (level == 2)
			SceneManager.LoadScene ("High Score");

		if (level == 3)
			Application.Quit ();
	}

	public void ReturnMainMenu ()
	{
		SceneManager.LoadScene ("Main Menu");
	}
}