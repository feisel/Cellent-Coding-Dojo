using ccdService.Services;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ccdService.Controllers
{
    public class PictureController : ApiController
    {
        private IPictureService GetPictureService()
        {
            var provider = new PictureProvider();
            return new PictureService(provider);
        }

        // GET api/values
        public IEnumerable<Picture> Get()
        {
            var service = GetPictureService();

            return service.GetAllPictures();
        }

        // GET api/values/5
        public Picture Get(int id)
        {
            var service = GetPictureService();

            return service.GetPicture(id);
        }

        // POST api/values
        public void Post([FromBody]Picture picture)
        {
            var service = GetPictureService();

            service.CreatePicture(picture.Name,picture.Description,picture.Content);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var service = GetPictureService();

            service.DeletePicture(id);
        }
    }


    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public byte[] Content { get; set; }

        public Picture()
        {
           
            
        }
    }


    public class PictureInformation
    {
        public PictureInformation()
        {
            Position = new GeoCoordinate();
        }

        public GeoCoordinate Position { get; set; }

        public bool IsSmiling { get; set; }
    }
}
