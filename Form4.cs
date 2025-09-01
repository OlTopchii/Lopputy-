using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lopputyo
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // При загрузке формы ничего не считаем
        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Syötä kaksi lukua ja paina Laske.";
        }

        // Дважды щёлкни по кнопке "Laske", чтобы VS создала этот обработчик
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int num1) &&
                int.TryParse(textBox2.Text, out int num2))
            {
                int sum = num1 + num2;
                label1.ForeColor = SystemColors.ControlText;
                label1.Text = $"Summa: {sum}";
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Red; // необязательно
                label1.Text = "Virhe: syötä vain numeroita!";
            }
        }

        // Этот метод можно оставить пустым или удалить привязку события из Designer
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
