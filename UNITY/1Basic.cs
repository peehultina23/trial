New 2D project > Game Object > 2D object > Sprites > Circle
Add component > new script


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

#sakina code
//using if else statement to find whether the no is odd or not

using UnityEngine;
public class practical: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        evennum();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void evennum()
    {
        int number = 2;
        if(number % 2 == 0)
        {
            Debug.Log(number + " is Even");
        }
        else
        {
            Debug.Log(number + " is Odd");
        }
    }
}

// using switch acse to calculate grade of student

using UnityEngine;
public class practical: MonoBehaviour
{
    void Start()
    {
        switchc();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void switchc()
    {
        int marks = 85;
        char grade;
        switch(marks)
        {
            case int m when(m >= 90):
                grade = 'A';
                break;
            case int m when(m >= 80):
                grade = 'B';
                break;
            case int m when(m >= 70):
                grade = 'C';
                break;
            case int m when(m >= 60):
                grade = 'D';
                break;
            default:
                grade = 'F';
                break;
        }
        Debug.Log("Grade: " + grade);
    }
}

//using for loop find sum of n numbers

using UnityEngine;
public class practical: MonoBehaviour
{
    // Start is called once before the first execution of Update
    void Start()
    {
        forloo();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void forloo()
    {
        int n = 5;
        int sum = 0;
        for(int i = 1; i <= n; i++)
        {
            sum += i;
        }
        Debug.Log("Sum of first " + n + " numbers = " + sum);
    }
}

// using while loop to find sum of all even number in a given range

using UnityEngine;
public class practical: MonoBehaviour
{
    // Start is called once before the first execution of Update
    void Start()
    {
        whileloo();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void whileloo()
    {
        int limit = 50;
        int sumEven = 0;
        int i = 0;
        while(i <= limit)
        {
            if(i % 2 == 0)
            {
                sumEven += i;
            }
            i++;
        }
        Debug.Log("Sum of all even numbers from 0 to 50 = " + sumEven);
    }
}