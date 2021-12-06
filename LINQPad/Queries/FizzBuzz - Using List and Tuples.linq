<Query Kind="Statements" />


var l = new List<(Predicate<int> IsValueUsed, Func<int, string> GetValue)>
	{
		(t => t % 15==0, t => "** FizzBuzz **"),
		(t => t % 3==0,  t => "Fizz"),
		(t => t % 5==0,  t => "Buzz"),
		(t => true,      t => t.ToString())
	};

Enumerable.Range(1, 100)
	.Select(e => l.FirstOrDefault(fb => fb.IsValueUsed(e)).GetValue(e))
	.Dump();