using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Models
{
    public class PictureCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Content { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}