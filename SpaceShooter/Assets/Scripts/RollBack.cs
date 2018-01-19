using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBack : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 offset = new Vector3 (Time.time * speed ,0 , 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
