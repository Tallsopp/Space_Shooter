using UnityEngine;
using System.Collections;

public class Tumble : MonoBehaviour {

	public float rotater;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		rb.angularVelocity = Random.insideUnitSphere * rotater;
	}
}
