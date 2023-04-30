using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace TryCatch
{
    internal class Class1
    {
        public int number { get; set; }
        public List<int> num = new List<int>();
        public void Add() 
        {
            
            num.Add(number);
        }
        public void Save()
        {
            string file = "Output.txt";
            StreamWriter sw = new StreamWriter(file);
            foreach(int i in num)
            {
                sw.WriteLine(i);
            }
            sw.Close();
        }
        public void Load(string file)
        {
            try
            {
                file = file + ".txt";
                StreamReader sr = new StreamReader(file);
                num = new List<int>();
                while (!sr.EndOfStream)
                {
                    for (int i = 2; i < Convert.ToInt32(sr.ReadLine()); i++)
                    {
                        if (Convert.ToInt32(sr.ReadLine()) % i == 0)
                        {
                            throw new ArgumentException("Число не простое");
                        }
                    }
                    num.Add(Convert.ToInt32(sr.ReadLine()));
                }
                sr.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Содержимое файла некорректно", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception er)
            {
                MessageBox.Show("Невозможно найти файл", er.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }

}
