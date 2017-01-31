using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTrigger : MonoBehaviour {
	//removes gameobject that enters trigger collider
	void OnTriggerEnter2D (Collider2D other) {
		Destroy (other.gameObject);
	}
}
