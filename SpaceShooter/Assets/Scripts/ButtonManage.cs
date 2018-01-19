using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // this is needed to load another level
using UnityEngine.UI;

public class ButtonManage : MonoBehaviour 
{

	public GameObject quitMenu;
	public GameObject creditsWindow;
	public GameObject instrMenu;

	void Start()
	{
		quitMenu.SetActive (false);
		creditsWindow.SetActive (false);
		instrMenu.SetActive (false);
	}
	public void startGame()
	{
		//SceneManager.LoadScene (levelName);
		GetComponent<AudioSource>().Play();
		instrMenu.SetActive (true);
	}

	public void OkStartGame(string levelName)
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene (levelName);
		//instrMenu.SetActive (true);
	}

	public void ExitGame()

	{
		//Application.Quit ();
		//Debug.Log ("You've sucssesfully quited the game!");
		GetComponent<AudioSource>().Play();
		quitMenu.SetActive(true);
	}

	public void NoOption()
	{
		GetComponent<AudioSource>().Play();
		quitMenu.SetActive (false);
	}

	public void YesOption()
	{
		GetComponent<AudioSource>().Play();
		Application.Quit ();
		Debug.Log ("You've sucssesfully quited the game!");
	}

	public void CreditsMenu()
	{
		GetComponent<AudioSource>().Play();
		creditsWindow.SetActive (true);
	}

	public void bckOption()
	{
		GetComponent<AudioSource>().Play();
		creditsWindow.SetActive (false);
	}
}
