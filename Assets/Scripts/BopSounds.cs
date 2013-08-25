using UnityEngine;
using System.Collections;

public class BopSounds : MonoBehaviour {
	
	public AudioClip bop1;
	public AudioClip bop2;
	public AudioClip bop3;
	
	public float bopRate;
	public float bopChance;
	
	public AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("doBop", bopRate, bopChance);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void doBop(){
		if(Random.value	<= bopChance){
			int clip = Random.Range(1, 4);
			if(clip == 1){
				audioSource.PlayOneShot(bop1, 0.5f);
			}
			else if(clip == 2){
				audioSource.PlayOneShot(bop2, 0.5f);
			}
			else if(clip == 3){
				audioSource.PlayOneShot(bop3, 0.5f);
			}
		}
	}
	
}
