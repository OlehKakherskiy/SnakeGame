using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

	private SnakeModel snake;

	private FoodModel food;

	public SnakeModel Snake {
		get {
			return this.snake;
		}
		set {
			snake = value;
		}
	}

	public FoodModel Food {
		get {
			return this.food;
		}
		set {
			food = value;
		}
	}

	public GameData ()
	{
		snake = new SnakeModel ();
		food = new FoodModel ();
	}
}
