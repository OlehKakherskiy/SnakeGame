using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

	private GameManager gameManager;

	void Awake()
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	public void ContinueGame()
	{
		Debug.Log (gameManager);
		gameManager.ContinueGame ();
	}

	public void StartNewGame()
	{
		gameManager.NewGame ();
	}

	public void SaveAndExit()
	{
		gameManager.SaveAndExit ();
	}
}
