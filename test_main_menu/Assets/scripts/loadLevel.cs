using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public void loadGivenLevel(int level) {
		Application.LoadLevel (level);
		}
}
