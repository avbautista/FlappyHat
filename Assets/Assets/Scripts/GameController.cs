using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject birdObject;
	GameObject birdController;
	bool birdAlive;

	Vector3 spawnPosition;

		void Start () {
		birdAlive = false;
		StartCoroutine (BirdSpawner());
	}

	//Use FixedUpdate for physics based updates
	void FixedUpdate () {
		if (Input.GetButtonUp("Fire1")) {
			Debug.Log ("Flap");
			//birdController = GameObject.FindWithTag ("Player");
			//birdController.AddComponent<Rigidbody2D>();
			birdController.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100.0f);
			//Debug.Log (Vector3);
		}
	}

	//Coroutine responsible for bird creation
	IEnumerator BirdSpawner () {
		yield return new WaitForSeconds (1.0f);
		while (true) {
			if (!birdAlive) {
				Vector3 screenPoint = new Vector3 (Screen.width, Screen.height, 0.0f);
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint (screenPoint);
				spawnPosition = new Vector3 (-worldPoint.x, (worldPoint.y * 3 / 4), 0.0f);
				birdController = Instantiate (birdObject, spawnPosition, Quaternion.identity) as GameObject;
				birdAlive = true;
				birdController.GetComponent<Rigidbody2D> ().velocity = new Vector3 (2.0f, 0.0f, 0.0f);

			}
			yield return new WaitForSeconds (0.5f);
		}
	}

	//Destroy objects that get out of bounds
	void OnTriggerEnter2D (Collider2D other) {
		birdAlive = false;
		Destroy (other.gameObject);
	}
}
