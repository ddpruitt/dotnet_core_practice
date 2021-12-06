<Query Kind="Statements" />

Enumerable.Range(1, 100)
	.Select(e => {
		if( (e % 3)== 0 && (e% 5)==0) return "FizzBuzz"; 
		if( (e % 3)==0 ) return "Fizz";
		if( (e% 5)==0) return "Buzz";
		return e.ToString();
	}).Dump();


Enumerable.Range(1, 100)
	.Select(e =>
		((e % 3) == 0 && (e % 5) == 0)  ?	"FizzBuzz" :
		(e % 3) == 0 ? "Fizz" : (e % 5) == 0 ? "Buzz" : e.ToString()
	).Dump();


Enumerable.Range(1, 100)
	.Select(e =>
		(e % 15) == 0 ? "FizzBuzz" :
		(e % 3) == 0  ? "Fizz" : 
		(e % 5) == 0  ? "Buzz" : 
		e.ToString()
	).Dump();