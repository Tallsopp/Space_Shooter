using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawmSystem : MonoBehaviour
{
	private WaveSystem wS;
	//reference to WaveSytem

	public List<GameObject> powerUps;

	public Vector3 spawnValues;
	//where enemies will spawn
	public int pCount;
	//amount of enemies
	public float spawnWait;
	//time they spawn between each other
	public float startWait;
	//when enemy wave begins
	public float waveWait;
	//time between enemy waves
	private float time;
	//timer for waves
	public float targetTime;
	//target for timer to reach
	public bool spawn = false;
	//if true spawn the power ups

	void Awake ()
	{
		wS = GetComponent<WaveSystem> ();
	}

	void Update ()
	{
		GameObject power = powerUps [Random.Range (0, powerUps.Count)];
		Vector3 spawnPos = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
		Quaternion spawnRot = Quaternion.identity;

		if (spawn) {
			Instantiate (power, spawnPos, spawnRot); //spawn hazards at random positions
			spawn = false;
		}

		if (wS.startWaves) {
			time += 1f * Time.deltaTime;
			if (time >= targetTime) {
				spawn = !spawn;
				time = 0;
			}
		}
	}
}
