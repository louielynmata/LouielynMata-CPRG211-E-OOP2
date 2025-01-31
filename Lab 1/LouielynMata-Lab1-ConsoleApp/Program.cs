using System;
using System.Collections;
using System.IO;

namespace LouielynMata_Lab1_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string separator = "\n----------------------------";

            // Task 1: Creating Variables
            Console.WriteLine("Task 1: Creating Variables through Difference Calculator\n");

            // Entering & Validating Number Inputs
            double lowNumber = GetValidNumber("Enter first lower number: ");
            double highNumber = GetValidNumber("Enter second higher number: ");

            // Calculate the sum of both numbers & Display
            double diffNumber = highNumber - lowNumber;
            Console.WriteLine("The difference of " + lowNumber + " and " + highNumber + " is " + diffNumber);

            // Task 2: Looping and Input Validation

            Console.WriteLine(separator);
            Console.WriteLine("\nTask 2: Looping and Input Validation\n");


            // Entering & Validating Number Inputs
            string EnterNumber = "Enter a number: ";
            string continueEnter = "Enter a number lower to continue reiterating.";

            double loopNumber = GetValidNumber(EnterNumber); 
            double highLoopNumber = loopNumber;


            while (loopNumber > 0 || loopNumber > highLoopNumber)
            {
                Console.WriteLine(continueEnter);
                Console.Write(EnterNumber);
                highLoopNumber = Convert.ToInt32(Console.ReadLine());

                if (highLoopNumber > loopNumber)
                {
                    break;
                }
            }

            Console.WriteLine("You entered a higher loop number. Terminating loop.");

            // Task 3: Using Arrays and File I/O

            Console.WriteLine(separator);
            Console.WriteLine("\nTask 3: Using Arrays and File I/O\n");

            // Entering & Validating Number Inputs
            double lowArrayNumber = GetValidNumber("Enter first lower number: ");
            double highArrayNumber = GetValidNumber("Enter second high number: ");

            // Setting up an aray based on the difference of the number.
            int size = Convert.ToInt32(highArrayNumber - lowArrayNumber + 1);
            int[] numberArray = new int[size];

            // Getting the number between the lower number and higher number.
            for (int i = 0; i < size; i++)
            {
                numberArray[i] = Convert.ToInt32(lowArrayNumber) + i;
            }

            // Printing each number.
            Console.WriteLine(separator);
            Console.WriteLine($"Printing the array\n");
            foreach (int i in numberArray)
            {
                Console.WriteLine(i);
            }


            // Sorting the Array first through Sort, then reversing it.
            Array.Sort(numberArray);
            Array.Reverse(numberArray);

            // WRITING TO A FILE - "numbers.txt"

            // Set a variable to the My Documents path.
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "numbers.txt")))
            {
                foreach (int line in numberArray)
                    outputFile.WriteLine(line);
            }


            // READING & PRINTING THE TEXT FILE (Additional Task)

            Console.WriteLine(separator);
            Console.WriteLine("Printing the FILE\n");
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(Path.Combine(docPath, "numbers.txt"));
            //Read the first line of text
            string lines = sr.ReadLine();
            //Continue to read until you reach end of file
            while (lines != null)
            {
                //write the line to console window
                Console.WriteLine(lines);
                //Read the next line
                lines = sr.ReadLine();
            }

            //close the file
            sr.Close();
            Console.ReadLine();


            // METHOD - to Get a Valid Number from User Input (Additional Task)
            static double GetValidNumber(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (ValidateNumber(input))
                    {
                        return Convert.ToDouble(input);
                    }

                    Console.WriteLine("Invalid number. Please enter a valid numeric value.");
                }
            }


            // METHOD - Validate if a String is a Valid Number (Additional Task)
            static bool ValidateNumber(string number)
            {
                bool hasDecimal = false;

                if (string.IsNullOrWhiteSpace(number))
                    return false;

                if (number[0] == '-')
                    number = number.Substring(1);

                foreach (char i in number)
                {
                    if (!char.IsDigit(i))
                    {
                        return false;
                    }
                }

                return true;
            }


        }
    }
}