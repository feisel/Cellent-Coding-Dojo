using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccdService.Controllers;

namespace ccdService.Services
{
    internal class PictureProvider : IPictureProvider
    {
        private List<Picture> pictureList = new List<Picture>();

        public PictureProvider()
        {
            pictureList.AddRange(CreateDummyPictures());
        }


        private static IEnumerable<Picture> CreateDummyPictures()
        {
            List<Picture> resultList = new List<Picture>();

            Picture pic = new Picture();
            pic.UserId = 1;
            pic.Description = "TestBild";
            pic.Name = "TestBild";

            resultList.Add(pic);
            return resultList;
        }

        public IEnumerable<Picture> GetAllPictures()
        {
            return pictureList;
        }




        public Picture GetPicture(int id)
        {
            return pictureList.Where(x => x.Id == id).SingleOrDefault();
        }

        public Picture CreatePicture(string name, string description,byte[] content)
        {
            var newPicture = new Picture();
            var newId = GetNextValidPictureId();
            newPicture.Id = newId;
            newPicture.Description = description;
            newPicture.Name = name;
            newPicture.Content = content;

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
    }
}