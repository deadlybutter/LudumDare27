using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision){
		GameObject collided = collision.gameObject;
		if(collided.name.EndsWith(ChallengeManager.UNCOMPLETED_TAG)){
			collided.name = ChallengeManager.COMPLETED_TAG;		
		}
		Destroy(gameObject);
	}
}
