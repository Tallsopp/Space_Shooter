using UnityEngine;
using System.Collections;

public class ScrollBG : MonoBehaviour {

	public float scrollSpeed;
	public float tileSize;

	private Vector3 startPos;


	void Start () {
		startPos = transform.position;
	}
	
	void Update () {
		float newPos = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
		transform.position = startPos + Vector3.right * newPos;
	}
}
