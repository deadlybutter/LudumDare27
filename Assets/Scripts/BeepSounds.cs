using UnityEngine;
using System.Collections;

public class BeepSounds : MonoBehaviour {
	
	public AudioClip beep1;
	public AudioClip beep2;
	public AudioClip beep3;
	
	public float beepRate;
	public float beepChance;
	
	public AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("doBeep", beepRate, beepRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void doBeep(){
		if(Random.value	<= beepChance){
			int clip = Random.Range(1, 4);
			if(clip == 1){
				audioSource.PlayOneShot(beep1, 0.5f);	
			}
			else if(clip == 2){
				audioSource.PlayOneShot(beep2, 0.5f);
			}
			else if(clip == 3){
				audioSource.PlayOneShot(beep3, 0.5f);
			}
		}
	}
	
}
