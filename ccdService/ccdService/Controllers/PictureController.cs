using ccdService.DB;
using ccdService.Models;
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
        IPictureService service;
        public PictureController(IPictureService pictureService)
        {
            service = pictureService;
        }
     

        // GET api/values
        public IEnumerable<PictureModel> Get()
        {
            var allPictures = service.GetAllPictures();

            var resultList = new List<PictureModel>();

            foreach(var picture in allPictures)
            {
                var model = ConvertPictureToPictureModel(picture);
                resultList.Add(model);
            }

            return resultList;
           // return response;
        }


        private static PictureModel ConvertPictureToPictureModel(Picture picture)
        {
            PictureModel model = new PictureModel();
            model.Description = picture.Description;
            model.Id = picture.ID;
            model.Name = picture.Name;
            model.UserId = picture.UserId;
            return model;
        }

        // GET api/values/5
        public PictureDetailsModel Get(int id)
        {
            var picture = service.GetPicture(id);
            if (picture == null)
                return null;

            var model = new PictureDetailsModel();
            model.Content = picture.Details.Content;
            model.IsSmiling = picture.Details.IsSmiling;
            model.Longitude = picture.Details.Longitude;
            model.Latitude = picture.Details.Latitude;
            model.Name = picture.Name;
            model.Description = picture.Description;
            model.Id = picture.ID;

            return model;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]PictureCreateModel picture)
        {
          var newPicture =  service.CreatePicture(picture.Name,picture.Description,picture.Content,picture.Longitude,picture.Latitude);

            PictureModel returnModel = new PictureModel();
            returnModel.Description = newPicture.Description;
            returnModel.Id = newPicture.ID;
            returnModel.Name = newPicture.Name;
            returnModel.UserId = newPicture.UserId;


            var response = Request.CreateResponse<PictureModel>(System.Net.HttpStatusCode.Created, returnModel);

            // Generate a link to the new book and set the Location header in the response.
            string uri = Url.Link("DefaultApi", new { id = returnModel.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]PictureCreateModel picture)
        {
            service.UpdatePicture(id, picture.Name, picture.Description, picture.Content, picture.Longitude, picture.Latitude);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            service.DeletePicture(id);
        }



     





    }




}
