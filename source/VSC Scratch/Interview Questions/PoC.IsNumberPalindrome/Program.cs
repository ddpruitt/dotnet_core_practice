﻿using System;

namespace PoC.IsNumberPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {

            var ints = new int[] {12321, 12,88,8999};

            foreach(var currentInt in ints)
            {
                System.Console.WriteLine($@"{currentInt} : {isPalindrome(currentInt)}");
            }
        }

        // A function that reurns true 
        // only if num contains one digit
        public static bool oneDigit(int num)
        {
            // comparison operation is 
            // faster than division 
            // operation. So using 
            // following instead of 
            // "return num / 10 == 0;"
            return ((num >= 0) && (num < 10));
        }

        // A recursive function to 
        // find out whether num is 
        // palindrome or not. 
        // Initially, dupNum contains
        // address of a copy of num.
        public static bool isPalUtil(int num,
                                    int dupNum)
        {
            // Base case (needed for recursion termination): This statement
            // mainly compares the first digit with the last digit
            if (oneDigit(num))
                return (num == (dupNum) % 10);

            // This is the key line in  this method. Note that 
            // all recursive calls have a separate copy of num,
            // but they all share same copy of *dupNum. We divide 
            // num while moving up the recursion tree
            if (!isPalUtil((int)(num / 10), dupNum))
                return false;

            // The following statements are executed when we move
            // up the recursion call tree
            dupNum = (int)(dupNum / 10);

            // At this point, if num%10 contains i'th digit from 
            // beiginning, then (*dupNum)%10 contains i'th digit from end
            return (num % 10 == (dupNum) % 10);
        }

        // The main function that uses recursive function isPalUtil()
        // to find out whether num is palindrome or not
        public static bool isPalindrome(int num)
        {
            // If num is negative, make it positive
            if (num < 0) num = (-num);

            // Create a separate copy of num, so that modifications 
            // made to address dupNum don't change the input number.
            int dupNum = (num); // *dupNum = num

            return isPalUtil(num, dupNum);
        }
    }
}

