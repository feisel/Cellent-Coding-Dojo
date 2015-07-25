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

            listBox.DisplayMemberPath = "Name";


        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
           var result = await  restclient.GetAllPictures();


            listBox.ItemsSource = result;
           
           
        }

        private async void button_DeletePicture_Click(object sender, RoutedEventArgs e)
        {
            var picture = listBox.SelectedItem as Picture;

            if (picture == null)
                return;

            await restclient.DeletePicture(picture.Id);
        }

        private async void button_GetPicture_Click(object sender, RoutedEventArgs e)
        {
            var picture = listBox.SelectedItem as Picture;

            if (picture == null)
                return;

            var pictureDetails = await restclient.GetPicture(picture.Id);


            if (pictureDetails!=null && pictureDetails.Content!=null)
            {
                var bitmapImage = LoadImage(pictureDetails.Content);
                this.image.Source = bitmapImage;
            }
        }


        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }






        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            var filePath = @"C:\Users\feisele\Dropbox\Photos\Geschäft\IMG_4360.jpg";

            var fileContent = File.ReadAllBytes(filePath);

            PictureDetails newPicture = new PictureDetails();
            
            newPicture.Description = "Fabi";
            newPicture.Name = "Fabi";
            newPicture.Latitude = 54.03;
            newPicture.Longitude = 10;
            newPicture.Content = fileContent;
            

            restclient.UploadNewPicture(newPicture);
        }
    }
}
