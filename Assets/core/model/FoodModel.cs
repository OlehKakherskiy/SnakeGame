using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class FoodModel {

	private List<Cell> foodPositions = new List<Cell>();

	public List<Cell> FoodPositions {
		get {
			return this.foodPositions;
		}
	}

	public void AddFoodPosition(int x, int y)
	{
		Cell newFoodPos = new Cell (x, y);
		Debug.Log("Adding new food position to model " + newFoodPos);
		foodPositions.Add (newFoodPos);
	}

	public void RemoveFoodPosition(int x, int y)
	{
		Cell removeFoodPos = new Cell (x, y);
		Debug.Log("Food was removed from position " + removeFoodPos +" - "+foodPositions.Remove (removeFoodPos));
	}

}