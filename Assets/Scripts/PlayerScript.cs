﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public float normalSpeed;
	public float mouseSensitivity;	
	public float upDownRange;	
	public float verticalRotation;
	public float verticalVelocity;
	public float jumpSpeed;	
	public float gravity;
	public float bulletImpulse;
	public GameObject bulletPrefab;
	public CharacterController cc;	
	public int ammo = 2;
	public Texture2D crosshair;
	public Texture2D ammoImage;
	public AudioSource audioSource;
	public AudioClip gunSound;
	public GUIStyle style;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc =  GetComponent<CharacterController>();
		audioSource = GetComponent<AudioSource>();
		InvokeRepeating("reload", 10f, 10f);
		style = new GUIStyle();
		style.fontSize = 24;
		style.normal.textColor = Color.white;
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
		
		if(Input.GetButtonDown("Fire1") && ammo > 0){
			GameObject bullet = (GameObject)Instantiate(bulletPrefab, Camera.main.transform.position + (Camera.main.transform.forward), Camera.main.transform.rotation); 	
			bullet.rigidbody.AddForce(Camera.main.transform.forward * bulletImpulse, ForceMode.Impulse);
			ammo--;
			audioSource.PlayOneShot(gunSound, 0.5f);
		}
		
		speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		
		cc.Move(speed * Time.deltaTime);		
		
	}
	
	void OnGUI(){
		
		float xMin = (Screen.width / 2) - (crosshair.width / 2);
		float yMin = (Screen.height / 2) - (crosshair.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshair.width, crosshair.height), crosshair);
		
		int x = 20; 
		int y = (Screen.height - 20) - ammoImage.height;
		GUI.DrawTexture(new Rect(x, y, ammoImage.width, ammoImage.height), ammoImage);
		GUI.Label(new Rect(x + (ammoImage.width / 2), y + (ammoImage.height / 2), ammoImage.width, ammoImage.height), "" + ammo, style);		
	}
	
	void reload(){
		ammo += 2;	
	}
	
}
