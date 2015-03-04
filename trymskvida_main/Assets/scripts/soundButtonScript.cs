using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Test {
	public class soundButtonScript : MonoBehaviour {


		public Sprite soundSprite;
		public Sprite noSoundSprite;
		private AudioSource Source;

		private bool soundBool;
		
		private Button soundButton;

		// Use this for initialization
		void Start () {
			soundButton = GetComponent<Button>();
			Source = GameObject.Find ("MusicSource").audio;
			soundBool = true;
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void toggleSound(){
			if (soundBool) {
				soundButton.image.sprite = noSoundSprite;
				soundBool = false;
				Source.mute = true;
			} else {
				soundButton.image.sprite = soundSprite;
				soundBool = true;
				Source.mute = false;
			}
	}

		void Awake(){
			DontDestroyOnLoad (transform.gameObject);
		}
}
}