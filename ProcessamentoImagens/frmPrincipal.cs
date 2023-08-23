using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Image image;
        private Bitmap imageBitmap;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAbrirImagem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictBoxImg1.Image = image;
                pictBoxImg1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pictBoxImg1.Image = null;
            pictBoxImg2.Image = null;
        }

        private void btnLuminanciaSemDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.convert_to_gray(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnLuminanciaComDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.convert_to_grayDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnNegativoSemDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.negativo(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void btnNegativoComDMA_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.negativoDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.espelhoHorizontalSemDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.espelhoVerticalSemDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.espelhoHorizontalDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.espelhoVerticalDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.pretoebranco(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.pretobrancoDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.rotacao90DMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.Rotacao90Direita(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.InverterCanaisRB(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.InverterCanaisRBDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.DividirMontarComDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button11_Click(object sender, EventArgs e)
        {
             Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EspelhoDiagonalDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.EspelhoDiagonalsemDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imageBitmap = (Bitmap)image;
            Filtros.DividirMontarSemDMA(imageBitmap, imgDest);
            pictBoxImg2.Image = imgDest;
        }
    }
}
