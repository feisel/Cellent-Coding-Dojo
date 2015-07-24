using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace ccdService.DB
{
    public class PictureDetails
    {
        public PictureDetails()
        {
          //  Position = new GeoCoordinate();
        }

        public int ID { get; set; }

        public int PictureID { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public bool IsSmiling { get; set; }

        public byte[] Content { get; set; }

        public virtual Picture Picture { get; set; }
    }
}