using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	private float LerpTime;
	private Vector3 StartPosition;
	public float InTime = 5f;
	public Vector3 EndPosition;

	// Use this for initialization
	void Start () {
		LerpTime = InTime;
		StartPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		InTime -= Time.deltaTime;
		InTime = InTime < 0 ? 0 : InTime;
		transform.position = Vector3.Lerp (StartPosition, EndPosition, 1 - InTime / LerpTime);
	}
}
