using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace ccdService.Models
{

    public class PictureDetailsModel
    {
        public PictureDetailsModel()
        {
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public bool IsSmiling { get; set; }

        public byte[] Content { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
    }
}