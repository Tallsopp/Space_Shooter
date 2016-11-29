using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
	public GameObject explosion;

	private GameController gameController;
	//reference to the gameController
	private Shooting shooting;
	//reference to shooting

	private float shieldTimer;
	//shield timer value
	private float rofTimer;
	//rof timer value

	private bool newROF = false;
	//checks if rate of fire is changed
	public bool activeShield = false;
	//checks if the player can activate the shield
	public bool smartBomb = false;
	//checks if the player can activate the smart bomb

	public GameObject shieldObj;
	//shield of the player

	void Start ()
	{
		//looks for gamecontroller and if found can refer to its scripts
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		shooting = GetComponent<Shooting> ();

		Collider playerCol = GetComponent<CapsuleCollider> ();
		playerCol.enabled = true;

		shieldTimer = 0;
		rofTimer = 0;
	}

	void Update ()
	{
		RateOfFire ();
		Shield ();
		SmartBomb ();
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Hazard") {
			gameController.health -= 20;
		}

		if (col.gameObject.tag == "Enemy") {
			gameController.health -= 10;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Fire Rate") {
			newROF = true;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Bomb") {
			smartBomb = true;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Health") {
			gameController.health += 25;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Lives") {
			gameController.lives += 1;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Shield") {
			activeShield = true;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Enemy Bullet") {
			gameController.health -= 10;
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
		}
	}

	void RateOfFire ()
	{
		if (newROF) {
			gameController.rofText.text = "Fire Rate Increased!";
			//change text to inform the player
			rofTimer += 1f * Time.deltaTime;
			//rof timer increases till the timer limit is reached
			if (rofTimer <= 5f) {
				shooting.fireRate = 0.1f;
				//rof increased
			} else {
				newROF = false;
			}

			if (!newROF) {
				shooting.fireRate = 0.2f;
				//if false the rof is reverted back to normal
				gameController.rofText.text = "";
				//removes the text
				rofTimer = 0;
			}
		}
	}

	void Shield ()
	{
		if (activeShield == false) {
			shieldObj.SetActive (false);
			//if false then no shield
		}

		if (activeShield == true) {
			shieldTimer += 1f * Time.deltaTime;
			shieldObj.SetActive (true);
			//if true activate the shield and start the timer
			if (shieldTimer >= 10f) {
				activeShield = false;
				shieldTimer = 0f;
			}
		}
	}

	void SmartBomb ()
	{
		if (smartBomb) {
			gameController.bombText.text = "Press 'U' to Activate Smart Bomb!";
			if (Input.GetKey (KeyCode.U)) {
				//local array searches for gameobjects with tag Enemy
				GameObject[] enemy = GameObject.FindGameObjectsWithTag ("Enemy");
				for (var i = 0; i < enemy.Length; i++) {
					//for every Enemy add points then destroy
					gameController.score += 50;
					Instantiate (explosion, enemy[i].transform.position, enemy[i].transform.rotation);
					Destroy (enemy [i]);
				}
				smartBomb = false;
			}
		}

		if(!smartBomb)
			gameController.bombText.text = "";
	}
}