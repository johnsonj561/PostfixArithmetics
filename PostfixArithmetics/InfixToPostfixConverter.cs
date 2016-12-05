using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStackLibrary;
using System.Text.RegularExpressions;

namespace PostfixArithmetics {

    /// <summary>
    /// Static class for converting arithmetic expressions from infix to postix
    /// </summary>
    static class InfixToPostfixConverter {

        /// <summary>
        /// Static method that converts arithmetic expression from infix to postfix
        /// Assumes infix input is valid arithmetic expression
        /// </summary>
        /// <param name="infix"></param>
        /// <returns></returns>
        public static string convertInfixToPostfix(string infix) {
            char[] inputChars = infix.ToCharArray();
            LinkedList<string> tokens = parseArithmeticExpression(inputChars);
            GenericStack<string> parsingStack = new GenericStack<string>();

            /*      Infix -> Postfix Rules
             * 1.	Print operands as they arrive.
             * 2.	If the stack is empty or contains a left parenthesis on top, push the incoming operator onto the stack.
             * 3.	If the incoming symbol is a left parenthesis, push it on the stack.
             * 4.	If the incoming symbol is a right parenthesis, pop the stack and print the operators until you see a left parenthesis. Discard the pair of parentheses.
             * 5.	If the incoming symbol has higher precedence than the top of the stack, push it on the stack.
             * 6.	If the incoming symbol has equal precedence with the top of the stack, use association. If the association is left to right, pop and print the top of the stack and then push the incoming operator. If the association is right to left, push the incoming operator.
             * 7.	If the incoming symbol has lower precedence than the symbol on the top of the stack, pop the stack and print the top operator. Then test the incoming operator against the new top of stack.
             * 8.	At the end of the expression, pop and print all operators on the stack. (No parentheses should remain.)
            */
            string postfix = "";
            for (int i = 0; i < tokens.Count(); i++) {
                //get incoming symbol s
                string s = tokens.ElementAt(i);

                //1. Print operands as they arrive.
                if (Regex.IsMatch(s, @"\d*\.?\d+")) {
                    postfix += s + " ";
                }
                //3.If the incoming symbol is a left parenthesis, push it on the stack.
                else if (s.Equals("(")) {
                    parsingStack.push(s);
                }
                //4. If the incoming symbol is a right parenthesis, pop the stack and print the operators until you see a left parenthesis. 
                //   Discard the pair of parentheses.
                else if (s.Equals(")")) {
                    while (!parsingStack.peek().Equals("(")) {
                        postfix += parsingStack.pop() + " ";
                    }
                    //pop the left parenthesis off stack to remove it
                    parsingStack.pop();
                }
                //else incoming symbol must be a left parenthesis or an operator
                else {
                    //2. If the stack is empty or contains a left parenthesis on top, push the incoming operator onto the stack.
                    if (parsingStack.isEmpty() || parsingStack.peek().Equals("(")) {
                        parsingStack.push(s);
                    }
                    //5. If the incoming symbol has higher precedence than the top of the stack, push it on the stack.
                    else if (isHighPrecedence(s) && !isHighPrecedence(parsingStack.peek())) {
                        parsingStack.push(s);
                    }
                    //7. If the incoming symbol has lower precedence than the symbol on the top of the stack, pop the stack and print the top operator. 
                    // Then test the incoming operator against the new top of stack.
                    else if (!isHighPrecedence(s) && isHighPrecedence(parsingStack.peek())) {
                        postfix += parsingStack.pop() + " ";
                        //now we need to check the incoming operator against new top of stack
                        //decementing loop index i will force loop to re-evaluate the same symbol s against new stack top
                        i--;
                    }

                    //6. If the incoming symbol has equal precedence with the top of the stack, use association. 
                    //   If the association is left to right, pop and print the top of the stack and then push the incoming operator. 
                    //   If the association is right to left, push the incoming operator.
                    // We can probably remove this condition and assume that precedence is equal...
                    // Stack can contain only operators and parenthesis! All numbers have already been printed to output
                    // If incoming is higher precedence, if incoming is lower precedence are already covered
                    // therefore the only option left is equal precedence
                    else {
                        postfix += parsingStack.pop() + " ";
                        parsingStack.push(s);
                    }
                }
            }
            //8. At the end of the expression, pop and print all operators on the stack. (No parentheses should remain.)
            while (!parsingStack.isEmpty()) {
                postfix += parsingStack.pop() + " ";
            }

            return postfix;
        }


        /// <summary>
    /// Returns true if string equals multiplication or division operator
    /// </summary>
    /// <param name="s"></param>
    /// <returns>True if string s is multiplication or division</returns>
        private static Boolean isHighPrecedence(string s) {
            if (s.Equals("*") || s.Equals("/")) {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Parses arithmetic string into array of string tokens
        /// Unexpected Values (non digits, non operators) are ignored
        /// </summary>
        /// <param name="input"></param>
        /// <returns>LinkedList<string> tokens</string></returns>
        private static LinkedList<string> parseArithmeticExpression(char[] input) {
            LinkedList<string> tokens = new LinkedList<string>();
            string tempDigits = "";
            for (int i = 0; i < input.Length; i++) {
                //if char is a number or digit, store to tempDigits
                //once we encounter a non digit/decimal -> flush tmepDigits into tokenList
                if (Char.IsNumber(input[i]) || input[i].Equals('.')) {
                    tempDigits += input[i].ToString();
                }
                //else character is not a number or a digit, check for operators or report error
                else {
                    switch (input[i]) {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '(':
                        case ')':
                        //flush the tempDigits
                        if (tempDigits.Length > 0) {
                            tokens.AddLast(tempDigits);
                            tempDigits = "";
                        }
                        //then append new character
                        tokens.AddLast(input[i].ToString());
                        break;
                        //default case assumes value to be unexpected and skips over it
                        default:
                        //Console.WriteLine("Unexpected Character Being Skipped");
                        //Console.WriteLine("Index: " + i + ", Character = " + input[i]);
                        break;
                    }
                }
            }
            //if last token was a number, add it to token string
            if (tempDigits.Length > 0) {
                tokens.AddLast(tempDigits);
            }
            return tokens;
        }
    }

}
