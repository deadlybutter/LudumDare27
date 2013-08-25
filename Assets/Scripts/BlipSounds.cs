using UnityEngine;
using System.Collections;

public class BlipSounds : MonoBehaviour {
	
	public AudioClip blip1;
	public AudioClip blip2;
	public AudioClip blip3;
	
	public float blipRate;
	public float blipChance;
	
	public AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("doBlip", blipRate, blipRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void doBlip(){
		if(Random.value	<= blipChance){
			int clip = Random.Range(1, 4);
			if(clip == 1){
				audioSource.PlayOneShot(blip1, 0.5f);
			}
			else if(clip == 2){
				audioSource.PlayOneShot(blip2, 0.5f);
			}
			else if(clip == 3){
				audioSource.PlayOneShot(blip3, 0.5f);
			}
		}		
	}

}
