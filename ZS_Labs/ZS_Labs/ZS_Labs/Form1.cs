using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS_Labs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calcControl1.BringToFront();
        }
        //====================================================================//
        //                               Скрытие меню                         //
        //====================================================================//
        private void hideMenu()
        {
            if (panelMenu.Width == 200)
            {
                timerMenuCl.Start();
            }
            else
            {
                timerMenuOp.Start();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
             hideMenu();
        }
        //====================================================================//
        //                        Инициализация таймера                       //
        //====================================================================//
        private void timerMenuCl_Tick(object sender, EventArgs e)
        {
            panelMenu.Width -= 10;
            if (panelMenu.Width == 40) {
                timerMenuCl.Stop();
            }
        }
        //====================================================================//
        //                        Инициализация таймера                       //
        //====================================================================//
        private void timerMenuOp_Tick(object sender, EventArgs e)
        {
            panelMenu.Width += 10;
            if (panelMenu.Width == 200)
            {
                timerMenuOp.Stop();
            }
        }
    }
}
