﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;

	void Start ()
	{
		Rigidbody rb;
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}

	/*
	void Update()
	{
		transform.Rotate (Vector3.right * Time.deltaTime * tumble, Space.World);
	}
	*/
}
