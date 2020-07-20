using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shutdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Wprowadź za ile godzin chcesz wyłączyć komputer.(tylko liczby całości)");
            toolTip1.SetToolTip(textBox2, "Wprowadź za ile minut chcesz wyłączyć komputer.(tylko liczby całości)");
            toolTip1.SetToolTip(textBox3, "Wprowadź za ile sekund chcesz wyłączyć komputer.(tylko liczby całości)");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                value = false;
                CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int h = int.Parse(textBox1.Text);
                int m = int.Parse(textBox2.Text);
                int s = int.Parse(textBox3.Text);
                int output = (h * 60 * 60) + (m * 60) + s;

                Process.Start(@"C:\Windows\system32\shutdown.exe", "-s -t " + output.ToString());

                MessageBox.Show("Ustawiono odliczanie do zamknięcia na " + h + " godzin(-ę/-y) i " + m + " minut(-ę/-y) (" + output + " sekund)");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podane liczby zawierają błąd (najprawdopodobniej nie są całkowite)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int h = int.Parse(textBox1.Text);
                int m = int.Parse(textBox2.Text);
                int s = int.Parse(textBox3.Text);
                int output = (h * 60 * 60) + (m * 60) + s;

                Process.Start(@"C:\Windows\system32\shutdown.exe", "-r -t " + output.ToString());

                MessageBox.Show("Ustawiono odliczanie do restartu na " + h + " godzin(-ę/-y) i " + m + " minut(-ę/-y) " + s + " sekund(-ę/-y) (" + output + " sekund)");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Podane liczby zawierają błąd (najprawdopodobniej nie są całkowite)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\system32\shutdown.exe", "-a ");
        }

        private void wyłaczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
