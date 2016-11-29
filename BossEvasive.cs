using UnityEngine;
using System.Collections;

public class BossEvasive : MonoBehaviour
{

	public float dodge;
	public float smoothing;
	public float tilt;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Boundary boundary;

	private float currentSpeed;
	private float targetManeuver;

	private float xPos;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (Evade ());
	}

	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.y);
			xPos = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			xPos = 0;
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (rb.velocity.y, targetManeuver, Time.deltaTime * smoothing);
		float currPos = Mathf.MoveTowards (rb.velocity.x, xPos, Time.deltaTime * smoothing);
		rb.velocity = new Vector2 (currPos, newManeuver);
		rb.position = new Vector2 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax)
		);

		rb.rotation = Quaternion.Euler (rb.velocity.x * tilt, 0f, 0f);
	}
}
