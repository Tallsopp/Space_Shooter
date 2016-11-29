using UnityEngine;
using System.Collections;

public class RandomShooting : MonoBehaviour {

	public GameObject shot;
	public GameObject shotSpawn;
	public float fireRate;
	public float delay;
	private AudioSource sound;


	void Start () {
		sound = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}
	

	void Fire () {
		Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
		sound.Play ();
	}
}
