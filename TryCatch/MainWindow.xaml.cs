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

namespace TryCatch
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Class1 class1 = new Class1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                class1.number = Convert.ToInt32(TextBox1.Text);
                class1.Add();
                TextBox1.Text = string.Empty;
                ListBox1.Items.Clear();
                foreach (int el in class1.num)
                {
                    ListBox1.Items.Add(el);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Введите число","Input Error" ,MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                class1.Save();
            }
            catch(Exception er)
            {
                MessageBox.Show("Невозможно прочитать файл:", er.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Click3(object sender, RoutedEventArgs e)
        {
            
                class1.Load(filename.Text);
                ListBox1.Items.Clear();
                foreach (int el in class1.num)
                {
                    ListBox1.Items.Add(el);
                }
            
            
            
        }
    }
}
