using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float TileLengthZ;

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, TileLengthZ); 

		Vector3 temp = new Vector3 (0.0f, 0.0f, 1);

		transform.position = startPos + temp * newPosition;
	}
}
