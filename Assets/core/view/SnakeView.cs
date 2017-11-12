using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeView : MonoBehaviour {
	List<GameObject> tail = new List<GameObject>();
	public GameObject tailPrefab;

	public void Start() {
		tail.ForEach (tailCell => Object.Destroy (tailCell));
		tail.Clear ();
	}

	public void UpdateView(Vector2 direction, bool ate) {
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Move head into new direction (now there is a gap)
		transform.Translate(direction);

		if (ate) {
			tail.Insert(0, (GameObject) Instantiate(tailPrefab, v, Quaternion.identity));
		}
		else if (tail.Count > 0) {
			tail.Last().transform.position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

}
