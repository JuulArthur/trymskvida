using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {
	private float LerpTime;
	private Vector3 StartPosition;
	public float InTime = 5f;
	public float RotationVelocity = 5f;
	public Vector3 EndPosition;
	public float rotationTime = 1f;
	public float waitTime;
	public bool wait;

	// Use this for initialization
	void Start () {
		LerpTime = InTime;
		StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (waitTime >= 0) {
			waitTime -= 0.1f;
		} else if (!(transform.position == EndPosition)) {
				InTime -= Time.deltaTime;
				InTime = InTime < 0 ? 0 : InTime;
				transform.Rotate (Vector3.forward * Time.deltaTime * RotationVelocity);
				transform.position = Vector3.Lerp (StartPosition, EndPosition, 1 - InTime / LerpTime);	
		} else if (!(rotationTime <= 0)) {
			transform.Rotate (Vector3.forward * Time.deltaTime * RotationVelocity);
			rotationTime -= 0.05f;
		}
	}
}
