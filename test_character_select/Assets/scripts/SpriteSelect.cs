using UnityEngine;
using System.Collections;

namespace CharacterCustomize {
	public class SpriteSelect : MonoBehaviour {

		public string Key;
		public bool UpdateEachFrame = false;
		private int val = -1;

		public Sprite[] Sprites;

		// Use this for initialization
		void Start () {
			UpdateSprite ();
		}

		void Update() {
			if (UpdateEachFrame) {
				UpdateSprite();
			}
		}

		public void SelectSprite (int sprite) {
			if (sprite < 0 || sprite >= Sprites.Length) {
				PlayerPrefs.SetInt(Key, 0);
			} else {
				PlayerPrefs.SetInt(Key, sprite);
			}
			UpdateSprite();
		}

		private void UpdateSprite() {
			if (PlayerPrefs.HasKey (Key)) {
				int k = PlayerPrefs.GetInt(Key);
				if (k != val) {
					val = k;
					if (k >= 0 && k < Sprites.Length) {
						gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[k];
					}
				}
			}
		}
	}
}
