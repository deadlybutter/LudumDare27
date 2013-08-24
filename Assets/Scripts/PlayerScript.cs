using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public float normalSpeed;
	public float mouseSensitivity;	
	public float upDownRange;	
	public float verticalRotation;
	public float verticalVelocity;
	public float jumpSpeed;	
	public float gravity;
	public CharacterController cc;	
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc =  GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Mouse rotation
		float yaw = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, yaw, 0);
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		
		//Movement
		float forwardSpeed = Input.GetAxis("Vertical") * normalSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * normalSpeed;
		verticalVelocity += gravity * Time.deltaTime;
		
		bool isGrounded = cc.isGrounded;
		Vector3 speed = Vector3.zero;
		
		if(Input.GetButtonDown("Jump") && isGrounded){
			verticalVelocity = jumpSpeed;	
		}
		
		speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		
		cc.Move(speed * Time.deltaTime);		
		
	}
}
