using UnityEngine;
using System.Collections;

public class PowerUpContact : MonoBehaviour {
	
	private GameController gameController;	//reference to GameController
	private WaveSystem waveSystem;	//reference to WaveSystem

	public bool activeShield = false;	//checks if the player can activate the shield
	public bool smartBomb = false;	//checks if the player can activate the smart bomb

	public GameObject shieldObj;	//shield of the player

	private float timer;

	void Start () {
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			waveSystem = gameControllerObject.GetComponent<WaveSystem> ();
		}

	}
	
	void Update () {
		Shield ();
		SmartBomb ();
	}

	void Shield ()
	{
		if (activeShield == false) {
			shieldObj.SetActive (false);
		}

		if (activeShield == true) {
			timer += 1f * Time.deltaTime;
			shieldObj.SetActive (true);
			if (timer >= 10f) {
				activeShield = false;
				timer = 0f;
			}
		}
	}

	void SmartBomb ()
	{
		if (smartBomb == true) {
			if (Input.GetKey (KeyCode.U)) {
				foreach (GameObject lookForEnemies in waveSystem.enemies) {
					Destroy (lookForEnemies);
				}
				smartBomb = false;
			}
		}
	}
}
