using UnityEngine;
using System.Collections;

namespace Test {
	public class SpriteSelect : MonoBehaviour {

		public Sprite Head1;
		public Sprite Head2;
		public Sprite Head3;

		// Use this for initialization
		void Start () {
			UpdateSprite ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void SelectSprite (int sprite) {
				switch (sprite) {
				case 2:
					PlayerPrefs.SetInt("Head", sprite);
					break;
				case 3:
					PlayerPrefs.SetInt("Head", sprite);
					break;
				default:
					PlayerPrefs.SetInt("Head", 1);
					break;
				}
				UpdateSprite();
		}

		private void UpdateSprite() {
			Sprite s = Head1;
			if (PlayerPrefs.HasKey ("Head")) {
				int v = PlayerPrefs.GetInt("Head");
				switch (v) {
				case 2:
					s = Head2;
					break;
				case 3:
					s = Head3;
					break;
				default:
					break;
				}
			}

			gameObject.GetComponent<SpriteRenderer>().sprite = s;
		}
	}
}
