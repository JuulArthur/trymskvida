using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CharacterCustomize {
	public class SelectCustomizeGroupScript : MonoBehaviour {

		public Toggle[] SelectButtons;

		public Sprite UnselectSprite;
		public Sprite SelectSprite;

		public string Group_1_Key;
		public Sprite[] Group_1_Unselect;
		public Sprite[] Group_1_Select;

		public string Group_2_Key;
		public Sprite[] Group_2_Unselect;
		public Sprite[] Group_2_Select;

		public string Group_3_Key;
		public Sprite[] Group_3_Unselect;
		public Sprite[] Group_3_Select;

		private const int GroupCount = 3;
		private int SelGroup = 1;

		private bool GetRelevantSprites(out Sprite[] Sel, out Sprite[] unSel) {
				
			switch (SelGroup) {
			case 1:
				Sel = Group_1_Select;
				unSel = Group_1_Unselect;
				break;
			case 2:
				Sel = Group_2_Select;
				unSel = Group_2_Unselect;
				break;
			case 3:
				Sel = Group_3_Select;
				unSel = Group_3_Unselect;
				break;
			default:
				Sel = null;
				unSel = null;
				return false;
			}

			return true;
		}

		private string GetRelevantKey() {
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

		public void SelectGroup(int group) {
			// Check for legality of argument
			if (group > 0 && group <= GroupCount) {
				SelGroup = group;
			} else {
				return;
			}

			// Update sprites, selected button and enabled
			Sprite[] selSprites;
			Sprite[] unselSprites;
			
			GetRelevantSprites (out selSprites, out unselSprites);
			int minSprites = selSprites.Length > unselSprites.Length ? unselSprites.Length : selSprites.Length;
			int selected = PlayerPrefs.GetInt (GetRelevantKey ());

			for (int i = 0; i < SelectButtons.Length; i++) {
				Toggle btn = SelectButtons[i];
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

		public void SelectAspect (int value) {
			if (value >= 0) {
				string key = GetRelevantKey();
				PlayerPrefs.SetInt (key, value);
			}
		}

		// Use this for initialization
		void Start () {
			SelectGroup (1);
		}
	}
}
