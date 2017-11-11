using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeModel {

	private static readonly int SECOND_POS = 1;

	private List<Cell> snakeCells;

	private MoveDirection direction;

	public MoveDirection Direction {
		get {
			return this.direction;
		}
		set {
			direction = value;
		}
	}

	public SnakeModel ()
	{
		snakeCells = new List<Cell> ();
		snakeCells.Add (new Cell (0, 0));
		Direction = MoveDirection.RIGHT;
	}

	public void IncreaseSize(MoveDirection direction)
	{
		Cell tail = snakeCells.Last ();
		Cell newCell = new Cell (tail.X, tail.Y);
		snakeCells.Add (newCell);
		DoMove (direction);
	}

	private Cell getHead() {
		return snakeCells.First ();
	}

	public void DoMove(MoveDirection direction)
	{
		Cell head = getHead ();

		Move (snakeCells.Last (), head.X, head.Y, getTailPosition(), SECOND_POS);

		switch (direction) {
		case MoveDirection.UP:
			head.Y += 1;
			break;

		case MoveDirection.DOWN:
			head.Y -= 1;
			break;

		case MoveDirection.RIGHT:
			head.X += 1;
			break;

		case MoveDirection.LEFT: 
			head.X -= 1;
			break;
		}
	}

	private void Move(Cell c, int newX, int newY, int posFrom, int posTo)
	{
		c.X = newX;
		c.Y = newY;
		snakeCells.Insert (posTo, c);
		snakeCells.RemoveAt (posFrom);
	}

	private int getTailPosition() {
		return snakeCells.Count - 1;
	}
}
