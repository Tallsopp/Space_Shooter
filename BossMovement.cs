using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
	public Vector2 pos1;
	public Vector2 pos2;
	public float speed = 1.0f;

	void Update() {
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
	}
}  