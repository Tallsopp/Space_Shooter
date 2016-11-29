using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private float rotateValue = 50f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime, rotateValue);
		transform.Rotate (Vector3.left * Time.deltaTime, rotateValue);
	}
}
