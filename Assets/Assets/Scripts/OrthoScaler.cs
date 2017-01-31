using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoScaler : MonoBehaviour {

	// Scales camera depending on screen size
	void Start () {
		//float width = Camera.main.orthographicSize / Screen.height * Screen.width;
		//Debug.Log (width);
		Camera.main.orthographicSize = 8.0f / Screen.width * Screen.height;
	}
	
}
