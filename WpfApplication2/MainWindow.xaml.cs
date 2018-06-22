using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void YABLUE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToDoItem ToDoList = new ToDoItem();
            ToDo.Children.Add(ToDoList);
        }

        private void ADD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ToDoItem ToDoList = new ToDoItem();
            ToDo.Children.Add(ToDoList);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                int a = 0;

                foreach (ToDoItem item in ToDo.Children)
                {

                    a += item.momoney;
                }
                Money.Text = a.ToString();
            }
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            ToDo.Children.Remove((ToDoItem)sender);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> datas = new List<string>();

            foreach (ToDoItem item in ToDo.Children)
            {
                string uuu = "";
                uuu += "|" + item.time + "|" + item.ITEMnameTb + "|" + item.momoney;
                datas.Add(uuu);

            }

            System.IO.File.WriteAllLines(@"C:\trytrysee.txt", datas);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            string[] lines = System.IO.File.ReadAllLines(@"C:\trytrysee.txt");​
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                ToDoItem item = new ToDoItem();
                item.ITEMname = parts[1];
                item.DeleteItem += new EventHandler(DeleteItem);​ToDo.Children.Add(item);
            }
            */
            string[] lines = System.IO.File.ReadAllLines(@"C:\trytrysee.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                ToDoItem item = new ToDoItem();
                item.ITEMname = parts[1];
                item.DeleteItem += new EventHandler(DeleteItem);
                ToDo.Children.Add(item); 

            }
        }

    }
}
