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
		foodList.ForEach(foodCell => Object.Destroy(foodCell));
		foodList.Clear ();
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
	

	private void Spawn() 
	{
		// x position between left & right border
		int x = (int)Random.Range(borderLeft.X, borderRight.X);

		// y position between top & bottom border
		int y = (int)Random.Range(borderBottom.Y, borderTop.Y);

		// Instantiate the food at (x, y)
		foodList.Add(Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity, gamePanel.transform)); // default rotation
	}
		

	private Cell getPosition(Transform border)
	{
		return new Cell ((int) border.position.x, (int) border.position.y);
	}
}
