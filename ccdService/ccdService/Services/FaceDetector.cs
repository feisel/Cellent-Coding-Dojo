using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    public class FaceDetector
    {
        public static byte[] GenerateDetectedImage(Image<Bgr, Byte> image, List<System.Drawing.Rectangle> faces, List<System.Drawing.Rectangle> eyes)
        {
            foreach (System.Drawing.Rectangle face in faces)
                image.Draw(face, new Bgr(System.Drawing.Color.Red), 10);
            foreach (System.Drawing.Rectangle eye in eyes)
                image.Draw(eye, new Bgr(System.Drawing.Color.Blue), 10);


            var allBytes =  image.ToJpegData();
            return allBytes;
        }


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
    }
}