using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {
	// Food Prefab
	public GameObject foodPrefab;

	public GameObject gamePanel;

	// Borders
	private Cell borderTop;
	private Cell borderBottom;
	private Cell borderLeft;
	private Cell borderRight;

	private FoodModel foodModel;

	private List<GameObject> foodList = new List<GameObject> ();

	void Awake()
	{
		borderTop = getPosition (gamePanel.transform.Find("UpBorder"));
		borderBottom = getPosition (gamePanel.transform.Find("DownBorder"));
		borderLeft = getPosition (gamePanel.transform.Find("LeftBorder"));
		borderRight = getPosition (gamePanel.transform.Find("RightBorder"));
	}
		
	public void Start () 
	{
		foodList.ForEach(foodCell => Object.Destroy(foodCell)); //TODO: simple Destroy(foodcell);
		foodList.Clear ();
		foodModel = GameObject.FindObjectOfType<GameManager> ().GameData.Food;
		preInstantiateFood ();
		StartGeneratingFood ();
	}

	public void StartGeneratingFood()
	{
		if(!IsInvoking("Spawn"))
		{
			InvokeRepeating("Spawn", 3, 4);
		}
	}

	public void StopGeneratingFood()
	{
		if(IsInvoking("Spawn"))
		{
			CancelInvoke ("Spawn");
		}
	}

	public void DestroyFood(Collider2D food)
	{
		Debug.Log ("destroying food object");
		Transform foodTransform = food.gameObject.transform;
		foodModel.RemoveFoodPosition ((int) foodTransform.position.x, (int) foodTransform.position.y);
		Destroy (food.gameObject);
	}
	

	private void Spawn() 
	{
		// x position between left & right border
		int x = (int)Random.Range(borderLeft.X + 1, borderRight.X);

		// y position between top & bottom border
		int y = (int)Random.Range(borderBottom.Y + 1, borderTop.Y);

		foodModel.AddFoodPosition (x, y);

		// Instantiate the food at (x, y)
		foodList.Add(createFoodCell(new Cell(x,y))); // default rotation
	}

	private void preInstantiateFood()
	{
		foodModel.FoodPositions.ForEach (cell => foodList.Add (createFoodCell (cell)));
	}

	private GameObject createFoodCell(Cell foodCell)
	{
		return Instantiate (foodPrefab, new Vector2 (foodCell.X, foodCell.Y), Quaternion.identity, gamePanel.transform);
	}
		

	private Cell getPosition(Transform border)
	{
		return new Cell ((int) border.position.x, (int) border.position.y);
	}
}
