using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Models
{

    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }



        public PictureDetails Details { get; set; }

        public Picture()
        {


        }
    }
}