using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection {
	UP, DOWN, RIGHT, LEFT
}

public class SnakeController: MonoBehaviour {

	public SnakeModel Snake {
		get {
			return this.snake;
		}
		set {
			snake = value;
		}
	}

	public SnakeModel snake;
	public SnakeView snakeView;

	private MoveDirection direction;
	private bool foodWasEaten = false;

	// Use this for initialization
	public void Start () {
		snake = new SnakeModel ();
		snakeView.Start ();
		StartMoving ();
	}

	// Update is called once per frame
	void Update () {
		// Move in a new Direction?
		if (Input.GetKey (KeyCode.RightArrow))
			direction = MoveDirection.RIGHT;
		else if (Input.GetKey (KeyCode.DownArrow))
			direction = MoveDirection.DOWN;
		else if (Input.GetKey (KeyCode.LeftArrow))
			direction = MoveDirection.LEFT;
		else if (Input.GetKey (KeyCode.UpArrow))
			direction = MoveDirection.UP;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Some object was reached");
		// Food?
		if (coll.name.StartsWith("FoodPrefab")) {
			Debug.Log ("food was reached, eating...");
			foodWasEaten = true;
			Destroy(coll.gameObject);
		}
		// Collided with Tail or Border
		else {
			Debug.Log ("END");
		}
	}

	public void Move()
	{
		if (foodWasEaten) {
			Debug.Log ("food was eaten, processing update model");
			snake.IncreaseSize (direction);
			snakeView.UpdateView (ConvertDirection(direction), true);
			foodWasEaten = false;
		} else {
			snake.DoMove (direction);
			snakeView.UpdateView (ConvertDirection(direction), false);
		}
	}

	public void StartMoving()
	{
		if(!IsInvoking("Move"))
		{
			InvokeRepeating("Move", 0.3f, 0.3f);
		}
	}

	public void DisableMoving()
	{
		if (IsInvoking ("Move")) 
		{
			CancelInvoke ("Move");
		}
	}

	private Vector2 ConvertDirection(MoveDirection direction)
	{
		Vector2 d = Vector2.right;
		switch (direction) {
		case MoveDirection.UP:
			d = Vector2.up;
			break;

		case MoveDirection.DOWN:
			d = Vector2.down;
			break;

		case MoveDirection.LEFT:
			d = Vector2.left;
			break;

		case MoveDirection.RIGHT:
			d = Vector2.right;
			break;
		}
		return d;
	}
}