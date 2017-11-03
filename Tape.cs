using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Tape
    {
        /// <summary>
        /// Входная строка
        /// </summary>
        private string tape;
        /// <summary>
        /// Символ конца стека. А так же конца ленты.
        /// </summary>
        const char endStack = '&';
        /// <summary>
        /// Подверждает принадлежит входная строка языку или нет.
        /// </summary>
        public bool confirmation = false;
        /// <summary>
        /// Подтверждение что слово принадлежит языку
        /// </summary>
        public void confirm()
        {
            confirmation = true;
        }

        public Tape(string str)
        {
            tape = str + endStack;
        }

        public string getTape()
        {
            return tape;
        }

        public char getTape(int i)
        {
            return tape[i];
        }
    }
}
