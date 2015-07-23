using System;
using System.Collections.Generic;
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

        public byte[] Content { get; set; }
    }
}
