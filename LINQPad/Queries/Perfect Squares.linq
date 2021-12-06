<Query Kind="Statements" />

/*

Determine if each number over a range of integers, from x to y, for example, is a perfect square or not.

A perfect square (also called a square number) is an integer that is the square of an integer; in other 
words, it is the product of some integer with itself. So, for example, 9 is a square number, since it 
can be written as 3 × 3. So are 16, 25, 36, 49 and so on.

So, if x happens to be 10 and y happens to have a value of 100, the goal of this exercise is to determine 
which numbers between 10 and 100 are perfect squares and which are not.

*/

Enumerable.Range(10, 100 - 10 + 1)
	.Select(e => new { e, x = Math.Sqrt(e) })
	.Where(ex => Math.Ceiling(ex.x) == Math.Floor(ex.x))
	.Dump();