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

namespace HytorcLogistic
{
    /// <summary>
    /// Lógica de interacción para Notificaction.xaml
    /// </summary>
    
    public partial class Notificaction : Window
    {
        public enum ICON_FILES
        {
            ADD = 1,
            NOTIFICATION,
            MAIL,
            HAPPY,
            SAVE,
            ARROW_DOWN
        }
        public Notificaction(string message, ICON_FILES icon)
        {
            InitializeComponent();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            labelMessage.Content = message;
            if (icon == ICON_FILES.NOTIFICATION)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_About_error_notification_help_info_information_1886031.png");
            if (icon == ICON_FILES.ADD)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_Add_character_include_more_person_user_1886171.png");
            if (icon == ICON_FILES.MAIL)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_4_330394.png");
            if (icon == ICON_FILES.HAPPY)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_338Big_emoji_face_happy_smile_smiley_1886033.png");
            if (icon == ICON_FILES.SAVE)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_188Backup_disk_data_data_storage_floppy_save_1886186.png");
            if (icon == ICON_FILES.ARROW_DOWN)
                img.UriSource = new Uri("pack://application:,,,/Resources/if_118Arrow_down_download_downloads_downloading_save_1886132.png");
            img.EndInit();
            imageIcon.Source = img;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            GC.SuppressFinalize(this);
        }
    }
}
