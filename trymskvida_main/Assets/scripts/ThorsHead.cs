using UnityEngine;
using System.Collections;

public class ThorsHead : MonoBehaviour {
	
	bool rotate = false;
	bool rotateBack = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate && !rotateBack) {
			transform.Rotate (new Vector3 (0, 0, 1) * Time.deltaTime * 30);
		} if (transform.rotation.z >= 0.2 || rotateBack) {
			rotate = false;
			rotateBack = true;
			transform.Rotate (new Vector3 (0, 0, -1) * Time.deltaTime * 30);
		} if (transform.rotation.z <= 0) {
			rotate = false;
			rotateBack = false;
		}
	}
	
	void OnMouseDown () {
		rotate = true;
	}
}

