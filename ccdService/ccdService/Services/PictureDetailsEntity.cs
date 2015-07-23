using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    public class PictureDetailsEntity
    {
        public PictureDetailsEntity()
        {
            Position = new GeoCoordinate();
        }

        public GeoCoordinate Position { get; set; }

        public bool IsSmiling { get; set; }

        public byte[] Content { get; set; }
    }
}