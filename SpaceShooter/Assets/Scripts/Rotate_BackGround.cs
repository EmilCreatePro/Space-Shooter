using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_BackGround : MonoBehaviour 
{

	public float rotateRate;

	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotateRate, Space.World);	
	}
}
