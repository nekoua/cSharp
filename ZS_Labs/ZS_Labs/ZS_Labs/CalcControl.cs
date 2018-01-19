using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS_Labs
{
    public partial class CalcControl : UserControl
    {
        public CalcControl()
        {
            InitializeComponent();
        }
        double x = 0, y = 0, res = 0;
        char operation = ' ';
        bool resize = true;

        //====================================================================//
        //                             Ввод чисел                             //
        //====================================================================//
        private void button5_Click(object sender, EventArgs e)
        {
            if ((display.Text == string.Empty) || (double.Parse(display.Text) == 0)&(display.Text != "0,"))
            {
                display.Text = (sender as Button).Text;
            }
            else
            {
                display.Text += (sender as Button).Text;
            }
        }
        //====================================================================//
        //                            Метод очистки                           //
        //====================================================================//
        private void Clear()
        {
            display.Clear();
            display.Text = "0";
        }
        //====================================================================//
        //                            Кнопка очистки                          //
        //====================================================================//
        private void button17_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //====================================================================//
        //                   Удаление последнего символа                      //
        //====================================================================//
        private void button18_Click(object sender, EventArgs e)
        {
            if ( (display.Text != "")/* && (display.Text[0] != '0')*/) {
                display.Text = display.Text.Remove(display.Text.Length - 1, 1);
                if ((display.Text == string.Empty))
                {
                    display.Text = "0";
                }
            }
        }
        //====================================================================//
        //          Кнопка "=" обработка операций на двумя операндами         //
        //====================================================================//
        private void button3_Click(object sender, EventArgs e)
        {
            y = Convert.ToDouble(display.Text);
            switch (operation) {
                case '+':
                    res = x + y;
                    break;
                case '-':
                    res = x - y;
                    break;
                case '*':
                    res = x * y;
                    break;
                case '/':
                    res = x / y;
                    break;
                case '&':
                    res = Convert.ToInt32(x) & Convert.ToInt32(y);
                    break;
                case '|':
                    res = Convert.ToInt32(x) | Convert.ToInt32(y);
                    break;
                case '^':
                    res = Convert.ToInt32(x) ^ Convert.ToInt32(y);
                    break;
                case '«':
                    res = Convert.ToInt32(x) << Convert.ToInt32(y);
                    break;
                case '»':
                    res = Convert.ToInt32(x) >> Convert.ToInt32(y);
                    break;
            }
            display.Text = res.ToString();
        }
        //====================================================================//
        //                             Смена знака                            //
        //====================================================================//
        private void button20_Click(object sender, EventArgs e)
        {
            if ((display.Text != string.Empty)&(double.Parse(display.Text) != 0))
            {
                double znak = Convert.ToDouble(display.Text);
                znak = -znak;
                display.Text = znak.ToString();
            }
        }
        //====================================================================//
        //                        Возвидение в квадрат                        //
        //====================================================================//
        private void button29_Click(object sender, EventArgs e)
        {
            display.Text = Convert.ToString(double.Parse(display.Text) * double.Parse(display.Text));
        }
        //====================================================================//
        //                                Инверсия                            //
        //====================================================================//
        private void button26_Click(object sender, EventArgs e)
        {
            display.Text = Convert.ToString((object)~Convert.ToInt64(display.Text));
        }
        //====================================================================//
        //                               Число П                              //
        //====================================================================//
        private void button25_Click(object sender, EventArgs e)
        {
            display.Text = "3,14159265359";
        }
        //====================================================================//
        //                               Число e                              //
        //====================================================================//
        private void button23_Click(object sender, EventArgs e)
        {
            display.Text = "2,71828182846";
        }
        //====================================================================//
        //                        Вычисление процента                         //
        //====================================================================//
        private void button19_Click(object sender, EventArgs e)
        {
            display.Text = Convert.ToString((x * double.Parse(display.Text)) / 100);
        }
        //====================================================================//
        //                      Расчет квадратного корня                      //
        //====================================================================//
        private void button27_Click(object sender, EventArgs e)
        {
            display.Text = Convert.ToString(System.Math.Sqrt(double.Parse(display.Text)));
        }
        //====================================================================//
        //                      Расширение калькулятора                       //
        //====================================================================//
        private void button31_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 340)
            {
                timerCalcOn.Start();
                button31.Cursor = Cursors.PanWest;
            }
            else
            {
                timerCalcCl.Start();
                button31.Cursor = Cursors.PanEast;
            }
        }
        //====================================================================//
        //                        Инициализация таймера                       //
        //====================================================================//
        private void timerCalcOn_Tick(object sender, EventArgs e)
        {
            display.Width += 10;
            panel1.Width += 10;
            if (panel1.Width == 500) {
                timerCalcOn.Stop();
            }
        }
        //====================================================================//
        //                         Инициализация таймера                      //
        //====================================================================//
        private void timerCalcCl_Tick(object sender, EventArgs e)
        {
            panel1.Width -= 10;
            display.Width -= 10;
            if (panel1.Width == 340)
            {
                timerCalcCl.Stop();
            }
        }
        //====================================================================//
        //                           Десятичная точка                         //
        //====================================================================//
        private void button2_Click(object sender, EventArgs e)
        {
            if (display.Text.Contains(',') == false) {
                display.Text += ',';
            }
        }
        //====================================================================//
        //                  Инициалиация первого операнда                     //
        //====================================================================//
        private void operationSelect(object sender, EventArgs e) {
            x = Convert.ToDouble(display.Text);
            operation = (sender as Button).Text[0];
            Clear();
        }
    }
}
