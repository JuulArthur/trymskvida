using UnityEngine;
using System.Collections;

public class moveHammer : MonoBehaviour {

	public Sprite hammer;
	private Vector2 start;
	private Vector2 end;
	private float speed;


	// Use this for initialization
	void Start () { 
		start = new Vector3 (0, 0);
		end = new Vector3 (2, 2);
		speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		var step = speed * Time.deltaTime;

		transform.position = Vector2.MoveTowards(transform.position, end, step);
	}
}
