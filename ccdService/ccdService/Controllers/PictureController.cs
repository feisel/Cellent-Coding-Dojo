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
        public IEnumerable<Picture> Get()
        {
            var allPictures = service.GetAllPictures();
            var response = ConvertPictureEntityListToPictureList(allPictures);
            return response;
        }

        // GET api/values/5
        public Picture Get(int id)
        {
            var picture = service.GetPicture(id);
            if (picture == null)
                return null;
            var response = ConvertPictureEntityToPicture(picture);
            return response;
        }

        // POST api/values
        public void Post([FromBody]Picture picture)
        {
            service.CreatePicture(picture.Name,picture.Description,picture.Details.Content);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Picture picture)
        {
            var pictureEntity = ConvertPictureToPictureEntity(picture);

            service.UpdatePicture(pictureEntity);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            service.DeletePicture(id);
        }


        private Picture ConvertPictureEntityToPicture(PictureEntity entity)
        {
            Picture pic = new Picture();
            pic.Id = entity.Id;
            pic.Name = entity.Name;
            pic.UserId = entity.UserId;
            pic.Description = entity.Description;
            pic.Details = new PictureDetails();
            if (pic.Details != null)
            {
                pic.Details.Content = entity.Details.Content;
                pic.Details.IsSmiling = entity.Details.IsSmiling;
                pic.Details.Position = entity.Details.Position;
            }

            return pic;
        }


        private IEnumerable<Picture> ConvertPictureEntityListToPictureList(IEnumerable<PictureEntity> pictures)
        {
            List<Picture> resultList = new List<Picture>();

            foreach (var entity in pictures)
            {
                var convertedPic = ConvertPictureEntityToPicture(entity);
                resultList.Add(convertedPic);
            }
            return resultList;
        }


        private PictureEntity ConvertPictureToPictureEntity(Picture pic)
        {
            PictureEntity entity = new PictureEntity();
            entity.Id = pic.Id;
            entity.Name = pic.Name;
            entity.UserId = pic.UserId;
            entity.Description = pic.Description;
            entity.Details = new PictureDetailsEntity();
            if (pic.Details!=null)
            {
                entity.Details.Content = pic.Details.Content;
                entity.Details.IsSmiling = pic.Details.IsSmiling;
                entity.Details.Position = pic.Details.Position;
            }

            return entity; 
        }

        private IEnumerable<PictureEntity> ConvertPictureListToPictureEntityList(IEnumerable<Picture> pictures)
        {
            List<PictureEntity> resultList = new List<PictureEntity>();

            foreach(var pic in pictures)
            {
                var convertedPic = ConvertPictureToPictureEntity(pic);
                resultList.Add(convertedPic);
            }
            return resultList;
        }


    }




}
