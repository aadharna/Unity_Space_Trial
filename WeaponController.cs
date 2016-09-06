 using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shot_spawn;
	public float fireRate, delay;

	private AudioSource audiosource;

	// Use this for initialization
	void Start () {

		audiosource = GetComponent<AudioSource> ();
		InvokeRepeating ("fire", delay, Random.Range(0, fireRate + 2));
	}

	void fire () {
		
		Instantiate (shot, shot_spawn.position, shot_spawn.rotation);
		audiosource.Play ();
	}
}
