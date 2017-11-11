public class Cell {
	private int x;
	private int y;

	public int X {
		get {
			return this.x;
		}
		set {
			x = value;
		}
	}

	public int Y {
		get {
			return this.y;
		}
		set {
			y = value;
		}
	}

	public Cell (int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}
