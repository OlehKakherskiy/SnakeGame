using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
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
	public GameObject gamePanel;
	private FoodController foodController;

	private MoveDirection direction;
	private bool foodWasEaten = false;
	private GameManager gameManager;

	void Awake()
	{
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	// Use this for initialization
	public void Start () 
	{
		snake = gameManager.GameData.Snake;
		foodController = gamePanel.GetComponent<FoodController> ();
		snakeView.Start ();
		InstantiateSnake ();
		direction = snake.Direction;
		StartMoving ();
	}

	private void InstantiateSnake()
	{
		List<Vector2> SnakePos = new List<Vector2> ();
		Snake.SnakeCells.ForEach (cell => SnakePos.Add (convertCell (cell)));
		Vector2 head = SnakePos.First ();
		SnakePos.RemoveAt (0);
		snakeView.InstantiateSnake (head, SnakePos);
	}

	private Vector2 convertCell(Cell cell)
	{
		return new Vector2 (cell.X, cell.Y);
	}

	// Update is called once per frame
	void Update () 
	{
		MoveDirection newDirection = this.direction;
		if (Input.GetKey (KeyCode.RightArrow))
			newDirection = MoveDirection.RIGHT;
		else if (Input.GetKey (KeyCode.DownArrow))
			newDirection = MoveDirection.DOWN;
		else if (Input.GetKey (KeyCode.LeftArrow))
			newDirection = MoveDirection.LEFT;
		else if (Input.GetKey (KeyCode.UpArrow))
			newDirection = MoveDirection.UP;
		if (moveInOppositeDirection (direction, newDirection)) 
		{
			gameManager.ShowGameOverPanel ();
		} else {
			direction = newDirection;
			snake.Direction = direction;
		}
	}

	private bool moveInOppositeDirection(MoveDirection oldDirection, MoveDirection newDirection)
	{
		bool moveInOppositeDirection = false;
		switch (newDirection) 
		{
		case MoveDirection.UP:
			moveInOppositeDirection = oldDirection == MoveDirection.DOWN;
			break;
		case MoveDirection.DOWN:
			moveInOppositeDirection = oldDirection == MoveDirection.UP;
			break;
		case MoveDirection.LEFT:
			moveInOppositeDirection = oldDirection == MoveDirection.RIGHT;
			break;
		case MoveDirection.RIGHT:
			moveInOppositeDirection = oldDirection == MoveDirection.LEFT;
			break;
		}
		return moveInOppositeDirection;
	}

	void OnTriggerEnter2D(Collider2D coll) 
	{
		Debug.Log ("Some object was reached");
		// Food?
		if (coll.name.StartsWith("FoodPrefab")) 
		{
			Debug.Log ("food was reached, eating...");
			foodWasEaten = true;
			Debug.Log (foodController);
			foodController.DestroyFood (coll);
		} else {
			gameManager.ShowGameOverPanel ();
		}
	}

	public void Move()
	{
		if (foodWasEaten) 
		{
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
		switch (direction) 
		{
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