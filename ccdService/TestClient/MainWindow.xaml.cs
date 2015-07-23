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

        private async void button_Click(object sender, RoutedEventArgs e)
        {
           var result = await  restclient.GetAllPictures();


            foreach(var pic in result)
            {

            }
           
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\feisele\Pictures\IMG_7455.jpg";

            var fileContent = File.ReadAllBytes(filePath);

            Picture newPicture = new Picture();
            
            newPicture.Description = "testPic2";
            newPicture.Name = "asdfasd";
            newPicture.Details = new PictureDetails();
            newPicture.Details.Position.Altitude = 54.03;
            newPicture.Details.Position.Longitude = 10;
            newPicture.Details.Content = fileContent;
            

            restclient.UploadNewPicture(newPicture);
        }
    }
}
