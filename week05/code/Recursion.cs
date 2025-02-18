using System;
using System.Collections.Generic;

class Program
{
    // Problem 1: Recursive Squares Sum
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations Choose
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters.Remove(i, 1), size, word + letters[i]);
        }
    }

    // Problem 3: Sum of the Digits (Recursive)
    public static int SumDigitsRecursive(int n)
    {
        if (n == 0)
            return 0;
        return (n % 10) + SumDigitsRecursive(n / 10);
    }

    // Problem 4: Reverse a String (Recursive)
    public static string ReverseStringRecursive(string s)
    {
        if (s.Length <= 1)
            return s;
        return s[s.Length - 1] + ReverseStringRecursive(s.Substring(0, s.Length - 1));
    }

    // Problem 5: Recursive Palindrome Check
    public static bool IsPalindromeRecursive(string s)
    {
        if (s.Length <= 1)
            return true;
        if (s[0] != s[s.Length - 1])
            return false;
        return IsPalindromeRecursive(s.Substring(1, s.Length - 2));
    }

    static void Main()
    {
        // Testing Problem 1
        Console.WriteLine("Sum of squares (5): " + SumSquaresRecursive(5)); // Output: 55
        
        // Testing Problem 2
        List<string> results = new List<string>();
        PermutationsChoose(results, "abc", 2);
        Console.WriteLine("Permutations of size 2 from 'abc': " + string.Join(", ", results));
        
        // Testing Problem 3
        Console.WriteLine("Sum of digits (1234): " + SumDigitsRecursive(1234)); // Output: 10
        
        // Testing Problem 4
        Console.WriteLine("Reverse of 'hello': " + ReverseStringRecursive("hello")); // Output: "olleh"
        
        // Testing Problem 5
        Console.WriteLine("Is 'racecar' a palindrome?: " + IsPalindromeRecursive("racecar")); // Output: True
        Console.WriteLine("Is 'hello' a palindrome?: " + IsPalindromeRecursive("hello")); // Output: False
    }
}
