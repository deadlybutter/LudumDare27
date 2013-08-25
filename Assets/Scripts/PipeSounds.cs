using UnityEngine;
using System.Collections;

public class PipeSounds : MonoBehaviour {

	public AudioClip pipe1;
	public AudioClip pipe2;
	
	public float pipeRate;
	public float pipeChance;
	
	public AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("doPipe", pipeRate, pipeRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void doPipe(){
		if(Random.value	<= pipeChance){
			int clip = Random.Range(1, 3);
			if(clip == 1){
				audioSource.PlayOneShot(pipe1, 0.5f);
			}
			else if(clip == 2){
				audioSource.PlayOneShot(pipe2, 0.5f);
			}
		}
	}
	
}
