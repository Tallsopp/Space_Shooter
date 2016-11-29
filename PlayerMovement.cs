using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax; //setting the values of the boundary box
}

public class PlayerMovement : MonoBehaviour {
	public float speed; //how fast the player moves
	public float tilt; //the amount the player tilts when moving
	private Rigidbody rb; //player's rigidbody

	public Boundary boundary; //reference to the boudary class

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate ()
	{
		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveH, moveV, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

		rb.rotation = Quaternion.Euler (rb.velocity.y * tilt, 0f, 0f);
	}
}
