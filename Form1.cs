using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа7
{
    public partial class Form1 : Form
    {
        WorkNotes MyNote; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // заполнить 
        {
            MyNote = new WorkNotes();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(MyNote.GetList());
        }

        private void button2_Click(object sender, EventArgs e) // очистить 
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)// удалить 
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Отметьте нужную строку для удаления");
            }
            else
            {
                int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
                MyNote.RemNotes(index); // удалить заметку по индексу
                listBox1.Items.Clear(); // очистить листбокс 
                                        // вывести список людей, использовать метод GetList
                listBox1.Items.AddRange(MyNote.GetList());
            }
        }

        private void button4_Click(object sender, EventArgs e) // добавить
        {
            string sname = textBox1.Text;
            string ssurname = textBox2.Text;
            string sphone = textBox3.Text;
            string sdate = textBox4.Text; 
           // string sdata = textBox4.Text;
           if (sname == "")
           {
                MessageBox.Show("Пустая 1 строка!", "Ошибка ввода");
                return; // выйти из обработчика
           }
           if (ssurname == "")
           {
                MessageBox.Show("Пустая 2 строка!", "Ошибка ввода");
                return; // выйти из обработчика
           }
           if (sphone == "")
           {
                MessageBox.Show("Пустая 3 строка!", "Ошибка ввода");
                return; // выйти из обработчика
           }
            if (sdate == "")
            {
                MessageBox.Show("Пустая 3 строка!", "Ошибка ввода");
                return; // выйти из обработчика
            }
            if (sdate == "")
            {
                MessageBox.Show("Пустая 3 строка!", "Ошибка ввода");
                return; // выйти из обработчика
            }
            if (sdate.Length > 8 || sdate.Length < 4)
            {
                MessageBox.Show("Неправильная форма ввода даты", "Ошибка ввода");
                return; // выйти из обработчика
            }
                MyNote.AddNotes(sname, ssurname, sphone, sdate);
            listBox1.Items.Clear(); // очистить листбокс 
            listBox1.Items.AddRange(MyNote.GetList());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(MyNote.GetNoteby(new MyIComparerData().Compare)); 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(MyNote.GetNoteby(new MyIComparerName().Compare));
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(MyNote.GetNoteby(new MyIComparerSurname().Compare));
        }

        
    }
}
