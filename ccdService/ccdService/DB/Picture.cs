using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.DB
{
    public class Picture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }


        public int dd { get; set; }

        public virtual PictureDetails Details { get; set; }
    }
}