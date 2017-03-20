﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Frontera{
	public float xMin, xMax, zMin, zMax;
}

public class Mover : MonoBehaviour {

	public float speed;
	public float tilt;
	public Frontera frontera;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			GetComponent<AudioSource>().Play();
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, frontera.xMin, frontera.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, frontera.zMin, frontera.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
	
}
