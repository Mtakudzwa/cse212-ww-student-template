using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of size 'length'.
        // 2. Use a loop to populate the array.
        // 3. Start with the given number and calculate its multiples by multiplying it with the loop index.
        // 4. Return the populated array.

        // Step 1: Create an array to store the multiples
        double[] multiples = new double[length];

        // Step 2: Use a loop to populate the array
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple by multiplying the number with (i + 1)
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the populated array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3, 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// 
    /// This function modifies the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Calculate the effective number of rotations by taking amount % data.Count.
        //    This ensures we don't rotate more than necessary (e.g., rotating 10 times on a list of size 9).
        // 2. Split the list into two parts: the last 'rotations' elements and the rest of the list.
        // 3. Clear the original list.
        // 4. Add the last 'rotations' elements to the front of the list.
        // 5. Add the rest of the list after the rotated elements.

        // Step 1: Calculate the effective number of rotations
        int rotations = amount % data.Count;

        // Step 2: Split the list into two parts
        List<int> tail = data.GetRange(data.Count - rotations, rotations); // Last 'rotations' elements
        List<int> head = data.GetRange(0, data.Count - rotations); // Remaining elements

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the last 'rotations' elements to the front
        data.AddRange(tail);

        // Step 5: Add the remaining elements
        data.AddRange(head);
    }

    // Test Cases (Example usage)
    public static void Main(string[] args)
    {
        // Testing MultiplesOf
        double[] result = MultiplesOf(3, 5); // Expected: {3, 6, 9, 12, 15}
        Console.WriteLine("MultiplesOf(3, 5): " + string.Join(", ", result));

        // Testing RotateListRight
        List<int> data = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
        RotateListRight(data, 3); // Expected: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        Console.WriteLine("RotateListRight (3): " + string.Join(", ", data));

        data = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
        RotateListRight(data, 5); // Expected: {5, 6, 7, 8, 9, 1, 2, 3, 4}
        Console.WriteLine("RotateListRight (5): " + string.Join(", ", data));
    }
}
