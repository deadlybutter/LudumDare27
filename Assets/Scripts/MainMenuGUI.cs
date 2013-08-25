using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		GUI.Label(new Rect(200, 200, 200, 200), "Use wasd + space for movement" +
			" and use left mouse to fire your Fixi-Gun 9000");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Play")) {
			Application.LoadLevel("IntroScene");
		}
	}
	
}
