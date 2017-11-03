using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab
{

    /// <summary>
    /// Автомат с магазинной памятью.
    /// </summary>
    class AutomatMP2
    {
        /// <summary>
        /// Состояния автомата.
        /// </summary>
        enum state { q0, q1, q2 };
        /// <summary>
        /// Действие автомата.
        /// </summary>
        const int doing = 4;
        /// <summary>
        /// Правила автомата.
        /// </summary>
        object[,] rules;
        /// <summary>
        /// Текущее состояние автомата.
        /// </summary>
        const int st0 = 0;
        /// <summary>
        /// Входной символ в автомат.
        /// </summary>
        const int inCh = 1;
        /// <summary>
        /// Следущее состояние автомата.
        /// </summary>
        const int st1 = 3;
        /// <summary>
        /// Действия автомата.
        /// </summary>
        enum action { push, pop, confirm };
        /// <summary>
        /// Таблица функицй переходов.
        /// </summary>
        public List<String[]> JumpFunction = new List<string[]>();
        /// <summary>
        /// Конструктор.
        /// Добавляет в стек конце стека. Формирует правила работы. Устанавливает текущее состояние в начальное, то есть в q0.
        /// </summary>
        public AutomatMP2() { 

            /// <summary>
            /// Создание правил работы распознавания слов языка
            /// </summary>
        void createRules() => rules = new object[5, 5] {
                {state.q0,  '0',        endStack,   state.q1,   action.push},//typeof(AutomatMP).GetMethod("push").MethodHandle.GetFunctionPointer();
                {state.q1,  '0',        '0',        state.q1,   action.push},
                {state.q1,  '1',        '0',        state.q2,   action.pop},
                {state.q2,  '1',        '0',        state.q2,   action.pop},
                {state.q2,  endStack,   endStack,   state.q0,   action.confirm},
            };
        /// <summary>
        /// Возвращение к начальному состоянию.
        /// </summary>
        void SetNullState()
        {
            JumpFunction.Clear();
            stack.Clear();
            stack.Add(endStack);
            st = state.q0;
            confirmation = false;
        }

        /// <summary>
        /// Подтверждение что слово принадлежит языку
        /// </summary>
        void confirm()
        {
            confirmation = true;
        }
        /// <summary>
        /// Запуск автомата с входной строкой.
        /// </summary>
        /// <param name="tape"/> Входная строка.
        void Run(string tape)
        {
            SetNullState();
            tape += '&';
            for (int i = 0; i < tape.Length; i++)
            {
                JumpFunction.Add(new String[] { new string(stack.ToArray()), st.ToString(), tape.Substring(i, tape.Length - i) });
                for (int m = 0; m < 5 //rules.Rank
                    ; m++)
                {
                    if ((st == (state)rules[m, st0]) &&
                        (tape[i] == (char)rules[m, inCh]) &&
                        (stack[0] == (char)rules[m, stckTop]))
                    {
                        st = (state)rules[m, st1];
                        //(IntPtr)rules[m, doing]('0');
                        switch (rules[m, doing])
                        {
                            case action.push:
                                push('0');
                                break;
                            case action.pop:
                                pop();
                                break;
                            case action.confirm:
                                confirm();
                                break;
                        }
                        break;
                    }
                    if (m == 4)
                        return;
                }
            }
        }

        /// <summary>
        /// Стек.
        /// </summary>
        List<char> stack = new List<char>();
        /// <summary>
        /// Верхушка стека автомата.
        /// </summary>
        const int stckTop = 2;
        
       
        //добавляем символ конца в стек
        stack.Add(endStack);
        createRules();
        st = state.q0;
        }
    /// <summary>
    /// Занести в стек.
    /// </summary>
    /// <param name="ch"/> Символ заносимый в стек.
    void push(char ch)
        {
            stack.Insert(0, ch);
            //stack[++stackTop] = ch;
        }
        /// <summary>
        /// Вытолкнуть из стека.
        /// </summary>
        void pop()
        {
            if (stack[0] != endStack)
                stack.RemoveAt(0);
            //ch = stack[stackTop--];
        }
        
        /// <summary>
        /// Входная строка.
        /// </summary>
        const int instr = 2;
        /// <summary>
        /// Символ конца стека. А так же конца ленты.
        /// </summary>
        const char endStack = '&';
        /// <summary>
        /// Подверждает принадлежит входная строка языку или нет.
        /// </summary>
        public bool confirmation = false;      
        
    }
}