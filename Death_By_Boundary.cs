﻿using UnityEngine;
using System.Collections;

public class Death_By_Boundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy (other.gameObject);
	}

}
