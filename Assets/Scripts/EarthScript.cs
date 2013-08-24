using UnityEngine;
using System.Collections;

public class EarthScript : MonoBehaviour {
	
	public float increaseRate;
	public float repeatTime;
	public float maxSize;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("IncreaseEarth", 0, repeatTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void IncreaseEarth(){
		if(transform.localScale.x >= maxSize){
			return;	
		}
		Vector3 increaseVector = new Vector3(increaseRate, increaseRate, increaseRate);
		transform.localScale += increaseVector;
	}
}
