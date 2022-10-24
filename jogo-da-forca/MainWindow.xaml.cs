using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jogo_da_forca
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        string a = "";
        string b = "";
        string c = "";
        string d = "";
        string e = "";
        string f = "";
        string g = "";
        string palavraInformada = "";
        string acertosDaPalavra = "";
        int totalErros = 0;
        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
            foreach (char i in txtPalavra.Text.ToString())
            {
                palavraInformada += i;
                acertosDaPalavra += "*";

            }

            txtPalavra.MaxLength = 1;

            btnJogar.Visibility = Visibility.Hidden;
            btnInserirLetra.Visibility = Visibility.Visible;

            txtFrase.Text = "";
            txtFrase.Text = acertosDaPalavra;
            txtPalavra.Text = "";
        }
        private void InserirLetra(object sender, RoutedEventArgs e)
        {
            if (txtPalavra.Text != "" && txtPalavra.Text != " ")
            {
                txtFrase.Text = "";
                bool achouLetra = false;
                string acertoTemporario = "";
                for (int i = 0; i < palavraInformada.Length; i++)
                {
                    if (txtPalavra.Text == palavraInformada[i].ToString())
                    {
                        txtFrase.Text += $"{txtPalavra.Text}";
                        acertoTemporario += txtPalavra.Text;
                        achouLetra = true;
                    }
                    else
                    {
                        txtFrase.Text += $"{acertosDaPalavra[i]}";
                        acertoTemporario += acertosDaPalavra[i];
                    }

                }
                acertosDaPalavra = acertoTemporario;
                if (achouLetra == false)
                {

                    totalErros++;
                    CalculaErros();

                }
                txtPalavra.Text = "";
                VerificaVitoria();
            }
        }
        private void ReiniciarJogo(object sender, RoutedEventArgs e)
        {
            EstadosIniciaisJogo();

        }
        private void SairDaAplicacao(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CalculaErros()
        {

            if (totalErros == 1)
            {
                txtCabeca.Visibility = Visibility.Visible;
                a = txtPalavra.Text;
                txtLetrasErradas.Text = a;
                totalErros = 1;
            }
            if (totalErros == 2)
            {
                b = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f)
                {
                    txtLetrasErradas.Text += b;
                    txtCorpo.Visibility = Visibility.Visible;
                    totalErros = 2;
                }
                else
                {
                    totalErros = 1;
                }
            }
            if (totalErros == 3)
            {
                c = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f && b != c && b != d && b != e && b != f)
                {
                    txtLetrasErradas.Text += c;
                    txtBracoEsquerdo.Visibility = Visibility.Visible;
                    totalErros = 3;
                }
                else
                {
                    totalErros = 2;
                }
            }
            if (totalErros == 4)
            {
                d = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f && b != c && b != d && b != e && b != f && c != d && c != e && c != f)
                {
                    txtLetrasErradas.Text += d;
                    txtBracoDireito.Visibility = Visibility.Visible;
                    totalErros = 4;
                }
                else
                {
                    totalErros = 3;
                }
            }
            if (totalErros == 5)
            {
                e = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f && b != c && b != d && b != e && b != f && c != d && c != e && c != f && d != e && d != f)
                {
                    txtLetrasErradas.Text += e;
                    txtPernaEsquerda.Visibility = Visibility.Visible;
                    totalErros = 5;
                }
                else
                {
                    totalErros = 4;
                }
            }
            if (totalErros == 6)
            {
                f = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f && b != c && b != d && b != e && b != f && c != d && c != e && c != f && d != e && d != f && e != f)
                {
                    txtLetrasErradas.Text += f;
                    txtPernaDireita.Visibility = Visibility.Visible;
                    totalErros = 6;
                }
                else
                {
                    totalErros = 5;
                }
            }
            if (totalErros == 7)
            {
                g = txtPalavra.Text;
                if (a != b && a != c && a != d && a != e && a != f && b != c && b != d && b != e && b != f && c != d && c != e && c != f && d != e && d != f && e != f && g != a && g != b && g != c && g != d && g != e && g != f)
                {
                    txtLetrasErradas.Text += g;
                    totalErros = 7;
                    MessageBox.Show("Você perdeu!", "Game Over!", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnInserirLetra.Visibility = Visibility.Hidden;
                    btnReiniciarJogo.Visibility = Visibility.Visible;
                    txtPalavra.Focusable = false;
                }
                else
                {
                    totalErros = 6;
                }
            }
        }

        private void VerificaVitoria()
        {
            if (acertosDaPalavra == palavraInformada)
            {
                MessageBox.Show("Você Ganhou!", "Parabéns!", MessageBoxButton.OK, MessageBoxImage.Information);
                btnInserirLetra.Visibility = Visibility.Hidden;
                btnReiniciarJogo.Visibility = Visibility.Visible;
                txtPalavra.Focusable = false;
            }
        }

        private void EstadosIniciaisJogo()
        {
            a = "";
            b = "";
            c = "";
            d = "";
            e = "";
            f = "";
            g = "";
            btnReiniciarJogo.Visibility = Visibility.Hidden;
            btnJogar.Visibility = Visibility.Visible;
            txtPalavra.MaxLength = 200;
            txtBracoDireito.Visibility = Visibility.Hidden;
            txtBracoEsquerdo.Visibility = Visibility.Hidden;
            txtPernaDireita.Visibility = Visibility.Hidden;
            txtPernaEsquerda.Visibility = Visibility.Hidden;
            txtCorpo.Visibility = Visibility.Hidden;
            txtCabeca.Visibility = Visibility.Hidden;

            txtLetrasErradas.Text = "";
            txtFrase.Text = "";
            txtPalavra.Focusable = true;
            acertosDaPalavra = "";
            palavraInformada = "";
            totalErros = 0;
        }
    }
}