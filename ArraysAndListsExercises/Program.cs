﻿using System;
using System.Collections.Generic;

namespace ArraysAndListsExercises
{
    internal class Program
    {
        private static void Main()
        {
            Exercise4();
        }

        private static void Exercise1()
        {
            /* When you post a message on Facebook, depending on the number of people who like your post, Facebook displays
             * different information.
             * If no one likes your post, it doesn't display anything.
             * If only one person likes your post, it displays: [Friend's Name] likes your post.
             * If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
             * If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People]
             * others like your post.
             * Write a program and continuously ask the user to enter different names, until the user presses Enter
             * (without supplying a name). Depending on the number of names provided, display a message based on the above
             * pattern.
             */
            var names = new List<string>();
            while (true) {
                Console.Write("Enter a name or press enter to finish: ");
                var input = Console.ReadLine();
                if (input == string.Empty) break;
                names.Add(input);
            }


            switch (names.Count)
            {
                case 0: break;
                case 1:
                    Console.WriteLine($"{names[0]} likes your post.");
                    break;
                case 2:
                    Console.WriteLine($"{names[0]} and {names[1]} like your post.");
                    break;
                default:
                    Console.WriteLine($"{names[0]}, {names[1]}, and {names.Count - 2} others like your post.");
                    break;
            }

        }

        private static void Exercise2()
        {
            /* Write a program and ask the user to enter their name. Use an array to reverse the name and then store the
             * result in a new string. Display the reversed name on the console.
             */

            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            var nameChars = name.ToCharArray();
            
            Array.Reverse(nameChars);

            var newName = new string(nameChars);
            Console.WriteLine($"{newName}");
        }

        private static void Exercise3()
        {
            /* Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an
             * error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and
             * display the result on the console.
             */

            var numbers = new int[5];

            Console.WriteLine("Please enter five unique numbers.");
            for (var i = 0; i < 5; i++)
            {
                Console.Write("Enter a number: ");
                var number = Convert.ToInt32(Console.ReadLine());
                while (Array.Exists(numbers, num => num == number))
                {
                    Console.WriteLine($"{number} has already been entered");
                    Console.Write("Enter a number: ");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                numbers[i] = number;
            }

            Array.Sort(numbers);
            foreach (var number in numbers)
                Console.Write(number);
            Console.WriteLine();
        }

        private static void Exercise4()
        {
            /* Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers
             * may include duplicates. Display the unique numbers that the user has entered.
             */

            var numbers = new HashSet<int>();

            while (true)
            {
                Console.Write("Enter a number or \"Quit\" to exit: ");
                var input = Console.ReadLine();
                if (input == "Quit")
                    break;
                numbers.Add(Convert.ToInt32(input));
            }
            
            Console.WriteLine($"You entered the following {numbers.Count} unique numbers");
            foreach (var number in numbers)
                Console.Write(number);
            Console.WriteLine();
        }
    }
}