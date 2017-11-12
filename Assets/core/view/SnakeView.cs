using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeView : MonoBehaviour {
	public GameObject tailPrefab;
	public GameObject gamePanel;

	private List<GameObject> tail = new List<GameObject>();

	public void Start() 
	{
		tail.ForEach (tailCell => Object.Destroy (tailCell));
		tail.Clear ();
		transform.Translate (-transform.position);
	}

	public void UpdateView(Vector2 direction, bool ate) 
	{
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Move head into new direction (now there is a gap)
		transform.Translate(direction);

		if (ate) 
		{
			tail.Insert(0, (GameObject) Instantiate(tailPrefab, v, Quaternion.identity, gamePanel.transform));
		}
		else if (tail.Count > 0) 
		{
			tail.Last().transform.position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}
}