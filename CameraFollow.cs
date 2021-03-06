﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float posx = Mathf.SmoothDamp(transform.position.x,player.transform.position.x, ref velocity.x,smoothTimeX);
	
		float posy = Mathf.SmoothDamp(transform.position.y,player.transform.position.y, ref velocity.y,smoothTimeY);
		transform.position = new Vector3(posx, posy, transform.position.z);
	}

}
