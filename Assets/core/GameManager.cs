using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gamePanel;
	public GameObject menuPanel;
	public GameObject snake;


	// Use this for initialization
	void Awake () {
		LoadGame ();
	}

	void Start()
	{
		Debug.Log ("Disable menu panel");
		menuPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menuPanel.SetActive (!menuPanel.activeInHierarchy);
			ToggleGameStatus ();
		}
	}

	private void ToggleGameStatus()
	{
		gamePanel.SetActive (!gamePanel.activeInHierarchy);
		snake.GetComponent<SnakeController> ().ToggleMovingStatus ();
	}

	public void ContinueGame()
	{
		gamePanel.SetActive (true);
		menuPanel.SetActive (false);
		snake.GetComponent<SnakeController> ().ToggleMovingStatus ();
	}

	public void SaveAndExit(){
		Debug.Log ("Clicked Save And Exit Game");
		Application.Quit ();
	}

	public void LoadGame(){
		Debug.Log ("Load game...");
	}

	public void NewGame(){
		Debug.Log ("Clicked New Game");
	}

	public void GameOver(){
		//TODO: remove saved game
		NewGame();
	}


}
