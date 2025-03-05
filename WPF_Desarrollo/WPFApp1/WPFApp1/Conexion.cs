using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WPFApp1
{
    class Conexion
    {
        private MySqlConnection conexion;
        private string cadenadeconexion;
        public Conexion()
        {
            cadenadeconexion = "Server=localhost; Port=3306; Database=upload_system; Uid=root; Pwd=";
            conexion = new MySqlConnection(cadenadeconexion);
        }
        /*public bool conectar()
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error al conectarse a la base de datos" + ex.Message);
                    return false;
                }
            }*/

        public bool ValidarUsuario(string matriculatbx, string passwordtxb)
        {
            try
            {
                using (var connection = new MySqlConnection(cadenadeconexion))
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa");

                    var query = "SELECT COUNT(*) FROM user_login WHERE matricula = @Matricula AND user_password = @Contraseña";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Matricula", MySqlDbType.VarChar).Value = matriculatbx;
                        command.Parameters.Add("@Contraseña", MySqlDbType.VarChar).Value = passwordtxb;

                        var result = command.ExecuteScalar();


                        return result != null && Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
                return false;
            }
        }

        public bool AgregarUsuario(string matricula, string nameuser, string apaterno, string amaterno, string email, string password, DateTime fecha)
        {
            try
            {
                

                using (var connection = new MySqlConnection(cadenadeconexion))
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa");

                    
                    var query = "INSERT INTO user_login(matricula, name_user, apellido_paterno, apellido_materno, user_email, user_password, registration_date) VALUES(@matricula, @nombres, @apaterno, @amaterno, @email, @contraseña, @registration);";

                    using (var command = new MySqlCommand(query, connection))
                    {
                      
                        command.Parameters.Add("@matricula", MySqlDbType.VarChar).Value = matricula;
                        command.Parameters.Add("@nombres", MySqlDbType.VarChar).Value = nameuser;
                        command.Parameters.Add("@apaterno", MySqlDbType.VarChar).Value = apaterno;
                        command.Parameters.Add("@amaterno", MySqlDbType.VarChar).Value = amaterno;
                        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                        command.Parameters.Add("@contraseña", MySqlDbType.VarChar).Value = password;
                        command.Parameters.Add("@registration", MySqlDbType.DateTime).Value = fecha;

                        int result = command.ExecuteNonQuery();
                        return result > 0; 

                        
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Ocurrió un error: " + ex.Message);
                return false;
            }
        }
    }


    
}
