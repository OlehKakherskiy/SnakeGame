using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gamePanel;
	public GameObject menuPanel;
	public GameObject gameOverPanel;
	public GameObject snake;

	private GameProceedingStrategy gameProceedingStrategy;
	private GameData gameData;

	public GameData GameData {
		get {
			return this.gameData;
		}
	}


	// Use this for initialization
	void Awake () 
	{
		gameProceedingStrategy = new FileGameProceedStrategy ();
		LoadGame ();
	}

	void Start()
	{
		//enable only game panel
		menuPanel.SetActive (false);
		gameOverPanel.SetActive (false);
		gamePanel.SetActive (true);

		//reset game data - starting from scratch
		//gameData = new GameData ();
		snake.GetComponent<SnakeController> ().Start();
		gamePanel.GetComponent<FoodController> ().Start ();

		//start game
		EnableGameActivity ();

		Debug.Log ("New game started");
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (gameOverPanel.activeInHierarchy) 
			{
				//ignore escape on game over panel
				return;
			}
			if (menuPanel.activeInHierarchy) 
			{
				//continue game
				menuPanel.SetActive (false);
				EnableGameActivity ();
				Debug.Log ("continue game after pause");
			} else {
				//pause game
				menuPanel.SetActive (true);
				DisableGameActivity ();
				Debug.Log ("pause game");
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
		Debug.Log ("Clicked save and exit game");
		gameData.Food.ConvertFoodPositionsToPersist ();
		gameProceedingStrategy.Save (gameData);
		Application.Quit ();
	}

	public void Exit()
	{
		Debug.Log ("Clicked exit game without saving");
		gameProceedingStrategy.RemoveSavedGame ();
		Application.Quit ();
	}

	public void LoadGame()
	{
		gameData = gameProceedingStrategy.Load ();
		gameData.Food.ConvertFoodPositionsToPerform ();
	}

	public void NewGame()
	{
		gameProceedingStrategy.RemoveSavedGame ();
		gameData = new GameData ();
		this.Start ();
	}

	public void GameOver()
	{
		Debug.Log ("Game is over");
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
