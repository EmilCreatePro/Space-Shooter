using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // we need this to reload the scene

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public GameObject gameOverMenu;
	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float showRoundWait;

	public GUIText scoreText;
	//public GUIText restartText;
	public Text GameOverText;
	public Text RoundText;


	private int score;
	private int round;
	//private bool restart;
	private bool gameOver;


	void Start()
	{
		score = 0;
		round = 1;
		//restart = false;
		gameOver = false;
		gameOverMenu.SetActive (false);
		//restartText.text = "";
		UpdateScore ();
		GameOverText.text = "";
		RoundText.text = "";
		//StartCoroutine ( PrintRound () );
		StartCoroutine (SpawnWaves () );
	}

	void Update() // use Update to wait for the user to give an input key
	{
		/*
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				//Application.LoadLevel (Application.loadedLevel); // restart the level
				SceneManager.LoadScene("Main");

			}
		}

		if (Input.GetKey(KeyCode.Escape)) 
		{
			SceneManager.LoadScene("StartMenu");
		}
		*/
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(!gameOver)
		{
			StartCoroutine ( PrintRound() );
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			/*
			if (gameOver) 
			{
				restartText.text = "Press 'R' to restart";
				restart = true;
			}
			*/
			yield return new WaitForSeconds (waveWait); //wait for another wave
		}
			
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

	}

	public void EndGameText(bool isGameDone)
	{
		if (isGameDone) 
		{
			GameOverText.text = "Game Over!";
			gameOver = true;
			gameOverMenu.SetActive (true);
		}

	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
		
	IEnumerator PrintRound()
	{
		RoundText.text = "Round " + round;
		yield return new WaitForSeconds (showRoundWait);
		RoundText.text = "";
		round++;
	}

	public void RestartBtn()
	{
		SceneManager.LoadScene("Main");
	}

	public void ExitBtn()
	{
		SceneManager.LoadScene("StartMenu");
	}
}
