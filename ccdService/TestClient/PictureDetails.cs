using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class PictureDetails
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsSmiling { get; set; }

        public byte[] Content { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
