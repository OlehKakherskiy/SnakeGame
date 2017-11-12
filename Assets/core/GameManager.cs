using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gamePanel;
	public GameObject menuPanel;
	public GameObject gameOverPanel;
	public GameObject snake;


	// Use this for initialization
	void Awake () 
	{
		LoadGame ();
	}

	void Start()
	{
		Debug.Log ("Disable menu panel");
		menuPanel.SetActive (false);
		gameOverPanel.SetActive (false);
		snake.GetComponent<SnakeController> ().Start();
		gamePanel.GetComponent<FoodController> ().Start ();
		EnableGameActivity ();
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (gameOverPanel.activeInHierarchy) 
			{
				return;
			}
			if (menuPanel.activeInHierarchy) 
			{
				menuPanel.SetActive (false);
				EnableGameActivity ();
			} else {
				menuPanel.SetActive (true);
				DisableGameActivity ();
			}
		}
	}

	public void ContinueGame()
	{
		EnableGameActivity ();
		menuPanel.SetActive (false);
	}

	public void SaveAndExit()
	{
		Debug.Log ("Clicked Save And Exit Game");
		Application.Quit ();
	}

	public void Exit()
	{
		//TODO: remove all saved games
		Application.Quit ();
	}

	public void LoadGame()
	{
		Debug.Log ("Load game...");
	}

	public void NewGame()
	{
		Debug.Log ("Clicked New Game");
		this.Start ();
	}

	public void GameOver()
	{
		//TODO: remove saved game
		NewGame();
	}

	public void ShowGameOverPanel()
	{
		gameOverPanel.SetActive (true);
		DisableGameActivity ();
	}


	private void EnableGameActivity()
	{
		gamePanel.SetActive (true);
		snake.GetComponent<SnakeController> ().StartMoving ();
		gamePanel.GetComponent<FoodController>().StartGeneratingFood ();
	}

	private void DisableGameActivity()
	{
		gamePanel.SetActive (false);
		snake.GetComponent<SnakeController> ().DisableMoving ();
		gamePanel.GetComponent<FoodController>().StopGeneratingFood ();
	}

}
