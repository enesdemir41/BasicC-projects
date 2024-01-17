using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace GPFinalEnesDemir202151501062
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //variables
        int bas, bit, sayi;
        int[] benzersizkulsayi = new int[5];
        int[] benzersizpcsayi = new int[10];
        Random rastgelesayi = new Random();
        WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();

        



        private void button1_Click(object sender, EventArgs e)
        {
            // baslangic ve bitis degerleri
            bas = int.Parse(textBox1.Text);
            bit = int.Parse(textBox2.Text);

            // degerler ters verilmiş ise 
            if (bas > bit)
            {
                int yer1 = bas;
                bas = bit;
                bit = yer1;

                textBox1.Text = bas.ToString();
                textBox2.Text = bit.ToString();
                MessageBox.Show("Aralıklar ters düzeltiliyor.");

            }

            // kullanıcıdan sayılarını al 
            for (int i = 0; i < benzersizkulsayi.Length; i++)
            {
                sayi = int.Parse(Interaction.InputBox($"{i + 1}. tahmininizi giriniz", "sayi  Ekranı", "Bu kısma sayi giriniz", 200, 200));
                if (sayi < bas || sayi > bit)
                {

                    MessageBox.Show("belirttiğiniz aralıktan farklı bir giriş yaptınız");
                    i--;
                }
                else if (Array.IndexOf(benzersizkulsayi, sayi) == -1)
                {
                    benzersizkulsayi[i] = sayi;
                    listBox1.Items.Add(sayi);

                }
                else
                {
                    MessageBox.Show("Bu sayıyı daha önce girdiniz veya geçersiz bir sayı girişi yaptınız. Lütfen farklı bir sayı giriniz.");
                    i--;
                }
            }


            // pc rastgele 10 benzersiz sayı üretsin
            for (int i = 0; i < benzersizpcsayi.Length; i++)
            {
            buraya:
                int rastsayi = rastgelesayi.Next(bas, bit);

                foreach (var item in benzersizpcsayi)
                {
                    if (item == rastsayi)
                    {
                        goto buraya;
                    }

                }
                benzersizpcsayi[i] = rastsayi;
                listBox2.Items.Add(rastsayi);
            }

            sonuc(); // kontrol fonksiyonuna git
        }


       public void sonuc()
        {
            int eslesen = 0;

            // ortak olanları bul ve esleseni 1 arrtır 
            for (int i = 0; i < benzersizpcsayi.Length; i++)
            {
                for (int j = 0; j < benzersizkulsayi.Length; j++)
                {
                    if (benzersizpcsayi[i] == benzersizkulsayi[j])
                    {
                        eslesen++;
                        break;
                    }
                }
            }

            label6.Text = eslesen.ToString(); // eslesenleri yazdır



            if (eslesen == 5)
            {
                MessageBox.Show("“BİZ KAVUŞTUK");
                mediaPlayer.URL = @"D:\\music\\music1.mp3";
                mediaPlayer.controls.play();

            }
            else if (eslesen == 0)
            {
                MessageBox.Show("Elbet Birgün.");
                mediaPlayer.URL = @"D:\\music\\music1.mp3";
                mediaPlayer.controls.play();
            }
            else
            {
                MessageBox.Show("Bir İhtimal");
                mediaPlayer.URL = @"D:\\music\\music1.mp3";
                mediaPlayer.controls.play();
            }
        }
    }
}
