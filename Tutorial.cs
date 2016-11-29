using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	private GameController gameController;
	private WaveSystem waveSystem;

	private int tutorialCount;
	//checks the progression of the tutorial
	public Text tutorialText;
	//displays the tutorial text, quick guide for the player
	private float timer;
	//amount of time

	void Start () {
		timer = 3;

		waveSystem = GetComponent<WaveSystem> ();
		gameController = GetComponent<GameController> ();

		tutorialText.text = "";
		tutorialCount = 0;
		StartCoroutine (TutorialWait ());
	}
	
	void Update () {
		//start of the tutorial
		if (tutorialCount == 1) {
			tutorialText.text = "Press Any Key";

			if (Input.anyKeyDown) {
				// adds one to the tutorial counter
				gameController.spawn = true;
				gameController.showUI = true;
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
		}

		//movement tutorial
		if (tutorialCount == 3) {
			tutorialText.text = "Press WASD to Move";
			if (Input.GetKeyDown (KeyCode.W)) {
				// adds one to the tutorial counter
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				// adds one to the tutorial counter
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				// adds one to the tutorial counter
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				// adds one to the tutorial counter
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
		}

		//shooting tutorial
		if (tutorialCount == 5) {
			tutorialText.text = "Press 'Spacebar' to Shoot!";
			if (Input.GetKey (KeyCode.Space)) {
				// adds one to the tutorial counter
				StartCoroutine (TutorialWait ());
				tutorialCount++;
			}
		}

		if (tutorialCount == 7) {
			waveSystem.display = true;
			waveSystem.startWaves = true;
			waveSystem.waves++;
			tutorialCount++;
		}

		if (tutorialCount >= 8) {
			StopAllCoroutines ();
		}
	}

	IEnumerator TutorialWait ()
	{ //waits for certain amount of time
		tutorialText.text = "";
		yield return new WaitForSeconds (timer);
		// adds one to the tutorial counter
		tutorialCount ++;
		}
	}
