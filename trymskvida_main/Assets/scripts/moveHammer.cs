using UnityEngine;
using System.Collections;

public class moveHammer : MonoBehaviour {

	private Animator animator;
	private Vector3 end;
	private float speed;
	private int state;


	// Use this for initialization
	void Start () { 
		end = new Vector3 (100, 80, -1);
		speed = 10f;
		state = 0;
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		var step = speed * Time.deltaTime;

		transform.position = Vector2.MoveTowards(transform.position, end, step);
	}

	void OnMouseDown () {
		print (state);
		if (state == 0) {
			animator.SetInteger ("Direction", 1);
			state = 1;
		} else {
			animator.SetInteger("Direction", 0);
			state = 0;
			Invoke("StopAnimation", this.animator.GetCurrentAnimatorStateInfo (0).length);
		}

	}

	void StopAnimation () {
		animator.SetInteger ("Direction", 1);
		state = 1;
		}
}
