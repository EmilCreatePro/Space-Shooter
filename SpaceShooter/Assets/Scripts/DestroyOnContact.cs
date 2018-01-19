using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject explode_player;
	private GameController gameController;
	private GameController gameEnd;

	public int scoreValue;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController> ();
			gameEnd =  gameControllerObject.GetComponent <GameController> ();
		}

		if (gameController == null) 
		{
			Debug.Log ("Nu putem gasi script-ul 'Game Controller'");
		}

		if (gameEnd == null) 
		{
			Debug.Log ("Nu putem gasi script-ul pt Game Over in'Game Controller'");
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		gameEnd.EndGameText (false);

		if (other.tag == "Player") 
		{
			Instantiate (explode_player, other.transform.position, other.transform.rotation);
			gameEnd.EndGameText (true);
		}

		gameController.AddScore (scoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
