using UnityEngine;
using System.Collections;

public class VoiceController : MonoBehaviour {

	private AudioSource Source;

	public AudioClip[] clips;
	private int clipNumber = 0;

	private bool play = false;

	// Use this for initialization
	void Start () {
		Source = GameObject.Find ("VoiceSource").audio;
	}
	
	// Update is called once per frame
	void Update () {
		if (play && !Source.isPlaying) {
			clipNumber++;
			play = clipNumber < clips.Length;
			DoPlayThisClip ();
		}
	}

	public void Play() {
		play = true;
		DoPlayThisClip ();
	}

	public void Stop() {
		play = false;
		Source.Stop ();
	}

	public void Rewind() {
		clipNumber = 0;
		Play ();
	}

	private void DoPlayThisClip () {
		if (clipNumber < clips.Length) {
			Source.clip = clips[clipNumber];
			Source.Play ();
		}
	}
}
