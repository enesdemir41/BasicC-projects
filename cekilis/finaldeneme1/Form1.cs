using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace finaldeneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList katilimcilar = new ArrayList();                   // Katilimcilar isminde bir liste oluşturduk
        string katilimciismi;                                       // ınputboxtan alınan kullanıcı isimleri kullaniciismi değişkeni olacak
        int yedekno;                                                // yedek talihliler için rastegele sayıların tutulacağı değişkenimiz
        int kazananno;                                              // asıl kazananlarımı için rastgele sayıların tutulacağı değişkenimiz
        Random rastgelesayi = new Random();                         // rastegele sayı üretme 
        int kackisi;                                                // kullanıcan alacagımız kac kazananın olacagının bilgisini tutan değişkenimiz
        int talihli;                                                // kullanıcan alacagımız kac talihki olacagının bilgisini tutan değişkenimiz
        ArrayList yedekKazananlar = new ArrayList();                // yedek kazananlarımız için isminde bir liste oluşturduk
        string cikis;                                               // kullanıcıdan çıkış anahtırımızı oluşturmak için ve bu degeri tutmak için değişkenimiz



        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            button2.Visible = false;
            listBox2.Visible = false;
            label2.Visible = false;
            label6.Visible = false;
            listBox3.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            button3.Visible = false;





        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {






                cikis = Interaction.InputBox("Çeklişten çıkmak için bir anahtar girin", "Çekilişten Sonlandırma Anahtarı", "Buraya  giriniz", 200, 200).ToString(); // kullanıcı eklemeyi sonlardırmak için anahtarı ınputbox ile alacagız

                for (; ; ) // sonuz döngümüzü oluşturduk çünkü kullanıcı istediği kadar kullanıcı ismi girebilsin diye
                {


                    katilimciismi = Interaction.InputBox("kullanıcı girişi", "Ekleme Ekranı", "Bu kısma isimleri giriniz", 200, 200);// ınputbox ile kullanıcıdan katılımcıları aldık
                    if (katilimciismi == cikis || katilimciismi == cikis)// kullanıcın belirlediği bir anahtar ile donguden cık
                    {
                        button2.Visible = true; // başta gözükmeyen 
                        break;

                    }
                    else
                    {
                        katilimcilar.Add(katilimciismi);// katılımcılar arrayine katılımcı isimlerini  ekle
                        listBox1.Items.Add(katilimciismi);// lisboxta yazdır

                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Geçerli Formatta Sayı giriniz");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Girilen Tanımlı aralıkta değil");
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Belirtilenden fazla giriş yapıldı");
            }



        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            textBox2.Visible = true;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Visible = false;
            textBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton1.Checked) // eğer kullanıcımız yedek kazananlar isterse assagıdakki kodlar calısacak
                {

                    kackisi = int.Parse(textBox1.Text); // kaç kişinin kazanacagını kullanıcan textbox1 ile aldık
                    talihli = int.Parse(textBox2.Text); // kaç talihli olacagı bilgisini textboz2 ile kullanıcıdan aldık
                    string[] yedekler = new string[talihli]; // yedeklar adında bir dizi oluştur yedeklerimiz bu dizi içinde olacak ve boyutu ise kullanıcın girdiği boyutta olacak
                    string[] kazananlar = new string[kackisi];// kaç kişi kazancaksa o kadar yer açsın kazananlar adında bir dizi oluştur kazannanlarımız bu dizi içinde olacak ve boyutu ise kullanıcın girdiği boyutta olacak

                    if (talihli > kackisi) // eğer yedek talihlilerimizin sayısı kazanacak kişi sayısından fazla olursa assada ki uyarı meydana gelecek
                    {
                        MessageBox.Show("Yedek Talihliler kazanacak sayısından fazla olamaz", "Uyarı", MessageBoxButtons.OK);
                    }
                    else   // eğer olmazsa assagıdaki kodlar calısacak
                    {
                        for (int i = 0; i <= kackisi - 1; i++) // döngümüzü kurduk kaç kişiye sayısı - 1  kadar çalışacak . -1 olmasının sebebi indekslerin 0 dan başlamasıdır 
                        {

                            kazananno = rastgelesayi.Next(0, katilimcilar.Count);// kazananlara rastgele numara verdik
                            kazananlar[i] = katilimcilar[kazananno].ToString();// kazananlara  katilimcilar listesindeki kazananno adlıları ekle
                            katilimcilar.RemoveAt(kazananno);// katilimcilar listesinden kaznannoları sil
                            listBox2.Items.Add(kazananlar[i]); // kazananları lisbox2 de goster



                        }






                        for (int i = 0; i < talihli; i++)  // yukarıdaki işlemi birde yedek talihlilermiz için yaptık
                        {

                            //zaten katilimcilar adli listeden kaznanlarımız çıktığı güncellememize gerek yok 

                            yedekno = rastgelesayi.Next(0, katilimcilar.Count);//yedeklere rastgele numara verdik
                            yedekler[i] = katilimcilar[yedekno].ToString();    // yedeklere  katilimcilar listesindeki yedekno adlıları ekle
                            katilimcilar.RemoveAt(yedekno);                    // katilimcilar listesinden yedeknoları sil
                            listBox3.Items.Add(yedekler[i]);                   //// kazananları lisbox2 de goster

                        }

                        MessageBox.Show("Çekilişiniz Yapıldı");
                        button3.Visible = true;
                    }


                }
                else // kullanıcımız yedek kazananlar istemezse aşşagıdaki kodlarımız calısaacak
                {

                    kackisi = int.Parse(textBox1.Text);
                    string[] kazananlar = new string[kackisi];// kaç kişi kazancaksa o kadar yer açsın
                    for (int i = 0; i <= kackisi - 1; i++)
                    {

                        kazananno = rastgelesayi.Next(0, katilimcilar.Count);// kazananlara numara ver
                        kazananlar[i] = katilimcilar[kazananno].ToString();// kazananların i. indeklilerini katilimcilar listesindeki kazananno adlıları ekle
                        katilimcilar.RemoveAt(kazananno);// katilimcilar listesinden kaznannolaro sil
                        listBox2.Items.Add(kazananlar[i]); // kazananları lisbox2 de goster


                    }

                    MessageBox.Show("Çekilişiniz Yapıldı");
                    
                    button3.Visible = true;

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Geçerli Formatta Sayı giriniz");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Girilen Tanımlı aralıkta değil");
            }

            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Belirtilenden fazla giriş yapıldı");
            }



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            label2.Visible = true;
            listBox3.Visible = true;
            label6.Visible = true;
        }
    }


  
    
}

