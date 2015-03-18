using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	private AudioSource VoiceSource;

	void Start () {
		VoiceSource = GameObject.Find ("VoiceSource").audio;
		}

	public void loadGivenLevel(string level) {
		Application.LoadLevel (level);
		VoiceSource.Stop ();
		}
}
