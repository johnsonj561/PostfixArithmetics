using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackLibrary {

    /// <summary>
    /// Stack generic stack class that stores primitive data types and user defined objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericStack<T> {

        /// <summary>
        /// Constructs empty stack with no elements
        /// </summary>
        public GenericStack() {
            top = null;
        }


        /// <summary>
        /// Push new node onto the top of the stack
        /// </summary>
        /// <param name="value"></param>
        public void push(T value) {
            StackNode<T> newNode = new StackNode<T>(value);
            size++;
            //if this is the first node in stack, it is also the top
            if (size == 1) {
                top = newNode;
                return;
            }
            //else bottom is already established, only change top
            newNode.prevNode = top;
            top = newNode;
        }



        /// <summary>
        /// Remove and return the top element from stack.
        /// Returns Null if stack is empty
        /// </summary>
        /// <returns></returns>
        public T pop() {
            //if there are elements to pop
            if (size > 0) {
                //get top node's value
                T returnValue = top.value;
                //if more node's exist, decrement top pointer to next node in stack
                //garbage collector will clean up popped node once de-referenced
                if(top.prevNode != null) {
                    top = top.prevNode;
                }
                size--;
                return returnValue;
            }
            else {
                return default(T);
            }
        }


        /// <summary>
        /// Returns value of stack's top most element without changing structure of stack
        /// </summary>
        /// <returns></returns>
        public T peek() {
            if(size > 0) {
                return top.value;
            }
            Console.WriteLine("Error -> Unable to view top value of empty stack.");
            return default(T);
        }


        /// <summary>
        /// Print all elements of stack
        /// </summary>
        public void print() {
            Console.WriteLine("\nPrinting Stack Elments" +
                "\n////////////////////\n////////TOP/////////\n////////////////////");
            StackNode<T> current = top;
            while (current != null) {
                Console.WriteLine(current.value);
                current = current.prevNode;
            }
            Console.WriteLine("////////////////////\n//////BOTTOM////////\n////////////////////");
        }


        /// <summary>
        /// Return false if stack size is greater than 0
        /// </summary>
        /// <returns></returns>
        public Boolean isEmpty() {
            if(size > 0) {
                return false;
            }
            return true;
        }

        //define bottom and top of stack
        //public StackNode<T> bottom { get; set; }
        public StackNode<T> top { get; set; }
        private int size;
    }

}


