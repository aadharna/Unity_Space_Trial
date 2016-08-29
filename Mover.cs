using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0.0f, 0.0f, 1 * speed);
			//(transform.forward * speed);
	}
}