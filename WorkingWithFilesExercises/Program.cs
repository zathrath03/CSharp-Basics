﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithFilesExercises
{
    internal class Program
    {
        private const string Path = @"..\..\LoremIpsum.txt";
        static void Main(string[] args)
        {
            Exercise2();
        }

        static void Exercise1()
        {
            // Write a program that reads a text file and displays the number of words.
            Console.WriteLine(File.ReadAllText(Path).Split(' ').Length);
        }

        static void Exercise2()
        {
            // Write a program that reads a text file and displays the longest word in the file.
            var maxLength = 0;
            var longestWord = "";
            var words = File.ReadAllText(Path).Split(' ');

            foreach (var word in words)
            {
                if (word.Length <= maxLength) continue;
                longestWord = word;
                maxLength = word.Length;
            }
            Console.WriteLine(longestWord);
        }
    }
}
