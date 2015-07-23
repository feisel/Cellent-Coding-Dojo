using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace ccdService.Models
{

    public class PictureDetails
    {
        public PictureDetails()
        {
            Position = new GeoCoordinate();
        }

        public GeoCoordinate Position { get; set; }

        public bool IsSmiling { get; set; }

        public byte[] Content { get; set; }
    }
}