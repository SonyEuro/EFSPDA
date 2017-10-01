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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tp.Content = "Разрешенные символы: 0 и 1. Повторите ввод.";
            InputText.ToolTip = tp;
            ToolTipService.SetShowDuration(InputText, 2000);
            tp.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
            tp.PlacementTarget = InputText;
        }
        
        ToolTip tp = new ToolTip();
        
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            Tape.Columns.Clear();
            List<String> str = new List<string>();
            dt.Rows.Add();
            for (int i=0;i< InputText.Text.Length;i++)
            {
                dt.Columns.Add();
                str.Add(InputText.Text[i].ToString());
            }
            dt.Rows[0].ItemArray = str.ToArray();
            Tape.ItemsSource = dt.DefaultView;
            //Tape.Columns.Add((DataGridColumn)(new DataGridTextColumn()));
            //((DataGridColumn)Tape.Columns[0]).Background = new SolidColorBrush(Colors.Red);
            //Tape.SelectedItem = 0;
            //Tape.SelectedIndex = 3;
            


            DataTable dt2 = new DataTable();
            Stack.Columns.Clear();
            List<String> str2 = new List<string>();
            //dt2.Rows.Add();
            dt2.Columns.Add();

            for (int i = 0; i < InputText.Text.Length; i++)
            {
                //dt2.Rows.Add();
                str2.Add(InputText.Text[i].ToString());
                //dt2.Columns.Add(new DataColumn());
                dt2.Rows.Add(new String[]{ str2[i].ToString() });
                //dt2.Rows[i].ItemArray[0] = ;
            }
            //dt2.Rows[0].ItemArray[0] = str2[0];
            //dt2.Rows[0].ItemArray = str2[0].ToArray();
            Stack.ItemsSource = dt2.DefaultView;
            Stack.MinColumnWidth = 68;
            Stack.MaxColumnWidth = 68;
            Stack.ColumnWidth = 68;
        }
    }
}
