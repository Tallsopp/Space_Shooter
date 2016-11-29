using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
	public bool restart = false;
	//checks if it can Restart

	public Text restartText;
	//displays when the game can be restarted

	void Start () {
		restartText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//if the game can be restarted, press R to replay the current level
		if (restart == true) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}
}
