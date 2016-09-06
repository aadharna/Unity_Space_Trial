using UnityEngine;
using System.Collections;

public class EvasiveAction : MonoBehaviour {

	public float dodge, smoothing, tilt;
	public Vector2 startWait, maneuverTime, maneuverWait;
	public Boundary boundary;

	private float targetMan, currentSpeed;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade());

	}

	IEnumerator Evade() {

		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y)); 

		while (true) {

			targetMan = Random.Range (1, dodge) * (-Mathf.Sign(transform.position.x));
			yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));
			targetMan = 0;
			yield return new WaitForSeconds (Random.Range(maneuverWait.x, maneuverWait.y));

		}
	}

	void Update() {
		
		if (rb.position.z <= boundary.zMin) {

			Destroy (rb.gameObject);
		}
	}

	// Update is called once per physics step
	void FixedUpdate () {
		
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetMan, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * (-tilt));



	}
}
