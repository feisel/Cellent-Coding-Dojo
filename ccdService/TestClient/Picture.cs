﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public PictureDetails Details { get; set; }
    }

    internal class PictureDetails
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
