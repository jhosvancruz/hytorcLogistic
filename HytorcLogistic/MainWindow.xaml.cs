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
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows.Threading;

namespace HytorcLogistic
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conexion = new SqlConnection();
        internal DispatcherTimer timer = new DispatcherTimer();
        private bool IsConnected { get; set; }
        private Thread ConexionThread;
        private int FlagThreadConexion = 0;
        public MainWindow()
        {
            InitializeComponent();
            ConexionThread = new Thread(new ThreadStart(ConnectWithDBHosting));
            TimerConexion();
            //calendar.SelectedDate = new DateTime(2019,01,03);
            calendar.SelectedDatesChanged += Calendar_SelectedDatesChanged;
            //SendMail("prueba número 1 Mail enviado desde Alebrijes Ventas");

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var a in e.AddedItems)
            {
                Debug.WriteLine(a);
            }
            //throw new NotImplementedException();
        }
        private void TimerConexion()
        {
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += (s, a) =>
            {
                if (IsConnected)
                    timer.Interval = new TimeSpan(0, 1, 0);
                else
                    timer.Interval = new TimeSpan(0, 0, 3);

                if (FlagThreadConexion == 0)
                    ConexionThread.Start();
                else if (FlagThreadConexion == 2)
                {
                    ConexionThread = null;
                    ConexionThread = new Thread(new ThreadStart(ConnectWithDBHosting));
                    ConexionThread.Start();
                }

            };
            timer.Start();
        }

        private void ConnectWithDBHosting()
        {
            FlagThreadConexion = 1;
            string conexionstring = "Data Source=alebrijesventas.com; User ID=administrator_sql; Password=JhosTaker..2018; Initial Catalog=ventas; Integrated Security=false";
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                conexion.ConnectionString = conexionstring;
                conexion.Open();
                IsConnected = true;
                Dispatcher.Invoke(() =>
                {
                    statusLabel.Content = "Online";
                    statusLabel.Foreground = new SolidColorBrush(Colors.Green);
                });

            }
            catch (SqlException ex)
            {
                Dispatcher.Invoke(() =>
                {
                    statusLabel.Content = "Off line";
                    statusLabel.Foreground = new SolidColorBrush(Colors.Red);
                });
                IsConnected = false;
            }
            FlagThreadConexion = 2;
        }
        private void QueryResults()
        {
            //string query =  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsConnected)
                conexion.Close();
            if (FlagThreadConexion == 1)
            {
                ConexionThread.Suspend();
                ConexionThread = null;
            }

        }
       public void SendMail(string e)
        {
            var fromAddress = new MailAddress("admin@alebrijesventas.com", "Administrador");
            var toAddress = new MailAddress("jhosvan@hotmail.com", "Jhosvan Cruz");
            string fromPassword = "ja060892";
            string subject = "correo de prueba";
            string body = e;

            var smtp = new SmtpClient
            {
                Host = "mail.alebrijesventas.com",
                Port = 587,
                EnableSsl = false,
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
                //message.Attachments.Add(); //Para adjuntar archivos en el correo.
                smtp.Send(message);
            }
            //string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"cid:Pic1\"></body></html>";
            //AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            //    (htmlBody, null, MediaTypeNames.Text.Html);

            //// Create a LinkedResource object for each embedded image
            //LinkedResource pic1 = new LinkedResource(@"C:\Users\Software02\Documents\Alebrijes\logo-alebrijes.png", MediaTypeNames.Image.Jpeg);
            //pic1.ContentId = "logo";
            //avHtml.LinkedResources.Add(pic1);


            //// Add the alternate views instead of using MailMessage.Body
            //MailMessage m = new MailMessage();
            //m.AlternateViews.Add(avHtml);

            //// Address and send the message
            //m.From = new MailAddress("admin@alebrijesventas.com", "Jhosvan Cruz");
            //m.To.Add(new MailAddress("jhosvan@hotmail.com", "Zamtest"));
            //m.Subject = "A picture using alternate views";

            //SmtpClient client = new SmtpClient("alebrijesventas.com");
            //try
            //{
            //    client.Port = 25;
            //    client.Send(m);
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.Message);
            //}

        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (!IsConnected)
                ConnectWithDBHosting();
        }
    }
}
