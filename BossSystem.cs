using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossSystem : MonoBehaviour {

	public bool spawnBoss = false;
	public bool showText = false;
	public GameObject bossObj;

	private float bossTime;
	public Text bossText;

	public Vector3 bSpawnValues;

	void Start()
	{
		bossText.text = "";
	}

	void Update () {
		if (spawnBoss) {
			Vector3 spawnPos = new Vector3 (bSpawnValues.x, Random.Range (-bSpawnValues.y, bSpawnValues.y), bSpawnValues.z);
			Quaternion spawnRot = Quaternion.identity;
			Instantiate (bossObj, spawnPos, spawnRot);
			spawnBoss = false;
			showText = true;
		}

		if (showText) {
			bossTime += 1f * Time.deltaTime;
			if (bossTime <= 5) {
				bossText.text = "Boss Wave!";
			} else {
				bossText.text = "";
			}
		}
	}
}
