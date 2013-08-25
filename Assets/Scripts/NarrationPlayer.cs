using UnityEngine;
using System.Collections;

public class NarrationPlayer : MonoBehaviour {

	public AudioClip clip;
	public AudioSource source;
	
	// Use this for initialization
	void Start () {
		Invoke("switchScenes", clip.length + 1);
		source.PlayOneShot(clip, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void switchScenes(){
		Debug.Log (clip.name);
		if(clip.name.Equals("Intro")){
			Application.LoadLevel("GameScene");	
		}
		else{
			Application.LoadLevel("MainMenu");	
		}
	}
}
