using UnityEngine;
using System.Collections;

public class TimeOut : MonoBehaviour {

	public float Lifetime;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, Lifetime);

	}
}
