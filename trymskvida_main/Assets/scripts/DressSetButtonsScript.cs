using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CharacterCustomize {
	public class DressSetButtonsScript : MonoBehaviour {

		public Toggle[] SelectButtons;
		
		public Sprite UnselectSprite;
		public Sprite SelectSprite;
		
		public string DressKey;
		public Sprite[] DressUnselect;
		public Sprite[] DressSelect;

		// Use this for initialization
		void Start () {

			int minSprites = DressSelect.Length > DressUnselect.Length ? DressUnselect.Length : DressSelect.Length;

			if (!PlayerPrefs.HasKey (DressKey))
				PlayerPrefs.SetInt (DressKey, 0);

			int selected = PlayerPrefs.GetInt (DressKey);
			
			for (int i = 0; i < SelectButtons.Length; i++) {
				Toggle btn = SelectButtons[i];
				if (i < minSprites) {
					// Legal, enabled
					((Image)(btn.targetGraphic)).sprite = DressUnselect[i];
					((Image)(btn.graphic)).sprite = DressSelect[i];
					btn.interactable = true;
					btn.isOn = i == selected;
				} else {
					// Illegal, disabled
					((Image)(btn.targetGraphic)).sprite = UnselectSprite;
					((Image)(btn.graphic)).sprite = SelectSprite;
					btn.interactable = false;
				}
			}
		}

		public void SetDress(int dress) {
			if (dress >= 0 && dress < DressSelect.Length)
				PlayerPrefs.SetInt (DressKey, dress);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
