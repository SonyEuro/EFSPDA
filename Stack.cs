using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Stack
    {
        /// <summary>
        /// Стек.
        /// </summary>
        private List<char> stack = new List<char>();
        /// <summary>
        /// Символ конца стека. А так же конца ленты.
        /// </summary>
        private const char endStack = '&';
        /// <summary>
        /// Занести в стек.
        /// </summary>
        /// <param name="ch"/> Символ заносимый в стек.
        public void push(char ch)
        {
            stack.Insert(0, ch);
            //stack[++stackTop] = ch;
        }
        /// <summary>
        /// Вытолкнуть из стека.
        /// </summary>
        public void pop()
        {
            if (stack[0] != endStack)
                stack.RemoveAt(0);
            //ch = stack[stackTop--];
        }

        public char topStack()
        {
            return stack[0];
        }
        public Stack()
        {
            push(endStack);
            //stack.Add(endStack);
        }

        public List<char> getStack()
        {
            return stack;
        }
    }
}
