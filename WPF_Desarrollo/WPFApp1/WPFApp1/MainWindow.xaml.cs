using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WPFApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
     

        login windows = new login();
        windows.Show();

        this.Close();
    }

    private void CheckDatabaseConnection()
    {
        string connectionString = "Server=localhost; Port=3306; Database=upload_system; Uid=root; Pwd=;";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MessageBox.Show("Conexión exitosa a la base de datos.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
        }
    }

    
}