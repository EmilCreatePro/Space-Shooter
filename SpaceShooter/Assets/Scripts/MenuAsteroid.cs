using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroid : MonoBehaviour {


	public GameObject hazard;
	public Vector3 spawnValues;
	public float spawnWait;

	void Start ()
	{
		StartCoroutine ( SpawnWaves() );
	}
		
	

	IEnumerator SpawnWaves()
	{
		while(true)
		{
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}

	}
}
