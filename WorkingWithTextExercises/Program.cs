﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithTextExercises
{
    /* Note: For all these exercises, ignore input validation unless otherwise specified. Assume the user provides input in
     * the format that the program expects.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise4();
        }

        private static void Exercise1()
        {
            /* Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are
             * consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message:
             * "Consecutive"; otherwise, display "Not Consecutive".
             */

            Console.Write("Enter a few numbers separated by a hyphen: ");
            var numbers = Array.ConvertAll(Console.ReadLine().Split('-'), Convert.ToInt32);
            var modifier = numbers[0] < numbers[1] ? (short)1 : (short)-1;

            for (byte i = 0; i < numbers.Length - 1; i++)
            {
                var num = numbers[i];
                var nextNum = numbers[i + 1];
                if (num + modifier == nextNum) continue;
                Console.WriteLine("Not Consecutive");
                return;
            }
            Console.WriteLine("Consecutive");
        }

        private static void Exercise2()
        {
            /* Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply presses
             * Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so,
             * display "Duplicate" on the console.
             */
            Console.Write("Enter a few numbers separated by a hyphen: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;
            var numbers = Array.ConvertAll(input.Split('-'), Convert.ToInt32);
            var seen = new HashSet<int>();

            foreach (var number in numbers)
            {
                if (seen.Contains(number))
                {
                    Console.WriteLine("Duplicate");
                    return;
                }

                seen.Add(number);
            }
        }

        private static void Exercise3()
        {
            /* Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). A valid
             * time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid
             * Time". If the user doesn't provide any values, consider it as invalid time.
             */
            Console.Write("Enter a time value in the 24-hour time format (e.g. 19:00): ");
            Console.WriteLine(DateTime.TryParse(Console.ReadLine(), out var _) ? "Ok" : "Invalid Time");
        }

        private static void Exercise4()
        {
            /* Write a program and ask the user to enter a few words separated by a space. Use the words to create a
             * variable name with PascalCase. For example, if the user types: "number of students", display
             * "NumberOfStudents". Make sure that the program is not dependent on the input. So, if the user types "NUMBER OF
             * STUDENTS", the program should still display "NumberOfStudents".
             */
            Console.Write("Enter a few word separated by a space: ");
            var words = Console.ReadLine().Split(' ');
            var pascalCase = new StringBuilder();
            foreach (var word in words)
            {
                pascalCase.Append(char.ToUpper(word[0]))
                          .Append(word.Substring(1).ToLower());
            }

            Console.WriteLine(pascalCase);
        }
    }
}