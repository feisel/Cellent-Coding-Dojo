using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    public class PictureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public PictureEntity()
        {
            Details = new PictureDetailsEntity();
        }


        public PictureDetailsEntity Details { get; set; }
    }
}