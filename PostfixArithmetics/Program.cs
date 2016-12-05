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
            string postfixOutput = PostfixEvaluator.convertInfixToPostfix(userInput);
            Console.WriteLine("\nUser Input (Infix) = " + userInput + "\nPostfix Output = " + postfixOutput);

            Console.WriteLine("\nCalculating Postfix Expression...");
            string postfixResult = PostfixEvaluator.evaluatePostfixExpression(postfixOutput);
            Console.WriteLine(postfixOutput + " = " + postfixResult);

            Console.WriteLine("\nPress any key to terminate...");
            Console.ReadKey();
        }
    }
}
