using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2лабораторная
{
    public partial class Form1 : Form
    {
        delegate void D_Time();

        event D_Time SecondTime;

        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("En-en");

            InitializeComponent();
            SecondTime += Show_Time_TextBox;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SecondTime();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && e.Alt)
                StartMenu.PerformClick();

            if (e.KeyCode == Keys.Left && e.Alt)
                StopMenu.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            KeyPreview = true;
        }

        private void Show_Time_TextBox()
        {
            Clock kik = new Clock();

            textBox1.Text = kik.tim("Moscow").ToString("dd/MM/yyyy H:mm:ss "); ;
            textBox2.Text = kik.tim("London").ToString("dd/MM/yyyy H:mm:ss "); ;
            textBox3.Text = kik.tim("Vladivostok").ToString("dd/MM/yyyy H:mm:ss "); ;
        }

        private void StartMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void StopMenu_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }

    class Clock
    {
        public DateTime tim(string name)
        {
            Dictionary<string, TimeSpan> slovar = new Dictionary<string, TimeSpan>
            {
                {"Moscow",new TimeSpan(0, 0, 0)},
                {"London",new TimeSpan(-2, 0, 0)},
                {"Vladivostok",new TimeSpan(7, 0, 0)}
            };

            DateTime now = DateTime.Now;
            now += slovar[name];

            return now;
        }
    }
}
