using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CharacterCustomize {
	public class SelectCustomizeGroupScript : MonoBehaviour {

		public Sprite UnselectSprite;
		public Sprite SelectSprite;

		public string Group_1_Key;
		public Toggle[] Group_1_Buttons;
		public Sprite[] Group_1_Unselect;
		public Sprite[] Group_1_Select;

		public string Group_2_Key;
		public Toggle[] Group_2_Buttons;
		public Sprite[] Group_2_Unselect;
		public Sprite[] Group_2_Select;

		public string Group_3_Key;
		public Toggle[] Group_3_Buttons;
		public Sprite[] Group_3_Unselect;
		public Sprite[] Group_3_Select;

		private bool GetRelevantSprites(int SelGroup, out Sprite[] Sel, out Sprite[] unSel, out Toggle[] Buttons) {
				
			switch (SelGroup) {
			case 1:
				Sel = Group_1_Select;
				unSel = Group_1_Unselect;
				Buttons = Group_1_Buttons;
				break;
			case 2:
				Sel = Group_2_Select;
				unSel = Group_2_Unselect;
				Buttons = Group_2_Buttons;
				break;
			case 3:
				Sel = Group_3_Select;
				unSel = Group_3_Unselect;
				Buttons = Group_3_Buttons;
				break;
			default:
				Sel = null;
				unSel = null;
				Buttons = null;
				return false;
			}

			return true;
		}

		private string GetRelevantKey(int SelGroup) {
			switch (SelGroup) {
			case 1:
				return Group_1_Key;
			case 2:
				return Group_2_Key;
			case 3:
				return Group_3_Key;
			default:
				return null;
			}
		}

		public void SelectAspect (int value) {
			int group = value / 3 + 1;
			value = value % 3;
			if (value >= 0) {
				string key = GetRelevantKey(group);
				PlayerPrefs.SetInt (key, value);
			}
		}

		// Use this for initialization
		void Start () {
			for (int s = 1; s <= 3; s++) {
				// Get relevant sprites and selected button
				Sprite[] selSprites;
				Sprite[] unselSprites;
				Toggle[] buttons;
				
				GetRelevantSprites (s, out selSprites, out unselSprites, out buttons);
				int minSprites = selSprites.Length > unselSprites.Length ? unselSprites.Length : selSprites.Length;
				int selected = PlayerPrefs.GetInt (GetRelevantKey (s));

				// Go through all 
				for (int i = 0; i < buttons.Length; i++) {
					Toggle btn = buttons[i];
					if (i < minSprites) {
						// Legal, enabled
						((Image)(btn.targetGraphic)).sprite = unselSprites[i];
						((Image)(btn.graphic)).sprite = selSprites[i];
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
		}
	}
}
