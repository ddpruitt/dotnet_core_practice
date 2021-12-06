<Query Kind="Statements" />

/*

Write a program that prints the numbers from 1 to 100. 

But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 

For numbers which are multiples of both three and five print “FizzBuzz”.

*/
"FizzBuzz Question".Dump();
new string('-', 80).Dump();

Enumerable.Range(1, 100)
	.Select(e =>
		((e % 3) == 0 && (e % 5) == 0) ? "FizzBuzz" :
		(e % 3) == 0 ? "Fizz" : (e % 5) == 0 ? "Buzz" : e.ToString()
	).Dump();
	
new string('-', 80).Dump();

