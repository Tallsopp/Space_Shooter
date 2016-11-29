using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private WaveSystem wS;
	//reference of the wave system

	public bool gameOver = false;
	//checks if the game is over
	public bool victory = false;
	//checks if player has won
	public bool spawn = false;
	//checks if player can spawn
	public bool showUI = false;
	//checks if it can show all of the UI

	public int health;
	//player's health
	public int lives;
	//player's lives
	public int score;
	//player's score

	public GameObject playerObject;
	//the actual player object
	public GameObject playerExplosion;
	public MeshRenderer playRen;
	//renderer of the player
	private Collider playerCol;
	//player's collider

	public Transform playerSpawn;
	//player's spawn

	public Text healthText;
	//displays the health
	public Text livesText;
	//displays the lives
	public Text scoreText;
	//displays the score
	public Text winText;
	//dispalys win the player wins
	public Text gameOverText;
	//displays when the game is over
	public Text rofText;
	//rate of fire text
	public Text bombText;
	//bomb text

	public GameObject restartButton;
	//restart button
	public GameObject pauseButton;
	//pause button
	public GameObject mainMenuButton;
	//button to the main menu
	public GameObject highScoreButton;
	//button for highscore

	void Awake ()
	{
		lives = 3;
		health = 100;
		score = 0;
		gameOverText.text = "";
		winText.text = "";
		healthText.text = "";
		scoreText.text = "";
		livesText.text = "";
		rofText.text = "";
		bombText.text = "";

		restartButton.SetActive (false);
		pauseButton.SetActive (false);
		mainMenuButton.SetActive(false);
		highScoreButton.SetActive (false);

		GameObject playerController = GameObject.FindWithTag ("Player");
		if (playerController != null) {
			playRen = GetComponent<MeshRenderer> ();
		}

		playerCol = playerObject.GetComponent<Collider> ();
		wS = GetComponent<WaveSystem> ();
	}

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update ()
	{
		if (showUI) {
			healthText.text = "Health: " + health;
			livesText.text = "Lives: " + lives;
			scoreText.text = "Score: " + score;
			restartButton.SetActive (true);
			pauseButton.SetActive (true);
		}

		AreYouAlive ();

		if (spawn) {
			playerObject.SetActive (true);
			spawn = false;
		}

		if (victory)
			StartCoroutine (Victory ());
	}


	public void AddScore (int newScoreValue)
	{ //if score is increased, change the value and update the text
		score += newScoreValue;
	}

	public void UpdateHealthandLives (int newDamage)
	{
		health -= newDamage;
	}

	void AreYouAlive ()
	{
		//if player died lose one life and reset position
		if (health <= 0) {
			if (lives > 1) {
				Died ();
				playerObject.gameObject.transform.position = playerSpawn.transform.position;
			}
		}

		//if dead health and lives equal 0 and game over screen appears
		if (lives <= 0) {
			lives = 0;
			health = 0;
			StartCoroutine(GameOver ());
			playerObject.SetActive (false);
			wS.startWaves = false;
		}
	}

	void Died ()
	{
		health = 100;
		lives -= 1;
		Instantiate (playerExplosion, transform.position, transform.rotation);
		//set collider and renderer to false
		playerCol.enabled = false;
		playRen.enabled = false;
		StartCoroutine (EnableCollider ());
		StartCoroutine (Blink ());
	}

	IEnumerator Blink()
	{
		while (true) {
			//flashes object on and off
			playRen.enabled = false;
			yield return new WaitForSeconds (0.2f);
			playRen.enabled = true;
			yield return new WaitForSeconds (0.2f);
		}
	}

	IEnumerator EnableCollider ()
	{
		playerObject.SetActive (true);
		yield return new WaitForSeconds (3f);
		playerCol.enabled = true;
		playRen.enabled = true;
		StopAllCoroutines ();
	}

	IEnumerator GameOver ()
	{ //if the game is over, tell the player
		playerObject.SetActive (false);
		gameOverText.text = "Game Over!";
		gameOver = true;
		yield return new WaitForSeconds (2f);
		mainMenuButton.SetActive(true);
	}

	IEnumerator Victory ()
	{
		//if player has won wait then enable winning screen
		gameOver = true;
		winText.text = "You've Won!";
		yield return new WaitForSeconds (2f);
		highScoreButton.SetActive (true);
	}
}

public class FinalScore
{
	static public int finalScore;
}