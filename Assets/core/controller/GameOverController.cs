using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	private GameManager gameManager;

	void Awake()
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	public void NewGame()
	{
		gameManager.NewGame ();
	}

	public void ExitGame()
	{
		gameManager.Exit ();
	}
}
