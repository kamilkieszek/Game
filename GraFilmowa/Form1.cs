using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GraFilmowa
{
    public partial class Form1 : Form
    {
        string[] tablica = File.ReadAllLines(@"C:\Users\Kamil\Desktop\pytanie.txt");
        int indp = 0;
        int indA = 1;
        int indB = 2;
        int indC = 3;
        int indD = 4;
        int poprawna = 5;
        string poprawnaodp;
        Label przyklad = new Label();             
        Label pytanie = new Label();
        Button odpA = new Button();
        Button odpB = new Button();
        Button odpC= new Button();
        Button odpD = new Button();
        Button zatwierdz = new Button();
        Label wyn = new Label();
        int wynik = 0;
        int licznik = 0;
        
private void zaznacz(object sender, EventArgs ea)
        {
            if (odpA.BackColor == Color.GreenYellow && odpB.BackColor == Color.GreenYellow &&
                odpC.BackColor == Color.GreenYellow && odpD.BackColor == Color.GreenYellow)
            {
                ((Button)sender).BackColor = Color.Yellow;
                licznik++;
            }                       
            if (odpA.BackColor == Color.Yellow || odpB.BackColor == Color.Yellow ||
                odpC.BackColor == Color.Yellow || odpD.BackColor == Color.Yellow)
            {
                zatwierdz.Visible = true;
            }
        }
    /* private void odznacz(object sender, EventArgs ae)
        {
          if(((Button)sender).BackColor == Color.Yellow)
            {
                ((Button)sender).BackColor = Color.GreenYellow;
            }
        }     */ 


        private void spr (object sender, EventArgs dd)
        {
            if (licznik > 0)
            {
                if (przyklad.Text == odpA.Text & odpA.BackColor == Color.Yellow || przyklad.Text == odpB.Text & odpB.BackColor == Color.Yellow ||
                    przyklad.Text == odpC.Text & odpC.BackColor == Color.Yellow || przyklad.Text == odpD.Text & odpD.BackColor == Color.Yellow)
                {
                    var ok = MessageBox.Show("Zdobywasz 1 punkt ! Aby przejść do następnego pytania kliknij OK !",
                "Brawo !", MessageBoxButtons.OK);
                    if (ok == DialogResult.OK)
                    {
                        if (tablica[indp] == "0")
                        {
                            var rf = MessageBox.Show("Wynik: ", "Koniec gry!", MessageBoxButtons.OK);
                            if (rf == DialogResult.OK)
                            {
                                Application.Exit();
                            }
                        }
                        else
                        {
                            pytanie.Text = tablica[indp += 6];
                            odpA.Text = tablica[indA += 6];
                            odpB.Text = tablica[indB += 6];
                            odpC.Text = tablica[indC += 6];
                            odpD.Text = tablica[indD += 6];
                            przyklad.Text = tablica[poprawna += 6];
                            wynik++;
                            wyn.Text = "Wynik: " + wynik;
                            odpA.BackColor = Color.GreenYellow;
                            odpB.BackColor = Color.GreenYellow;
                            odpC.BackColor = Color.GreenYellow;
                            odpD.BackColor = Color.GreenYellow;
                        }
                    }
                }
                else
                {
                    var ok1 = MessageBox.Show("Zła odpowiedź! Masz -1 punkt! Aby przejść do następnego pytania kliknij OK!",
                "Błąd!", MessageBoxButtons.OK);
                    if (ok1 == DialogResult.OK)
                    {
                        pytanie.Text = tablica[indp += 6];
                        odpA.Text = tablica[indA += 6];
                        odpB.Text = tablica[indB += 6];
                        odpC.Text = tablica[indC += 6];
                        odpD.Text = tablica[indD += 6];
                        przyklad.Text = tablica[poprawna += 6];
                        wynik--;
                        wyn.Text = "Wynik: " + wynik;
                        odpA.BackColor = Color.GreenYellow;
                        odpB.BackColor = Color.GreenYellow;
                        odpC.BackColor = Color.GreenYellow;
                        odpD.BackColor = Color.GreenYellow;
                    }
                }
            }
            else
            {
                ;
            }
        }


        public Form1()
        {
            Text = "Quiz";
            Height = 500;
            Width = 700;
            //BackgroundImage = @"C:\Users\Kamil\Desktop\tapeta.jpg";
            InitializeComponent();
            int szerpytania = 200;
            int wyspytania = 50;
            poprawnaodp = tablica[poprawna];
                        
            pytanie.Text = tablica[indp];
            pytanie.Width = 400;
            pytanie.Top = 60;
            pytanie.Left = (ClientSize.Width - pytanie.Width) / 2;
            pytanie.AutoSize = true;

            przyklad.Text = tablica[poprawna];
            przyklad.Top = 450;
            przyklad.Left = 500;
            przyklad.Visible = false;

            odpA.Text = tablica[indA];
            odpA.AutoSize = true;
            odpA.Width = szerpytania;
            odpA.Top = 130;
            odpA.Left =(ClientSize.Width / 2 - odpA.Width) / 2;
            odpA.Height = wyspytania;
            odpA.Click += zaznacz;
            //odpA.Click += odznacz;
            odpA.BackColor = Color.GreenYellow;

            odpB.Text = tablica[indB];
            odpB.AutoSize = true;
            odpB.Width = szerpytania;
            odpB.Top = 130;
            odpB.Left = ClientSize.Width - (odpB.Width + odpB.Width/2);
            odpB.Height = wyspytania;          
            odpB.Click += zaznacz;
            //odpB.Click += odznacz;
            odpB.BackColor = Color.GreenYellow;

            odpC.Text = tablica[indC];
            odpC.AutoSize = true;
            odpC.Width = szerpytania;
            odpC.Height = wyspytania;
            odpC.Top = 300;
            odpC.Left = (ClientSize.Width / 2 - odpC.Width)/2;
            odpC.Click += zaznacz;
            //odpC.Click += odznacz;
            odpC.BackColor = Color.GreenYellow;

            odpD.Text = tablica[indD];
            odpD.Width = szerpytania;
            odpD.Height = wyspytania;
            odpD.Top = 300;
            odpD.Left = ClientSize.Width - (odpD.Width + odpD.Width / 2);
            odpD.Click += zaznacz;
            //odpD.Click += odznacz;
            odpD.BackColor = Color.GreenYellow;

            zatwierdz.Text = "Zatwierdź";
            zatwierdz.Top = 400;           
            zatwierdz.Height = 50;
            zatwierdz.Width = 200;
            zatwierdz.Left = (ClientSize.Width - zatwierdz.Width) / 2;
            zatwierdz.AutoSize = true;
            zatwierdz.Visible = false;
            zatwierdz.Click += spr;

            wyn.Text = "Wynik: " + wynik;
            wyn.Top = 40;
            wyn.Left = 600;
            wyn.AutoSize = true;

            Controls.Add(pytanie);
            Controls.Add(odpA);
            Controls.Add(odpB);
            Controls.Add(odpC);
            Controls.Add(odpD);
            Controls.Add(zatwierdz);
            Controls.Add(przyklad);
            Controls.Add(wyn);       

        }

   
    }
}
