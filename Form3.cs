using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Lopputyo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!listBox1.Items.Contains(file))
                    listBox1.Items.Add(file);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = this.Location;
            f2.Show();
            this.Hide();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF файлы|*.pdf|Все файлы|*.*";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    if (!listBox1.Items.Contains(file))
                        listBox1.Items.Add(file);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один PDF-файл для конвертации.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string file in listBox1.Items)
            {
                try
                {
                    if (!System.IO.File.Exists(file))
                    {
                        MessageBox.Show($"Файл не найден: {file}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    string outputPath = System.IO.Path.ChangeExtension(file, ".docx");
                    ConvertPdfToWord(file, outputPath);

                    MessageBox.Show($"Файл успешно конвертирован: {outputPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при конвертации {file}: {ex.Message}\nДетали: {ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConvertPdfToWord(string inputPath, string outputPath)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                doc.LoadFromFile(inputPath);
                if (doc.Pages.Count > 10)
                {
                    MessageBox.Show($"Файл {inputPath} содержит более 10 страниц. Конвертация ограничена 10 страницами.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                doc.SaveToFile(outputPath, FileFormat.DOCX);
            }
        }
    }
}