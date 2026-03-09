
using UnityEngine;
public class BasicScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello, Unity!");
    }

    void Update()
    {
        // This method is called once per frame
    }
}



# Check if a number is odd
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 != 0)
        {
            Console.WriteLine($"{number} is an odd number.");
        }
        else
        {
            Console.WriteLine($"{number} is not an odd number.");
        }
    }
}

#check odd/even number without input
using System;
class Program
{
    static void Main()
    {
        int number = 10; 

        if (number % 2 != 0)
        {
            Console.WriteLine($"{number} is an odd number.");
        }
        else
        {
            Console.WriteLine($"{number} is an even number.");
        }
    }
}

#using switch case to check student grade
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the student's grade (A, B, C, D, F):");
        char grade = Convert.ToChar(Console.ReadLine().ToUpper());

        switch (grade)
        {
            case 'A':
                Console.WriteLine("Excellent!");
                break;
            case 'B':
                Console.WriteLine("Good job!");
                break;
            case 'C':
                Console.WriteLine("You passed.");
                break;
            case 'D':
                Console.WriteLine("You need to improve.");
                break;
            case 'F':
                Console.WriteLine("You failed.");
                break;
            default:
                Console.WriteLine("Invalid grade entered.");
                break;
        }
    }
}

#using switch case to give student grade
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the student's score (0-100):");
        int score = Convert.ToInt32(Console.ReadLine());
        char grade;

        switch (score / 10)
        {
            case 10:
            case 9:
                grade = 'A';
                break;
            case 8:
                grade = 'B';
                break;
            case 7:
                grade = 'C';
                break;
            case 6:
                grade = 'D';
                break;
            default:
                grade = 'F';
                break;
        }

        Console.WriteLine($"The student's grade is: {grade}");
    }
}

#using for loop to find sum of n numbers
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer:");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        Console.WriteLine($"The sum of the first {n} numbers is: {sum}");
    }
}

#using while loop to find the sum of all even numbers in a given range
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the start of the range:");
        int start = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the end of the range:");
        int end = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int current = start;

        while (current <= end)
        {
            if (current % 2 == 0)
            {
                sum += current;
            }
            current++;
        }

        Console.WriteLine($"The sum of all even numbers between {start} and {end} is: {sum}");
    }
}

