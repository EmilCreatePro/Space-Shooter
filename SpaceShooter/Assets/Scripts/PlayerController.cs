using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour //inhereting from MonoBehaviour
{	
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public GameObject player;
	private float nextFire;

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GetComponent<AudioSource>().Play();
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

		Vector3 temp = new Vector3(player.transform.position.x, 0.5f, player.transform.position.z);
		player.transform.position = temp;
	}
		

	void FixedUpdate() //called before each physics step
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");

		Vector3 deviceTilt = Input.acceleration;

		//var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var rigidbody = GetComponent<Rigidbody> ();

		//rigidbody.velocity = movement * speed;

		//rigidbody.velocity = deviceTilt;

		deviceTilt = Quaternion.Euler (90, 0, 0) * deviceTilt;

		rigidbody.velocity = deviceTilt * speed;

		//rigidbody.AddForce (deviceTilt);

		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * (-tilt));
	}


}
