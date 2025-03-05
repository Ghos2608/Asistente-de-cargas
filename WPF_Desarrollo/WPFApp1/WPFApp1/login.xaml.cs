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
using System.Windows.Shapes;

namespace WPFApp1
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
            Conexion op = new Conexion();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string matricula = matriculatbx.Text;
            string password = passwordtxb.Text;

            MessageBox.Show($"matricula: {matriculatbx}, Contraseña: {passwordtxb}");


            Conexion conex = new Conexion();


            if (conex.ValidarUsuario(matricula, password))
            {
                MessageBox.Show("INGRESO CON EXITO");
            }
            else
            {
                MessageBox.Show("Matricula y contraseña incorrectos");
            }  
        } 
        private void bttregistro_Click(object sender, RoutedEventArgs e)
        {
            string matricula = matriculaTextBox1.Text;
            string name = tbxnombres.Text;
            string apaterno = txbapellidoparterno.Text;
            string amaterno = txbapellidomaterno.Text;
            string email = txbemail.Text;
            string contraseña =txbpassword.Text;
            DateTime fecha = DateTime.Now;

            Conexion cxn = new Conexion();

            if (cxn.AgregarUsuario(matricula, name, apaterno, amaterno, email, contraseña, fecha))
            {
                MessageBox.Show("Registro con exito");
                matriculaTextBox1.Clear();
                tbxnombres.Clear();
                txbapellidoparterno.Clear();
                txbapellidomaterno.Clear();
                txbemail.Clear();
                txbpassword.Clear();
            }
            else
            {
                MessageBox.Show("Registro fallido");
            }

            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stackpanellogin.Visibility = Visibility.Collapsed;
            Stackloginup.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Stackloginup.Visibility = Visibility.Collapsed;
            stackpanellogin.Visibility = Visibility.Visible;
        }

       
    }
}
