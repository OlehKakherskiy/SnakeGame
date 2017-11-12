using System.Collections;
using System.Collections.Generic;

public class FoodModel {

	private List<Cell> foodPositions = new List<Cell>();

	public List<Cell> FoodPositions {
		get {
			return this.foodPositions;
		}
	}

	public void AddFoodPosition(int x, int y)
	{
		foodPositions.Add (new Cell (x, y));
	}

	public void RemoveFoodPosition(int x, int y)
	{
		foodPositions.Remove (new Cell (x, y));
	}

}