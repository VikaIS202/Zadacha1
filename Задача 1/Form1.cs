using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задача_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(@"C:\задача1.txt"); //читаем из файла
            while (!streamReader.EndOfStream) //пока переменная не равна конечному значению
            {
                listBox1.Items.Add(streamReader.ReadLine() + "\r\n"); //выводим числа в ListBox1
            }
            streamReader.Close(); //закрываем чтение
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string alltext; //переменная текстовая
            StreamReader sr = new StreamReader(@"C:\задача1.txt"); //читаем из файла
            int count = System.IO.File.ReadAllLines(@"C:\задача1.txt").Length; //присваиваем переменной длину всего файлаа
            string[] arrayText = new string[count];
            int[] y = new int[count]; 
            int[] w = new int[count];
            int p = 0; 
            for (int i = 0; i < count; i++)
            {
                alltext = sr.ReadLine(); //присваиваем текстовой переменной значения из файла
                arrayText = alltext.Split(new char[] { ' ' });//делим один текст на
                y[i] = Convert.ToInt32(arrayText[0]);
                w[i] = Convert.ToInt32(arrayText[1]);
            }
            Hi(y); //вызов метода
            Hip(w); //вызов метода
            
            for (int i = 0; i < count; i++)
            {
                if ((y[i] != y[i + 1]) && (w[i + 1] - w[i] != 14)) //условие
                { continue; }
                else p = y[i];
            }
            textBox1.Text = p.ToString();
        }
        private static void Hip(int[] m) //пузырьковый метод
        {
            for (int i = 0; i < m.Length; i++) //запуск цикла по длине массива
            {
                for (int j = 0; j < m.Length-1; j++) //запуск цикла, не включающего последний элемент, чтобы избежать ошибки программы
                {
                    if (m[j] > m[j + 1]) //если начальный элемент больше следующего
                    {
                        int r = m[j + 1]; //переменной присваивается наименьшее значение
                        m[j + 1] = m[j]; //переменная, которая меньше начальной, принимает ее значение
                        m[j] = r; //начальная переменная берет наименьшее значение
                    }
                }
            }
        }
        private static void Hi(int[] m) //пузырьковый метод
        {
            for (int i = m.Length; i < 0; i--) //запуск цикла по длине массива
            {
                for (int j = m.Length-1; j < 0; j--) //запуск цикла, не включающего последний элемент, чтобы избежать ошибки программы
                {
                    if (m[j] < m[j + 1]) //если начальный элемент < следующего
                    {
                        int r = m[j + 1]; //переменной присваивается наибольшее значение
                        m[j + 1] = m[j]; //переменная, которая больше начальной, принимает ее значение
                        m[j] = r; //начальная переменная берет наибольшее значение
                    }
                }
            }
        }
    }
}
