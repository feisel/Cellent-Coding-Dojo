using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccdService.Controllers;

namespace ccdService.Services
{
    public class PictureProvider : IPictureProvider
    {
        private List<PictureEntity> pictureList = new List<PictureEntity>();

        public PictureProvider()
        {
            pictureList.AddRange(CreateDummyPictures());
        }


        private static IEnumerable<PictureEntity> CreateDummyPictures()
        {
            List<PictureEntity> resultList = new List<PictureEntity>();

            PictureEntity pic = new PictureEntity();
            pic.UserId = 1;
            pic.Description = "TestBild";
            pic.Name = "TestBild";

            resultList.Add(pic);
            return resultList;
        }

        public IEnumerable<PictureEntity> GetAllPictures()
        {
            return pictureList;
        }


        public PictureEntity GetPicture(int id)
        {
            return pictureList.Where(x => x.Id == id).SingleOrDefault();
        }

        public PictureEntity CreatePicture(string name, string description,byte[] content)
        {
            var newPicture = new PictureEntity();
            var newId = GetNextValidPictureId();
            newPicture.Id = newId;
            newPicture.Description = description;
            newPicture.Name = name;
            newPicture.Details = new PictureDetailsEntity();
            newPicture.Details.Content = content;

            pictureList.Add(newPicture);

            return newPicture;
        }

        private int GetNextValidPictureId()
        {
            var currentMaxId = pictureList.Max(x => x.Id);
            var newId = currentMaxId + 1;
            return newId;
        }

        public void DeletePicture(int id)
        {
           var picture =  pictureList.Where(x => x.Id == id).SingleOrDefault();
            if (picture != null)
                pictureList.Remove(picture);
        }

        public void UpdatePicture(PictureEntity picture)
        {
            var pictureEntity = pictureList.Where(x => x.Id == picture.Id).SingleOrDefault();
            if (pictureEntity != null)
            {
                pictureEntity.Description = picture.Description;
                pictureEntity.Name = picture.Name;
                pictureEntity.UserId = picture.UserId;
                pictureEntity.Details = picture.Details;


            }
        }
    }
}