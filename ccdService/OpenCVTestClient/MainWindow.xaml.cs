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
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace OpenCVTestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static void Detect(Image<Bgr, Byte> image, String faceFileName, String eyeFileName, List<System.Drawing.Rectangle> faces, List<System.Drawing.Rectangle> eyes)
        {
            using (CascadeClassifier face = new CascadeClassifier(faceFileName))
            //Read the eyeFileName objects
           
            using (CascadeClassifier eye = new CascadeClassifier(eyeFileName))
            {

                var watch = Stopwatch.StartNew();
                using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
                {
                    //normalizes brightness and increases contrast of the image
                    gray._EqualizeHist();

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel
                    System.Drawing.Rectangle[] facesDetected = face.DetectMultiScale(
                       gray,
                       1.1,
                       10,
                       new System.Drawing.Size(20, 20),
                       System.Drawing.Size.Empty);
                    faces.AddRange(facesDetected);

                    foreach (System.Drawing.Rectangle f in facesDetected)
                    {

                     


                        //Set the region of interest on the faces
                        gray.ROI = f;
                        System.Drawing.Rectangle[] eyesDetected = eye.DetectMultiScale(
                           gray,
                           1.1,
                           10,
                           new System.Drawing.Size(20, 20),
                           System.Drawing.Size.Empty);
                        gray.ROI = System.Drawing.Rectangle.Empty;

                        foreach (System.Drawing.Rectangle e in eyesDetected)
                        {
                            System.Drawing.Rectangle eyeRect = e;
                            eyeRect.Offset(f.X, f.Y);
                            eyes.Add(eyeRect);
                        }
                    }
                }
                watch.Stop();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            
         

            /*
 
ImageViewer viewer = new ImageViewer(); //create an image viewer
            Capture capture = new Capture(); //create a camera captue
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)

               
                viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
            });
            viewer.ShowDialog(); //show the image viewer

    */
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
          var filePath =   openFileDialog.FileName;
            Image<Bgr, Byte> image = new Image<Bgr, byte>(filePath); //Read the files as an 8-bit Bgr image  
            List<System.Drawing.Rectangle> faces = new List<System.Drawing.Rectangle>();
            List<System.Drawing.Rectangle> eyes = new List<System.Drawing.Rectangle>();
            
            Detect(image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes);


            foreach (System.Drawing.Rectangle face in faces)
                image.Draw(face, new Bgr(System.Drawing.Color.Red), 2);
            foreach (System.Drawing.Rectangle eye in eyes)
                image.Draw(eye, new Bgr(System.Drawing.Color.Blue), 2);

            ImageViewer.Show(image);
            File.WriteAllBytes("test.jpg", image.ToJpegData());


            
            Image<Gray, Byte> smileImage = new Image<Gray, byte>("happy.jpg"); //Read the files as an 8-bit Bgr image  
            Image<Gray, Byte> sadImage = new Image<Gray, byte>("sad.jpg"); //Read the files as an 8-bit Bgr image 


            List<Image<Gray, Byte>> trainingList = new List<Image<Gray, byte>>();
            trainingList.Add(smileImage);
            trainingList.Add(sadImage);

            List<string> labelList = new List<string>();
            labelList.Add("happy");
            labelList.Add("sad");
            // labelList.Add(2);

            MCvTermCriteria termCrit = new MCvTermCriteria(10, 0.001);

                //Eigen face recognizer
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                trainingList.ToArray(),
                labelList.ToArray(),
                5000,
                ref termCrit);


            Image<Gray, Byte> inputImage = new Image<Gray, byte>(filePath); //Read the files as an 8-bit Bgr image  
            var resizedImage = inputImage.Resize(smileImage.Width, smileImage.Height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            var name = recognizer.Recognize(resizedImage).Label;


            List<int> temp = new List<int>();
            temp.Add(1);
            temp.Add(2);


            EigenFaceRecognizer recogizer2 = new EigenFaceRecognizer(80, double.PositiveInfinity);
            recogizer2.Train(trainingList.ToArray(), temp.ToArray());
           var dd = recogizer2.Predict(resizedImage);




            ImageViewer.Show(resizedImage);



        }
    }
}
