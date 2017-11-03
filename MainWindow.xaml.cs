using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Всплывающая подсказака при ошибке.
        /// </summary>
        ToolTip tp = new ToolTip();

        /// <summary>
        /// Конструктор главной формы.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //содержание подсказки
            tp.Content = "Разрешенные символы: 0 и 1. Повторите ввод.";
            //назначаем всплывающую подсказку объекту
            InputText.ToolTip = tp;
            //задержка отображения
            ToolTipService.SetShowDuration(InputText, 2000);
            //расположение подсказки
            tp.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
            //расположение относительно объекта
            tp.PlacementTarget = InputText;
            CreateTables();
        }


        /// <summary>
        /// Разрешён ввод только 1 и 0.
        /// </summary>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Key == Key.D0) || (e.Key == Key.D1) || (e.Key == Key.NumPad0) || (e.Key == Key.NumPad1))
            {
                tp.IsOpen = false;
                return;
            }
            else
            {
                ((ToolTip)InputText.ToolTip).IsOpen = true;
                e.Handled = true;
            }
        }

        private void InputText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //что бы пробел не вводился
            if (e.Key == Key.Space)
            {
                ((ToolTip)InputText.ToolTip).IsOpen = true;
                e.Handled = true;
            }
        }

 //       private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            DataTable dt = new DataTable();
//            Tape.Columns.Clear();
 //           List<String> str = new List<string>();
//            dt.Rows.Add();
 //           for (int i = 0; i < InputText.Text.Length; i++)
 //           {
 //               dt.Columns.Add();
 //               str.Add(InputText.Text[i].ToString());
 //           }
  //          dt.Rows[0].ItemArray = str.ToArray();
 //           Tape.ItemsSource = dt.DefaultView;
 //           //Tape.Columns.Add((DataGridColumn)(new DataGridTextColumn()));
            //((DataGridColumn)Tape.Columns[0]).Background = new SolidColorBrush(Colors.Red);
            //Tape.SelectedItem = 0;
            //Tape.SelectedIndex = 3;



     //       DataTable dt2 = new DataTable();
     //       Stack.Columns.Clear();
    //        List<String> str2 = new List<string>();
            //dt2.Rows.Add();
    //        dt2.Columns.Add();

       //     for (int i = 0; i < InputText.Text.Length; i++)
      //      {
     //           //dt2.Rows.Add();
      //          str2.Add(InputText.Text[i].ToString());
                //dt2.Columns.Add(new DataColumn());
     //           dt2.Rows.Add(new String[] { str2[i].ToString() });
                //dt2.Rows[i].ItemArray[0] = ;
       //     }
            //dt2.Rows[0].ItemArray[0] = str2[0];
            //dt2.Rows[0].ItemArray = str2[0].ToArray();
     //       Stack.ItemsSource = dt2.DefaultView;
    //        Stack.MinColumnWidth = 68;
     //       Stack.MaxColumnWidth = 68;
     //       Stack.ColumnWidth = 68;
      //  }

        private void InputText_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Space)
            //    e.Handled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dt4.Rows.Clear();
            //AutomatMP at = new AutomatMP();
            Permanent(at);
            JumpFunction = at.JumpFunction;
            foreach (string[] str in JumpFunction)
            {
                dt4.Rows.Add(str);
            }
            Success(at);
        }

        /// <summary>
        /// Запуск автомата в режиме "непрерывно".
        /// </summary>
        private void Permanent(AutomatMP at)
        {
            string tape = InputText.Text;
            at.Run(tape);
        }

        private void Success(AutomatMP at)
        {
            if (at.getConfirmation())
            {
                InputText.Background = Brushes.LightGreen;
            }
            else
            {
                InputText.Background = Brushes.Red;
            }
        }

        List<String[]> JumpFunction;
        DataTable dt4;
        void CreateTables()
        {
            DataTable dt3 = new DataTable();
            JumpTb.Columns.Clear();
            //dt2.Rows.Add();
            dt3.Columns.Add("Магазин");
            dt3.Columns.Add("0");
            dt3.Columns.Add("1");
            dt3.Columns.Add("&");
            dt3.Rows.Add(new String[] { "0", "↓0,→", "↑→", "Отвергнуть" });
            dt3.Rows.Add(new String[] { "&", "↓0,→", "Отвергнуть", "Допустить" });

            JumpTb.ItemsSource = dt3.DefaultView;
            //JumpTb.MinColumnWidth = 68;
            //JumpTb.MaxColumnWidth = 68;
            //JumpTb.ColumnWidth = 68;

            dt4 = new DataTable();
            JumpFunctionTb.Columns.Clear();
            //dt2.Rows.Add();
            dt4.Columns.Add("Магазин");
            dt4.Columns.Add("Состояние");
            dt4.Columns.Add("Исходная строка");
            //dt3.Columns.Add();
            //dt3.Columns.Add();
            //dt3.Columns.Add();
            //dt3.Columns.Add();

            //dt4.Rows.Add(new String[] { "&", "q0", "0011&" });
            //dt4.Rows.Add(new String[] { "&0", "q1", "011&" });

            JumpFunctionTb.ItemsSource = dt4.DefaultView;
            //JumpTb.MinColumnWidth = 68;
            //JumpTb.MaxColumnWidth = 68;
            //JumpTb.ColumnWidth = 68;
        }
        AutomatMP at = new AutomatMP();
        int k = 0;
        int q = 0;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (q == 0)
            {
                dt4.Rows.Clear();
                InputText.Background = Brushes.White;
                //AutomatMP at = new AutomatMP();
                Permanent(at);
                JumpFunction = at.JumpFunction;
                k = 0;
                DiscreteBtn.Content = "Далее";
                InputText.IsReadOnly = true;
                q = 1;
            }
            else
            {
                
                if (k < JumpFunction.Count)
                    dt4.Rows.Add(JumpFunction[k++]);
                if (k == JumpFunction.Count)
                {
                    DiscreteBtn.Content = "Дискретно";
                    InputText.IsReadOnly = false;
                    q = 0;
                    Success(at);
                    
                }
            }
        }
        

    }
}
