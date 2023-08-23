using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace ProcessamentoImagens
{
    class Filtros
    {
        //sem acesso direto a memoria
        public static void convert_to_gray(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;
            Int32 gs;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);

                    //nova cor
                    Color newcolor = Color.FromArgb(gs, gs, gs);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        //sem acesso direito a memoria
        public static void negativo(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int r, g, b;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;

                    //nova cor
                    Color newcolor = Color.FromArgb(255 - r, 255 - g, 255 - b);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        //sem acesso direto a memória
        public static void espelhoHorizontalSemDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    // Definindo a nova posição invertida horizontalmente
                    int novoX = width - x - 1;  // Inverte a posição horizontal

                    imageBitmapDest.SetPixel(novoX, y, cor);
                }
            }
        }

        public static void espelhoVerticalSemDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    // Definindo a nova posição invertida verticalmente
                    int novoY = height - y - 1;  // Inverte a posição vertical

                    imageBitmapDest.SetPixel(x, novoY, cor);
                }
            }
        }

        public static void pretoebranco(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int media = 0;
            int r, g, b;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    r = cor.R;
                    g = cor.G;
                    b = cor.B;
                    media = (r + g + b) / 3;
                    if(media > 127)
                    {
                        media = 255;
                    }
                    else
                    {
                        media = 0;
                    }

                    //nova cor
                    Color newcolor = Color.FromArgb(media, media, media);

                    imageBitmapDest.SetPixel(x, y, newcolor);
                }
            }
        }

        public static void Rotacao90Direita(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    // Definindo a nova posição após a rotação
                    int novoX = height - y - 1;  // Novo X é a altura menos a coordenada Y original menos 1
                    int novoY = x;               // Novo Y é igual à coordenada X original

                    imageBitmapDest.SetPixel(novoX, novoY, cor);
                }
            }
        }

        public static void InverterCanaisRB(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    // Invertendo os canais R (vermelho) e B (azul)
                    Color novaCor = Color.FromArgb(cor.A, cor.B, cor.G, cor.R);

                    imageBitmapDest.SetPixel(x, y, novaCor);
                }
            }
        }

        public static void EspelhoDiagonalsemDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);

                    int tempx, tempy;
                    tempx = (width - 1) - x;
                    tempy = (height - 1) - y;

                    imageBitmapDest.SetPixel(tempx, tempy, cor);
                }
            }
        }

        public static void DividirMontarSemDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;

            int meioaltura = height / 2;
            int meiolargura = width / 2;

            for (int y = 0; y < meioaltura; y++)
            {
                for (int x = 0; x < meiolargura; x++)
                {
                    //quadrante 1 para o quadrante 4
                    // Obtendo a cor do pixel
                    Color cor = imageBitmapSrc.GetPixel(x, y);
                    Color cor2 = imageBitmapSrc.GetPixel(meiolargura + x, meioaltura + y);

                    int tempx, tempy;
                    tempx = meiolargura + x;
                    tempy = meioaltura + y;

                    imageBitmapDest.SetPixel(tempx, tempy, cor);
    
                    imageBitmapDest.SetPixel(x, y, cor2);

                    //quadrante 2 para o quadrante 3
                    cor = imageBitmapSrc.GetPixel(x, meioaltura + y);
                    cor2 = imageBitmapSrc.GetPixel(meiolargura + x,y);

                    imageBitmapDest.SetPixel(meiolargura + x, y, cor);

                    imageBitmapDest.SetPixel(x, meioaltura + y, cor2);

                }
            }
        }


        //com acesso direto a memória
        public static void convert_to_grayDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            Int32 gs;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++); //está armazenado dessa forma: b g r 
                        g = *(src++);
                        r = *(src++);
                        gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        //com acesso direito a memoria
        public static void negativoDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            //lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src1 = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src1++); //está armazenado dessa forma: b g r 
                        g = *(src1++);
                        r = *(src1++);

                        *(dst++) = (byte)(255 - b);
                        *(dst++) = (byte)(255 - g);
                        *(dst++) = (byte)(255 - r);
                    }
                    src1 += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        public static void espelhoVerticalDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            // Lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    int offsetY = height - y - 1;

                    for (int x = 0; x < width; x++)
                    {
                        int offsetX = x * pixelSize;

                        // Calcula a posição do pixel na imagem de origem
                        int srcOffset = offsetY * bitmapDataSrc.Stride + offsetX;

                        // Copia os pixels da imagem de origem para a imagem destino invertendo verticalmente
                        *(dst++) = *(src + srcOffset);     // R
                        *(dst++) = *(src + srcOffset + 1); // G
                        *(dst++) = *(src + srcOffset + 2); // B
                    }
                    dst += padding;
                }
            }
            // Unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        public static void espelhoHorizontalDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            // Lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int offsetX = width - x - 1;
                        int offsetY = y;

                        // Calcula a posição do pixel na imagem de origem
                        int srcOffset = offsetY * bitmapDataSrc.Stride + offsetX * pixelSize;

                        // Copia os pixels da imagem de origem para a imagem destino invertendo horizontalmente
                        *(dst++) = *(src + srcOffset);     // R
                        *(dst++) = *(src + srcOffset + 1); // G
                        *(dst++) = *(src + srcOffset + 2); // B
                    }
                    dst += padding;
                }
            }
            // Unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        public static void pretobrancoDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            Int32 media;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++); //está armazenado dessa forma: b g r 
                        g = *(src++);
                        r = *(src++);
                        media = (Int32)(r+g+b)/3;
                        if(media > 127)
                        {
                            media = 255;
                        }
                        else
                        {
                            media = 0;
                        }
                        *(dst++) = (byte)media;
                        *(dst++) = (byte)media;
                        *(dst++) = (byte)media;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        public static void rotacao90DMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            // Lock dados bitmap origem 
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, height, width),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Calcula a posição do pixel na imagem de origem
                        int srcOffset = y * bitmapDataSrc.Stride + x * pixelSize;

                        // Calcula a posição do pixel na imagem destino rotacionada
                        int dstOffset = x * bitmapDataDst.Stride + (height - y - 1) * pixelSize;

                        // Copia os pixels da imagem de origem para a imagem destino rotacionada
                        *(dst + dstOffset) = *(src + srcOffset);     // R
                        *(dst + dstOffset + 1) = *(src + srcOffset + 1); // G
                        *(dst + dstOffset + 2) = *(src + srcOffset + 2); // B
                    }
                }
            }
            // Unlock imagem origem 
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        public static void InverterCanaisRBDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            // Lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte b = *(src++); // Está armazenado dessa forma: b g r
                        byte g = *(src++);
                        byte r = *(src++);

                        // Inverter canais R (vermelho) e B (azul)
                        *(dst++) = r;
                        *(dst++) = g;
                        *(dst++) = b;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            // Unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }

        public static void EspelhoDiagonalDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;

            // Lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int paddingSrc = bitmapDataSrc.Stride - (width * pixelSize);
            int paddingDst = bitmapDataDst.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte b = *(src++); // Está armazenado dessa forma: b g r
                        byte g = *(src++);
                        byte r = *(src++);

                        int tempx, tempy;
                        tempx = (width - 1) - x;
                        tempy = (height - 1) - y;

                        dst = (byte*)bitmapDataDst.Scan0 + (tempy * bitmapDataDst.Stride + tempx * pixelSize);

                        *(dst++) = b;
                        *(dst++) = g;
                        *(dst++) = r;
                    }
                    src += paddingSrc;
                    dst += paddingDst;
                }
            }
            // Unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }


        public static void DividirMontarComDMA(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int meioaltura = height / 2;
            int meiolargura = width / 2;

            // Lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // Lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int strideSrc = bitmapDataSrc.Stride;
            int strideDst = bitmapDataDst.Stride;

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                for (int y = 0; y < meioaltura; y++)
                {
                    for (int x = 0; x < meiolargura; x++)
                    {
                        byte* srcPixel1 = src + (y * strideSrc) + (x * 3);
                        byte* srcPixel2 = src + ((meioaltura + y) * strideSrc) + (x * 3);

                        byte* srcPixel3 = src + (y * strideSrc) + ((meiolargura + x) * 3);
                        byte* srcPixel4 = src + ((meioaltura + y) * strideSrc) + ((meiolargura + x) * 3);

                        byte* dstPixel1 = dst + (y * strideDst) + (x * 3);
                        byte* dstPixel2 = dst + ((meioaltura + y) * strideDst) + (x * 3);

                        byte* dstPixel3 = dst + (y * strideDst) + ((meiolargura + x) * 3);
                        byte* dstPixel4 = dst + ((meioaltura + y) * strideDst) + ((meiolargura + x) * 3);

                        for (int i = 0; i < 3; i++) // 3 bytes per pixel (R, G, B)
                        {
                            byte temp1 = *(srcPixel1 + i);
                            *(dstPixel1 + i) = *(srcPixel4 + i);
                            *(dstPixel4 + i) = temp1;

                            byte temp2 = *(srcPixel2 + i);
                            *(dstPixel2 + i) = *(srcPixel3 + i);
                            *(dstPixel3 + i) = temp2;
                        }
                    }
                }
            }
            // Unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            // Unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }



    }
}
