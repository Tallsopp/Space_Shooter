using UnityEngine;
using System.Collections;

public class ShieldContact : MonoBehaviour
{
	public GameObject explosion;
	private float shieldTime = 10f;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Hazard" | col.gameObject.tag == "Enemy") {
			shieldTime -= 5;
			Instantiate (explosion, col.transform.position, col.transform.rotation);
			Destroy (col.gameObject);
		}
	}
}
