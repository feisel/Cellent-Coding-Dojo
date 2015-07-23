using System;
using System.Collections.Generic;
using System.IO;
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

namespace TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestClient restclient = new RestClient();

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            restclient.RunAsync();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\feisele\Pictures\IMG_7455.jpg";

            var fileContent = File.ReadAllBytes(filePath);

            Picture newPicture = new Picture();
            newPicture.Content = fileContent;
            newPicture.Description = "testPic2";
            newPicture.Name = "asdfasd";

            restclient.UploadNewPicture(newPicture);
        }
    }
}
