using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class FoodModel {

	private HashSet<Cell> foodPositions = new HashSet<Cell>();

	private List<Cell> persistableFoodPositions = new List<Cell>();

	public List<Cell> FoodPositions {
		get {
			return new List<Cell> (this.foodPositions);
		}
	}

	public void AddFoodPosition(int x, int y)
	{
		Cell newFoodPos = new Cell (x, y);
		Debug.Log("Adding new food position to model " + newFoodPos);
		foodPositions.Add (newFoodPos);
	}

	public void ConvertFoodPositionsToPersist() {
		persistableFoodPositions = new List<Cell> (foodPositions);
		foodPositions.Clear ();
		foodPositions = null;
	}

	public void ConvertFoodPositionsToPerform() {
		foodPositions = new HashSet<Cell> (persistableFoodPositions);
		persistableFoodPositions.Clear();
		persistableFoodPositions = null;
	}

	public void RemoveFoodPosition(int x, int y)
	{
		List<Cell> removePositions = new List<Cell> ();
		removePositions.Add (new Cell (x, y));
		removePositions.Add (new Cell (x, y - 1));
		removePositions.Add (new Cell (x, y + 1));
		removePositions.Add (new Cell (x - 1, y));
		removePositions.Add (new Cell (x - 1, y - 1));
		removePositions.Add (new Cell (x - 1, y + 1));
		removePositions.Add (new Cell (x + 1, y));
		removePositions.Add (new Cell (x + 1, y - 1));
		removePositions.Add (new Cell (x + 1, y + 1));
		foreach (Cell possibleRemovePos in removePositions) {
			if (foodPositions.Remove (possibleRemovePos)) {
				Debug.Log ("Food was removed from position " + possibleRemovePos);
				break;
			}
		}
	}

}