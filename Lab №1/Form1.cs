using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab__1
{
    public partial class Form1 : Form
    {
        int num1, num2, num3, tim; //расчет времени в таймере
        DateTime dt1 = new DateTime (2019, 11, 11, 0, 0, 0);//DateTime для секундомера
        DateTime dt2 = new DateTime (2019, 11, 11, 0, 0, 0);//DateTime для таймера
        int inc = 0; //секундомер
        bool butt2 = true;//Пуск в таймере


        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            timer3.Start();
            button4.Visible = false;
            button5.Visible = false;
        }//Настройка при запуске

        private void Timer1_Tick(object sender, EventArgs e)
        {
            inc++;
            if (inc % 2 == 0)
            {
                label1.Text = Convert.ToString(dt1.AddSeconds(inc).ToString("HH:mm:ss"));
            }
            else
            {
                label1.Text = Convert.ToString(dt1.AddSeconds(inc).ToString("HH mm ss"));
            }
        }//Мигание надписи в секундомере

        private void Button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button1.Text = "Пуск";
                timer1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button1.Text = "Стоп";
                timer1.Enabled = true;
                button2.Enabled = true;
            }
        }// Запуск и остановка секундомера

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button2.Enabled = false;
            inc = 0;
            label1.Text = "00:00:00";
            button1.Text = "Пуск";
        }//Сброс времени в секундомере

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value == 0) & (numericUpDown2.Value == 0) & (numericUpDown3.Value == 0))
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }//Проверка времени в таймере

        private void Button5_Click(object sender, EventArgs e)
        {
            if (tim>0)
            {
                tim -= 300;
            }
            else
            {
                label2.Text = "00:00:00";
            }
        }// - 5 мин.

        private void Button4_Click(object sender, EventArgs e)
        {
            if (tim > 0)
            {
                tim -= 600;
            }
            else
            {
                label2.Text = "00:00:00";
            }
        }// - 10 мин

        private void Button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            button6.Enabled = false;
            groupBox1.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button3.Text = "Пуск";
            label2.Text = "00:00:00";
            butt2 = true;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }//Сброс таймера 

        private void Button3_Click(object sender, EventArgs e)
        {
            if (butt2 == true)
            {
                button3.Text = "Стоп";
                num1 = Convert.ToInt32(numericUpDown1.Value) * 3600;
                num2 = Convert.ToInt32(numericUpDown2.Value) * 60;
                num3 = Convert.ToInt32(numericUpDown3.Value);
                tim = num1 + num2 + num3;
                groupBox1.Visible = false;
                timer2.Start();
                butt2 = false;
                button6.Enabled = true;
            }
            else
            {
                button3.Text = "Пуск";
                tim++;
                num1 = tim / 3600;
                num2 = (tim - num1* 3600) / 60;
                num3 = tim - (num1 * 3600 + num2 * 60);
                numericUpDown1.Value = num1;
                numericUpDown2.Value = num2;
                numericUpDown3.Value = num3;
                button4.Visible = false;
                button5.Visible = false;
                groupBox1.Visible = true;
                timer2.Stop();
                butt2 = true;
            }
 
        }// Пуск в таймере

        private void Timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(dt2.AddSeconds(tim).ToString("HH:mm:ss"));
            if (tim>0)
            {
                tim--;
                button4.Visible = true;
                button5.Visible = true;
            }
            else
            {
                label2.Text = "00:00:00";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                button4.Visible = false;
                button5.Visible = false;
                timer2.Stop();
                MessageBox.Show("Время истекло", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Visible = true;
                button3.Text = "Пуск";
                butt2 = true;
                button6.Enabled = false;
            }
        }//Работа таймера

        private void Timer3_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }//Текущая дата
    }
}
