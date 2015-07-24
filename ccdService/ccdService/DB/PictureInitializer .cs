using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.DB
{
    public class PictureInitializer :  System.Data.Entity.DropCreateDatabaseIfModelChanges<PictureContext>
    {
        protected override void Seed(PictureContext context)
        {

            var pic = new Picture();
            pic.Name = "sdfsdfsdf";

            pic.Details = new PictureDetails();
            pic.Details.IsSmiling = true;

            var pictures = new List<Picture>();
            pictures.Add(pic);
          


            pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();



          
        }
    }
}