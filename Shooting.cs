using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
	public float fireRate;
	//how fast the player can move
	private float nextFire;
	//when the player can fire next
	public Rigidbody bulletPrefab;
	//rigidbody of the bullet
	public Transform shotSpawn;
	//position of the player's shot spawn
	private AudioSource sound;

	void Start()
	{
		sound = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		FireWeapon ();
	}

	void FireWeapon ()
	{
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody bulletInstance;
			bulletInstance = Instantiate (bulletPrefab, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
			bulletInstance.AddForce (shotSpawn.forward * 100);
			sound.Play ();
		}
	}
}
