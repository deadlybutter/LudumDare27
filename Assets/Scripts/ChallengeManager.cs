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
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("checkAndUpdateStatus", 10f, 10f);
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
	}
	
	// Update is called once per frame
	void Update () {
		//Emergency light code - check if the current object has been completed. spin / not sping depending on its state
	}
	
	void OnGUI(){
		GameObject challenge = (GameObject) challenges[count];
		GUI.Box(new Rect(10, 10, 240, 20), "Fix the " + challenge.name.Replace(UNCOMPLETED_TAG, ""));	
	}	
	
	void checkAndUpdateStatus(){
		GameObject challenge = (GameObject) challenges[count];
		if(challenge.name.EndsWith(UNCOMPLETED_TAG)){
			//Lost the game
			return;	
		}
		count++;
	}
	
}
