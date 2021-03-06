﻿using UnityEngine;
using System.Collections;

namespace PlayerControl {
	public class PlayerMoveScript : MonoBehaviour {

		private bool walking = false;
		private bool wavingArms = false;
		private bool shaking = false;

		private float walkPhase = 0;
		private float walkTime = 0;
		private float walkTimeLeft = 0;
		public Vector2 walkTarget;
		private Vector2 walkStart;

		private float wavePhase = 0;

		public GameObject Head;
		public GameObject Torso;
		public GameObject LeftHand;
		public GameObject RightHand;
		public GameObject LeftFoot;
		public GameObject RightFoot;

		public void StartWalk(float time) {
			walkTime = time;
			walkTimeLeft = time;
			walkStart = transform.position;
			walking = true;
		}
		public void StopWalk() {
			walking = false;
			walkPhase = 0;
		}

		public void StartWaveArms() {
			wavingArms = true;
		}
		public void StopWaveArms() {
			wavingArms = false;
		}

		public void StartShake() {
			shaking = true;
		}
		public void StopShake() {
			shaking = false;
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (walking) {
				walkTimeLeft -= Time.deltaTime;
				walkPhase += Time.deltaTime;
				transform.position = Vector2.Lerp(walkTarget, walkStart, walkTimeLeft / walkTime);
				if (walkTimeLeft < 0) {
					StopWalk();
				}
				if (walkPhase < 0.3f) {
					LeftFoot.rigidbody2D.rotation = 100f * walkPhase;
					//LeftFoot.transform.rotation = Quaternion.Lerp(LeftFoot.transform.rotation, Quaternion.Euler(-Vector3.forward), walkPhase / 0.3f); 
				}
				if (walkPhase > 0.3f && walkPhase < 0.6f) {
					RightFoot.rigidbody2D.rotation = - 100f * (walkPhase - 0.3f);
					//RightFoot.rigidbody2D.AddTorque(2f*(walkPhase - 0.3f) / 0.3f, ForceMode2D.Impulse);
					//RightFoot.transform.rotation = Quaternion.Lerp(RightFoot.transform.rotation, Quaternion.Euler(-Vector3.forward), (walkPhase - 0.3f) / 0.3f);
				} else
				if (walkPhase > 0.6f) {
					walkPhase -= 0.6f;
				}
			}
			if (wavingArms) {
				wavePhase += Time.deltaTime;
				if (wavePhase < 0.2f) {
					LeftHand.rigidbody2D.AddRelativeForce(-Vector2.right * 40.0f* (Random.value + 0.5f), ForceMode2D.Force);
					RightHand.rigidbody2D.AddRelativeForce(-Vector2.right * 30.0f * (Random.value + 0.5f), ForceMode2D.Force);
				} else if (wavePhase < 0.4f) {
					RightHand.rigidbody2D.AddRelativeForce(Vector2.right * 40.0f * (Random.value + 0.5f), ForceMode2D.Force);
					LeftHand.rigidbody2D.AddRelativeForce(Vector2.right * 30.0f* (Random.value + 0.5f), ForceMode2D.Force);
				} 
				if (wavePhase > 0.4f) {
					wavePhase = 0.0f;
				}
			}
			if (shaking) {
				Head.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.4f, ForceMode2D.Impulse);
				//Torso.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.2f, ForceMode2D.Impulse);
				//LeftHand.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.2f, ForceMode2D.Impulse);
				//RightHand.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.2f, ForceMode2D.Impulse);
				//LeftFoot.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.2f, ForceMode2D.Impulse);
				//RightFoot.rigidbody2D.AddRelativeForce(Random.onUnitSphere * 0.2f, ForceMode2D.Impulse);
			}
		}
	}
}
