using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double boy, kilo, sonuc, durumunuz;


            

            if (radioButton1.Checked)//Button 1 yani erkek seçilyse aşşağıdaki hesaplamaları yapacak
            {
                boy = Convert.ToDouble(textBox1.Text);// Textboxtan alınan değer double türüne değiştirildi 
                kilo = Convert.ToDouble(textBox2.Text);// text olan yerden sayı alamayız o yüzden
                boy = boy / 100;    // boyu metre cinsine aldık 
                sonuc = kilo / (boy * boy); // formül
                label3.Text = sonuc.ToString(); // Formulün sonucu
                if (sonuc < 20)// formulün sonuca göre durumlar
                {
                    label4.Text = "normal";
                }
                else
                {
                    label4.Text = "kilolusunuz";
                }
            }



            if ( radioButton2.Checked) //Button 1 yani kadın seçilyse aşşağıdaki hesaplamaları yapacak
            {
                boy = Convert.ToDouble(textBox1.Text);
                kilo = Convert.ToDouble(textBox2.Text);
                boy = boy / 100;
                sonuc = kilo / (boy * boy);
                label3.Text = sonuc.ToString();
                if (sonuc < 20)
                {
                    label4.Text = "normal";
                }
                else
                {
                    label4.Text = "kilolusunuz";
                }

            }
            
            if (radioButton1.Checked == false && radioButton2.Checked == false)// eğer radio buttonlar deger almazsa ekrana uyarı mesajı versin
            {
                MessageBox.Show("Lüften cinsiyet seçiniz", "Uyarı",MessageBoxButtons.OK) ;
            }
         
        }
    }
}
