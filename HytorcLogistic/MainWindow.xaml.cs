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
using System.Net.Mime;

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
            //Connect();
            SendMail("prueba número 1 Mail enviado desde Hytorc Logistic");

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
            var fromAddress = new MailAddress("ecruz@hytorc.com.mx", "Esteban Cruz");
            var toAddress = new MailAddress("jhosvan@hotmail.com", "Mi");
            const string fromPassword = "Eqt*3279&";
            const string subject = "an error ocurred";
            string body = e;

            var smtp = new SmtpClient
            {
                Host = "smtp.office365.com",
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
            //string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"cid:Pic1\"></body></html>";
            //AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            //    (htmlBody, null, MediaTypeNames.Text.Html);

            //// Create a LinkedResource object for each embedded image
            //LinkedResource pic1 = new LinkedResource(@"C:\Users\Jhosvan\Desktop\PROYECTO HYTORC-JHOS\logocoisa.jpg", MediaTypeNames.Image.Jpeg);
            //pic1.ContentId = "logo";
            //avHtml.LinkedResources.Add(pic1);


            //// Add the alternate views instead of using MailMessage.Body
            //MailMessage m = new MailMessage();
            //m.AlternateViews.Add(avHtml);

            //// Address and send the message
            //m.From = new MailAddress("jhosvan@hotmail.com", "Jhosvan Cruz");
            //m.To.Add(new MailAddress("jhosvan@hotmail.com", "Zamtest"));
            //m.Subject = "A picture using alternate views";

            //SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            //try
            //{
            //    client.Port = 587;
            //    client.Send(m);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void buttonLauncher_Click(object sender, RoutedEventArgs e)
        {
            Notificaction noty = new Notificaction("Se lanzó una notificación!", Notificaction.ICON_FILES.HAPPY);
            noty.ShowDialog();
            GC.SuppressFinalize(noty);
        }
    }
}
