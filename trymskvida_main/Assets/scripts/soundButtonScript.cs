using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Test {
	public class soundButtonScript : MonoBehaviour {


		public Sprite soundSprite;
		public Sprite noSoundSprite;

		private bool soundBool;
		
		private Button soundButton;

		// Use this for initialization
		void Start () {
			soundButton = GetComponent<Button>();
			soundBool = true;
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void toggleSound(){
			if (soundBool) {
				soundButton.image.sprite = noSoundSprite;
				soundBool = false;
				AudioListener.pause = true;
			} else {
				soundButton.image.sprite = soundSprite;
				soundBool = true;
				AudioListener.pause = false;
			}
	}

		void Awake(){
			DontDestroyOnLoad (transform.gameObject);
		}
}
}