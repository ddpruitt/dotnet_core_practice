<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
</Query>

IEnumerable<Cell> ToList(int[,] puzzle)
{
	var retList = Enumerable.Range(0, 9)
		.SelectMany(x =>
			Enumerable.Range(0, 9), (column, row) => new Cell(puzzle[row, column], column, row));

	return retList;
}

bool IsValuePossible(int[,] puzzle, int value, int row, int column)
{
	for (int i = 0; i < 9; i++)
		if (puzzle[row, i] == value) return false;

	for (int i = 0; i < 9; i++)
		if (puzzle[i, column] == value) return false;

	var x0 = (column / 3) * 3;
	var y0 = (row / 3) * 3;

	for (int i = 0; i < 3; i++)
		for (int j = 0; j < 3; j++)
			if (puzzle[y0 + i, x0 + j] == value) return false;

	return true;
}

class Cell
{
	public int Value { get; set; }

	public Point Location { get; }
	public Point Quadrant { get; }

	public List<int> PossibleValues { get; }

	public Cell(int value, int x, int y)
	{
		Location = new Point(x, y);
		Quadrant = new Point(x / 3, y / 3);

		Value = value;
		PossibleValues = new List<int>(Enumerable.Range(1, 9));
		if (value != 0) PossibleValues.RemoveAll(pv => !pv.Equals(value));
	}
}


var puzzle = new int[,]
		   {
				{5, 3, 0, 0, 7, 0, 0, 0, 0},
				{6, 0, 0, 1, 9, 5, 0, 0, 0},
				{0, 9, 8, 0, 0, 0, 0, 6, 0},
				{8, 0, 0, 0, 6, 0, 0, 0, 3},
				{4, 0, 0, 8, 0, 3, 0, 0, 1},
				{7, 0, 0, 0, 2, 0, 0, 0, 6},
				{0, 6, 0, 0, 0, 0, 2, 8, 0},
				{0, 0, 0, 4, 1, 9, 0, 0, 5},
				{0, 0, 0, 0, 8, 0, 0, 0, 0}
			};
puzzle.Dump();
puzzle[1,0].Dump();

IsValuePossible(puzzle, 6, 1, 1).Dump();

var puzzleList = Enumerable.Range(0, 9)
			.SelectMany(x =>
				Enumerable.Range(0, 9), (x, y) => new { value=puzzle[y, x], x, y});

//x.Dump();

var puzzleArryFromList = puzzleList.GroupBy(x => x.y)
	.Select(x => x.ToArray())
	.ToArray();
//puzzleArryFromList.Dump();

var p2 = new int[9,9];
for (int y = 0; y < 9; y++)
{
	for (int x = 0; x < 9; x++)
	{
		p2[y,x] = puzzleArryFromList[y][x].value;
	}
}

p2.Dump();

var p3 = from yRange in Enumerable.Range(0,9)
		 from xRange in Enumerable.Range(0,9)
			select new {yRange, xRange};
p3.Dump();