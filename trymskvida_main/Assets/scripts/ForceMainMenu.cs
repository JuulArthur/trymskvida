using UnityEngine;
using System.Collections;

public class ForceMainMenu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Application.LoadLevel ("Mainmenuscene");
		Destroy (this);
	}
}
