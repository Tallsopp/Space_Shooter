using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSystem : MonoBehaviour
{
	private BossSystem bS;
	//reference to BossSystem
	private GameController gC;
	//reference to GameController

	public GameObject hazard;
	//hazard objects to spawn
	public Vector3 hSpawnValues;
	//where hazards spawn
	public int hCount;
	//amount of hazards
	public float hSpawnWait;
	//time they spawn between one another
	public float hStartWait;
	//when the wave will start
	public float hWaveWait;
	//time between hazard waves

	public List<GameObject> enemies;
	//public GameObject[] enemies;
	//enemy objects to spawn
	public Vector3 eSpawnValues;
	//where enemies will spawn
	public int eCount;
	//amount of enemies
	public float eSpawnWait;
	//time they spawn between each other
	public float eStartWait;
	//when enemy wave begins
	public float eWaveWait;
	//time between enemy waves

	public Text wavesText;
	//displays what wave is active

	public float time;
	//timer for waves
	private float targetTime;
	//target for timer to reach
	public int waves;
	//number of waves the player faces

	public bool startWaves = false;
	//start the waves
	public bool display = false;
	//controls the text


	void Start ()
	{
		waves = 0;
		targetTime = 10f;
		wavesText.text = "";
		StartCoroutine (HazardSpawnWaves ());
		StartCoroutine (EnemySpawnWaves ());

		bS = GetComponent<BossSystem> ();
		gC = GetComponent<GameController> ();
	}

	void Update ()
	{
		if (startWaves) {
			Waves ();
		}

		if (display) {
			//displays the wave then stops displaying
			if (time <= 2f) {
				wavesText.text = "Wave " + waves + " Incoming!";
			} else {
				wavesText.text = "";
			}
		}
	}

	IEnumerator HazardSpawnWaves ()
	{ //wait for the hazards to spawn
		yield return new WaitForSeconds (hStartWait);
		while (true) { //when the spawn wait is over, start spawning
			for (int i = 0; i < hCount; i++) {
				Vector3 spawnPos = new Vector3 (hSpawnValues.x, Random.Range (-hSpawnValues.y, hSpawnValues.y), hSpawnValues.z);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (hazard, spawnPos, spawnRot); //spawn hazards at random positions
				yield return new WaitForSeconds (hSpawnWait);
				if (gC.gameOver) {
					break;
				}
			}
			yield return new WaitForSeconds (hWaveWait);
		}
	}

	IEnumerator EnemySpawnWaves ()
	{
		yield return new WaitForSeconds (eStartWait);
		while (true) {
			for (int i = 0; i < eCount; i++) {
				GameObject enemy = enemies [Random.Range (0, enemies.Count)];
				Vector3 spawnPos = new Vector3 (eSpawnValues.x, Random.Range (-eSpawnValues.y, eSpawnValues.y), eSpawnValues.z);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (enemy, spawnPos, spawnRot);
				yield return new WaitForSeconds (eSpawnWait);
			}
			yield return new WaitForSeconds (eWaveWait);
			if (gC.gameOver) {
				break;
			}
		}
	}

	void Waves ()
	{
		//every wave the value of variables changes
		if (waves == 1) {
			targetTime = 20f;
			hCount = 15;
			hSpawnWait = 1;
			hStartWait = 2;
			hWaveWait = 5;

			eCount = 12;
			eSpawnWait = 3;
			eStartWait = 2;
			eWaveWait = 5;
		}

		if (waves == 2) {
			targetTime = 40f;
			hCount = 25;
			hSpawnWait = 0.5f;
			hStartWait = 2;
			hWaveWait = 2;

			eCount = 20;
			eSpawnWait = 2;
			eStartWait = 1;
			eWaveWait = 5;
		}

		if (waves == 3) {
			targetTime = 80f;
			hCount = 30;
			hSpawnWait = 0.5f;
			hStartWait = 2;
			hWaveWait = 1;

			eCount = 25;
			eSpawnWait = 1;
			eStartWait = 1;
			eWaveWait = 2;
		}

		//if past the first three waves no more enemies just the boss wave
		if (waves >= 4) {
			hCount = 0;
			eCount = 0;
			time = 0;
			wavesText.text = "";
			startWaves = false;
			display = false;
			bS.spawnBoss = true;
		}

		time += 1f * Time.deltaTime;
		if (time >= targetTime) {
			waves += 1;
			time = 0;
		}
	}
}
