using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeView : MonoBehaviour {
	List<Transform> tail = new List<Transform>();
	public GameObject tailPrefab;

	void Start() {
		tail.Clear ();
	}

	public void UpdateView(Vector2 direction, bool ate) {
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Move head into new direction (now there is a gap)
		transform.Translate(direction);

		if (ate) {
			// Load Prefab into the world
			GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
			tail.Insert(0, g.transform);
		}
		else if (tail.Count > 0) {
			tail.Last().position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

}
