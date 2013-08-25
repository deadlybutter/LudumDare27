using UnityEngine;
using System.Collections;

public class ChallengeManager : MonoBehaviour {
	
	public static string COMPLETED_TAG = "completed-challenge";
	public static string UNCOMPLETED_TAG = "uncompleted-challenge";
	
	public GameObject challenge1;
	public GameObject challenge2;
	public GameObject challenge3;
	public GameObject challenge4;
	public GameObject challenge5;
	public GameObject challenge6;
	public GameObject challenge7;
	public GameObject challenge8;
	public GameObject challenge9;
	public GameObject challenge10;
	public ArrayList challenges;
	
	private int count = 0;
	
	private bool lightOn = false;
	public GameObject light;
	
	public Texture2D challengeBox;
	public GUIStyle style;
	
	public Texture2D countdownImage;
	public int seconds = 10; 
	public GUIStyle style2;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("checkAndUpdateStatus", 10f, 10f);
		InvokeRepeating("updateEmergencyLight", 0f, 1f);
		seconds = 10;
		InvokeRepeating("doomTicker", 2f, 1f);
		challenges = new ArrayList();
		challenges.Add(challenge1);
		challenges.Add(challenge2);
		challenges.Add(challenge3);
		challenges.Add(challenge4);
		challenges.Add(challenge5);
		challenges.Add(challenge6);
		challenges.Add(challenge7);
		challenges.Add(challenge8);
		challenges.Add(challenge9);
		challenges.Add(challenge10);
		for(int index = 0; index < 10; index++){
			GameObject g = (GameObject)challenges[index];
			g.name += " " + UNCOMPLETED_TAG;
		}
		style = new GUIStyle();
		style.fontSize = 24;
		style2 = new GUIStyle();
		style2.fontSize = 24;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if(count >= challenges.Count){
			return;	
		}
		GameObject challenge = (GameObject) challenges[count];
		
		if(challenge.name == COMPLETED_TAG){
			return;	
		}
		int x = (Screen.width - 20) - challengeBox.width; 
		int y = (Screen.height - 20) - challengeBox.height;
		GUI.DrawTexture(new Rect(x, y, challengeBox.width, challengeBox.height), challengeBox);
		GUI.Label(new Rect(x + 10, y + 40, challengeBox.width, challengeBox.height), "Fix the " + challenge.name.Replace(UNCOMPLETED_TAG, ""), style);
		
		int x2 = 20;
		int y2 = 20;
		GUI.DrawTexture(new Rect(x2, y2, countdownImage.width, countdownImage.height), countdownImage);
		GUI.Label(new Rect(x2 + (countdownImage.width / 2), y2 + (countdownImage.height / 2), countdownImage.width, countdownImage.height), "" + seconds, style2);
	}	
	
	void checkAndUpdateStatus(){
		GameObject challenge = (GameObject) challenges[count];
		if(challenge.name.EndsWith(UNCOMPLETED_TAG)){
			Application.LoadLevel("MainMenu");
			return;	
		}
		if(count >= 10){
			Application.LoadLevel("MainMenu");
			return;
		}
		count++;
		seconds = 11;
	}
	
	void updateEmergencyLight(){
		GameObject current = (GameObject) challenges[count];
		if(current.name.EndsWith(UNCOMPLETED_TAG)){
			if(lightOn){
				light.light.range = 15;
			}
			else{
				light.light.range = 0;
			}
			lightOn = !lightOn;
		}
		else{
			lightOn = false;
			light.light.range = 0; 
		}
	}
	
	void doomTicker(){
		seconds--;
	}
	
}
