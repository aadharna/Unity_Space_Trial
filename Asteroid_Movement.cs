using UnityEngine;
using System.Collections;

public class Asteroid_Movement : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.velocity = (transform.forward * speed);
	}
}
