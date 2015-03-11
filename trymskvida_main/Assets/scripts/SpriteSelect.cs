using UnityEngine;
using System.Collections;

namespace CharacterCustomize {
	public class SpriteSelect : MonoBehaviour {

		public string Key;
		public bool UpdateEachFrame = false;
		private int val = -1;

		public Sprite[] Sprites;

		public string DressKey;
		public Sprite[] Dress;
		public bool UseDress = false;
		private int dressVal = -1;

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

		public void SelectDress(int sprite) {
			if (sprite < 0 || sprite >= Dress.Length) {
				PlayerPrefs.SetInt(DressKey, 0);
			} else {
				PlayerPrefs.SetInt(DressKey, sprite);
			}
		}

		private void UpdateNormalSprite() {
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

		private void UpdateDressSprite() {
			if (PlayerPrefs.HasKey (DressKey)) {
				int k = PlayerPrefs.GetInt(DressKey);
				if (k != dressVal) {
					dressVal = k;
					if (k >= 0 && k < Dress.Length) {
						gameObject.GetComponent<SpriteRenderer>().sprite = Dress[k];
					}
				}
			}
		}

		private void UpdateSprite() {
			if (UseDress) {
				UpdateDressSprite ();
			} else {
				UpdateNormalSprite ();
			}
		}
	}
}
