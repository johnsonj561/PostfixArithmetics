using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackLibrary {

    /// <summary>
    /// Node designed for the generic stack object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class StackNode<T> {

        /// <summary>
        /// Constructor creates node with Value T and empty pointers
        /// </summary>
        /// <param name="value"></param>
        public StackNode(T value) {
            this.value = value;
            prevNode = null;
        }



        public T value { get; set; }
        public StackNode<T> prevNode { get; set; }
    }
}
