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


            

            if (radioButton1.Checked)
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



            if ( radioButton2.Checked ) {
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
            
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Lüften cinsiyet seçiniz");
            }
         
        }
    }
}
