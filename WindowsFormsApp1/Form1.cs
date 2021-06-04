using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static bool executar = true;
        public Form1()
        {
            InitializeComponent();
        }

        static void NovaThread()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            executar = true;

            for (int i = 1; i > 0; i++)
            {
                SendKeys.SendWait(i.ToString());
                Thread.Sleep(TimeSpan.FromSeconds(5));

                if (executar == false)
                {
                    break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            executar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            Thread t = new Thread(NovaThread);
            txtWill.Text += t + Environment.NewLine;
            t.Start();
        }
    }
}
