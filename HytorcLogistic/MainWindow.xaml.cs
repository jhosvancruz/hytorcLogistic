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
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
namespace HytorcLogistic
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conexion = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();

            Connect();
            SendMail("<h2>prueba número 1<\\h2> Mail enviado desde Hytorc Logistic");
        }

        private void Connect()
        {
            
            string conexionstring = "Data Source=DESKTOP-I7TFU8J\\SQLEXPRESS; Initial Catalog=test; Integrated Security=True";
            try
            {
                conexion.ConnectionString = conexionstring;
                conexion.Open();
                MessageBox.Show("Conexión Éxitosa!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Mensaje: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void QueryResults()
        {
            //string query =  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            conexion.Close();
        }
       public void SendMail(string e)
        {
            var fromAddress = new MailAddress("jhosvan@hotmail.com", "Jhosvan Cruz");
            var toAddress = new MailAddress("jhosvan@hotmail.com", "Mi");
            const string fromPassword = "JhosTaker..";
            const string subject = "an error ocurred";
            string body = e;

            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
    }
}
