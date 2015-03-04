using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public void loadGivenLevel(string level) {
		Application.LoadLevel (level);
		}
}
