﻿using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

	public float moveSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
	}
}
