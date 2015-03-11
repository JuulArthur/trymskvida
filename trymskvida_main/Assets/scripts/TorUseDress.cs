using UnityEngine;
using System.Collections;

namespace CharacterCustomize {
	public class TorUseDress : MonoBehaviour {

		public bool initUSeDressTo = false;


		public bool UseDress {
			get {
				if (PlayerPrefs.HasKey (SpriteSelect.useDressKey)) {
					PlayerPrefs.SetInt (SpriteSelect.useDressKey, 0);
				}
				return PlayerPrefs.GetInt(SpriteSelect.useDressKey) == 1;
			}
			set {
				if (value)
					PlayerPrefs.SetInt (SpriteSelect.useDressKey, 1);
				else
					PlayerPrefs.SetInt (SpriteSelect.useDressKey, 0);
			}
		}

		void Start() {
			PlayerPrefs.SetInt (SpriteSelect.useDressKey, initUSeDressTo ? 1 : 0);
		}
	}
}
