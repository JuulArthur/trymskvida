using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour {

	private AudioSource Source;

	public AudioClip[] clips;
	private int clipNumber = 0;

	private bool play = false;
	private bool muted = false;

	public Sprite voiceSprite;
	public Sprite noVoiceSprite;

	private Button voiceButton;

	// Use this for initialization
	void Start () {
		voiceButton = GetComponent<Button>();
		Source = GameObject.Find ("VoiceSource").audio;
		Rewind ();
	}
	
	// Update is called once per frame
	void Update () {
		if (play && !Source.isPlaying) {
			clipNumber++;
			play = clipNumber < clips.Length;
			DoPlayThisClip ();
		}
	}

	private void Play() {
		play = true;
		DoPlayThisClip ();
	}

	private void Stop() {
		play = false;
		Source.Stop ();
	}

	private void Rewind() {
		clipNumber = 0;
		Play ();
	}

	private void DoPlayThisClip () {
		if (clipNumber < clips.Length) {
			Source.clip = clips[clipNumber];
			Source.Play ();
		}
	}

	public void ToggleMute () {
		if (muted) {
			Source.mute = false;
			Rewind ();
			muted = false;
			voiceButton.image.sprite = voiceSprite;
		} else {
			Source.mute = true;
			muted = true;
			voiceButton.image.sprite = noVoiceSprite;
		}
	}
}
