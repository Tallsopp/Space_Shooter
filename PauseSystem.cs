using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour {

	public bool paused = false;
	//checks if the game is paused
	public Text pauseText;
	//displays when the game is paused

	void Start()
	{
		pauseText.text = "Press 'P' to Pause";
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P)) {
			paused = !paused;

			if (paused) {
				Time.timeScale = 0;
				pauseText.text = "Paused";
			} else {
				Time.timeScale = 1;
			}

			if (!paused) {
				Time.timeScale = 1;
				pauseText.text = "Press 'P' to Pause";
			}
		}
	}
}
