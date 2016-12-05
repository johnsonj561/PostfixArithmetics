/*
 * Justin Johnson
 * Practicing C# Data Structures
 * Program uses a stack to translate a infix arithmetic expression into postfix format
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStackLibrary;
using System.Text.RegularExpressions;

namespace PostfixArithmetics {
    class Program {
        static void Main(string[] args) {

            //Get input from user
            Console.WriteLine("Enter Infix Arithmetic Expression");
            string userInput = Console.ReadLine();

            //generate postfix output
            string postfixOutput = InfixToPostfixConverter.convertInfixToPostfix(userInput);

            Console.WriteLine("\nParsing Finished\nUser Input (Infix) = " + userInput + "\nPostfix Output = " + postfixOutput);
            Console.WriteLine("\nPress any key to terminate...");
            Console.ReadKey();
        }


    }
}
