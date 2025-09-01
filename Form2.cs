using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lopputyo
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();

            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = this.Location;

            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();

            f3.StartPosition = FormStartPosition.Manual;
            f3.Location = this.Location;

            f3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();

            f4.StartPosition = FormStartPosition.Manual;
            f4.Location = this.Location;

            f4.Show();
            this.Hide();
        }
    }
}
