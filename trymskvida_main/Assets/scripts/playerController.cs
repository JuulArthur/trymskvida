using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		int direction = 0;


		if (direction == 0 && !this.animator.GetCurrentAnimatorStateInfo (0).IsName("walkNorth")) {
			animator.SetInteger("Direction", 3);
				}
		
		if (vertical > 0) {
			animator.SetInteger ("Direction", 2);
			direction = 2;
			Invoke("StopAnimation", this.animator.GetCurrentAnimatorStateInfo (0).length);
		} else if (vertical < 0) {
			animator.SetInteger ("Direction", 0);
			direction = 0;
		} else if (horizontal > 0) {
			animator.SetInteger ("Direction", 1);
			direction = 1;
		} else if (horizontal < 0) {
			animator.SetInteger ("Direction", 3);
			direction = 3;
		} else if (Input.GetMouseButtonDown (0)) {
			animator.SetInteger ("Direction", 0);
		}
	}

	void StopAnimation () {
		animator.SetInteger ("Direction", 0);
		}

	void OnMouseDown () {
		animator.SetInteger ("Direction", 0);
	}
}