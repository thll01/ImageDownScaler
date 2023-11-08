using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Bitmap image = new Bitmap(filePath);
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }

            if (float.TryParse(textBox1.Text, out float factor) && factor > 0 && factor <= 10)
            {
                // Make sure pictureBox1.Image is not null before creating the Bitmap
                if (pictureBox1.Image is Bitmap originalImage)
                {
                    Bitmap downsizedImageConsequential = ImageProperties.ConsequentialDownscale(originalImage, factor);
                    Bitmap downsizedImageParallel = ImageProperties.ParallelDownscale(originalImage, factor);

                    pictureBox2.Image = downsizedImageConsequential; 
                }
            }
            else
            {
                MessageBox.Show("Invalid downscaling factor. Please enter a valid value between 0 and 10.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
