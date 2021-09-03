<Query Kind="Statements" />


var l = GetListOfFizzBuzzers();
Enumerable.Range(1, 100)
	.Select(e => l.FirstOrDefault(fb => fb.IsValueUsed(e)).GetValue(e))
	.Dump();


List<FizzBuzzer<int, string>> GetListOfFizzBuzzers()
{
	var list = new List<FizzBuzzer<int, string>>
	{
		new FizzBuzzer<int,string> 
		{
			IsValueUsed = t=> t % 15==0, // The number is a multiple of 3 && 5
			GetValue = t => "** FizzBuzz **"
		},
		new FizzBuzzer<int,string>
		{
			IsValueUsed = t=> t % 3==0,
			GetValue = t => "Fizz"
		},
		new FizzBuzzer<int,string>
		{
			IsValueUsed = t=> t % 5==0,
			GetValue = t => "Buzz"
		},
		new FizzBuzzer<int,string>
		{
			IsValueUsed = t=> true,
			GetValue = t => t.ToString()
		}
	};

	return list;
}

class FizzBuzzer<T, U>
{
	public Predicate<T> IsValueUsed { get; set; }
	public Func<T, U> GetValue { get; set; }
}