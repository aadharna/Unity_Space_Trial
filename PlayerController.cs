using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary  {

	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;
	private Rigidbody rb;
	private AudioSource audioSource;
	private float nextFire;
	private GameLoop gameController;

	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	//executed once at the start of the game
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource> ();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameLoop> ();
		}
		if (gameController == null) {
			Debug.Log ("Connot find 'GameController' script");
		}
	}

	//executed with each frame renewal
	void Update() 
	{
		if ((Input.GetButton("Fire1") || Input.GetKeyDown("space")) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			gameController.addScore (-1);
			audioSource.Play ();
		}
	}

	//executed once per physics step
	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = (movement*speed);

		rb.position = new Vector3
		(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * (-tilt));
	}
}