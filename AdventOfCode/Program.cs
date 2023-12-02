// Date     : 12/01/2023
// Author   @ Joe Centeno

// FileName     : AdventDay1P1  
/* Problem Desc : 
The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
*/

// Input  : A string with at least one starting int and one ending int
// Output : The first and last int in the string combined to repersent a number.
// Data Structure : 

// Test Cases : 
/*
1abc2       -> 12
pqr3stu8vwx -> 38
a1b2c3d4e5f -> 15 
treb7uchet  -> 77
 */

// Algorithm : 
// First make a helper function to read in file
// Read in file
// Inilize a var to store current total number
// loop over each line, find starting and ending int
// make number from those ints
// add together all ints to get number

// Code :

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<string> ReadFileIntoList(string filePath)
    {
        try
        {
            // Read all lines of the file into an array
            string[] lines = File.ReadAllLines(filePath);

            // Convert the array to a list and return
            return new List<string>(lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return new List<string>(); // Return an empty list in case of an error
        }
    }

    static int? ExtractAndCombineDigits(string line)
    {
        var digits = line.Where(char.IsDigit).ToArray();

        if (digits.Length >= 2)
        {
            // Convert first and last digit to a string and then to an integer
            string combined = $"{digits.First()}{digits.Last()}";
            return int.Parse(combined);
        }

        if(digits.Length == 1)
        {
            string combined = $"{digits[0]}{digits[0]}";
            return int.Parse(combined);
        }

        return null;
    }

    static public void DayOnePOne()
    {
        string filePath = "/Users/joe/Projects/AdventOfCode/AdventOfCode/Day1P1Input.txt";
        List<string> lines = ReadFileIntoList(filePath);

        int total = 0;

        foreach (string line in lines)
        {
            int? combinedNumber = ExtractAndCombineDigits(line);

            if (combinedNumber.HasValue)
            {
                total += combinedNumber.Value;
            }
        }

        Console.WriteLine($"Total sum of combined numbers: {total}");
    }

    static void Main(string[] args)
    {
        DayOnePOne();
    }
}
