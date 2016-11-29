using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
	public GameObject explosion;
	public GameObject enemyExplosion;
	public float health;
	private GameController gC;

	void Awake ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gC = gameControllerObject.GetComponent<GameController> ();
		}

		health = 100;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player Bullet") {
			health -= 5;
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
		}
	}

	void Update ()
	{
		if (health < 100) {
			Heal ();
		}

		if (health >= 100) {
			health = 100;
		}

		if (health <= 0) {
			Instantiate (enemyExplosion, transform.position, transform.rotation);
			gC.victory = true;
			Destroy (gameObject);
		}
	}

	void Heal ()
	{
		health += 1f * Time.deltaTime;
	}
}
