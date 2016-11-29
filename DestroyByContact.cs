using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public int scoreValue;
	public int damage;

	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player") {
			gameController.UpdateHealthandLives (damage);
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if(gameObject.tag == "Enemy")
		{
			if (other.tag == "Player Bullet") {
				gameController.AddScore (scoreValue);
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		}

		if (other.tag == "Hazard") {
			return;
		}

		if (other.tag == "Enemy") {
			return;
		}
	}
}