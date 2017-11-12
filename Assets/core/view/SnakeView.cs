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
		tail.ForEach (tailCell => Object.Destroy (tailCell)); //TODO: try just Destroy(GameObject)
		tail.Clear ();
	}

	public void UpdateView(Vector2 direction, bool ate) 
	{
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Move head into new direction (now there is a gap)
		transform.Translate(direction);

		if (ate) 
		{
			tail.Insert(0, CreateTailCell(v));
		}
		else if (tail.Count > 0) 
		{
			tail.Last().transform.position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

	private GameObject CreateTailCell(Vector2 v)
	{
		return (GameObject)Instantiate (tailPrefab, v, Quaternion.identity, gamePanel.transform);
	}

	public void InstantiateSnake(Vector2 head, List<Vector2> tail)
	{
		transform.position = head;
		tail.ForEach(tailCell => this.tail.Add(CreateTailCell(tailCell)));
	}
}