﻿using UnityEngine;
using System.Collections;

public class FlyThrough : MonoBehaviour {
 
	/*
	EXTENDED FLYCAM
		Desi Quintans (CowfaceGames.com), 17 August 2012.
		Based on FlyThrough.js by Slin (http://wiki.unity3d.com/index.php/FlyThrough), 17 May 2011.
 
	LICENSE
		Free as in speech, and free as in beer.
 
	FEATURES
		WASD/Arrows:    Movement
		          Q:    Climb
		          E:    Drop
                      Shift:    Move faster
                    Control:    Move slower
                        End:    Toggle cursor locking to screen (you can also press Ctrl+P to toggle play mode on and off).
	*/
 
	public float cameraSensitivity = 90;
	public float climbSpeed = 4;
	public float normalMoveSpeed = 10;
	public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3;
 
	private float rotationX = -90.0f;
	private float rotationY = 0.0f;
 
	void Start ()
	{
		Screen.lockCursor = true;
		Screen.lockCursor = false;
		Screen.lockCursor = true;
		
	}
 
	void Update ()
	{
		
		
		//InputDevice device = InputManager.ActiveDevice;
		//Vector2 lsv = device.LeftStickVector;
		
		rotationX += Input.GetAxis("LookHorizontal") * cameraSensitivity * Time.deltaTime;
		rotationY -= Input.GetAxis("LookVertical") * cameraSensitivity * Time.deltaTime;
		
		rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		
		
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		
		//rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
		//rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
		//rotationY = Mathf.Clamp (rotationY, -90, 90);
 
		
		
		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

		
				
//	 	if (device.RightTrigger.IsPressed)
//	 	{
//			transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * device.LeftStickY * Time.deltaTime;
//			transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * device.LeftStickX * Time.deltaTime;
//	 	}
//	 	else if (device.LeftTrigger.IsPressed)
//	 	{
//			transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * device.LeftStickY * Time.deltaTime;
//			transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * device.LeftStickX * Time.deltaTime;
//	 	}
//	 	else
//	 	{
//	 		transform.position += transform.forward * normalMoveSpeed * device.LeftStickY * Time.deltaTime;
//			transform.position += transform.right * normalMoveSpeed * device.LeftStickX * Time.deltaTime;
//	 	}
 
		

	 	if (Input.GetButton("ps3trigl"))
	 	{
			transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
	 	}
	 	else if (Input.GetButton("ps3trigr"))
	 	{
			transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
	 	}
	 	else
	 	{
	 		transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
	 	}
 
 
		if (Input.GetButton("ps3r1")) {transform.position += transform.up * climbSpeed * Time.deltaTime;}
		if (Input.GetButton("ps3l1"))  {transform.position -= transform.up * climbSpeed * Time.deltaTime;}
		
		if (Input.GetKey (KeyCode.Q)) {transform.position += transform.up * climbSpeed * Time.deltaTime;}
		if (Input.GetKey (KeyCode.E)) {transform.position -= transform.up * climbSpeed * Time.deltaTime;}
		
	
		if (Input.GetButtonDown("ps3tri") || Input.GetKeyDown(KeyCode.P))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
			Debug.Log (Screen.lockCursor);
		}
	}
}