using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccdService.Controllers;
using ccdService.DB;

namespace ccdService.Services
{
    public class PictureProvider : IPictureProvider
    {

        private PictureContext dbContext;

        public PictureProvider()
        {
            dbContext = new PictureContext();
            //Falls Datenbank nicht existieren anlegen
            dbContext.Database.CreateIfNotExists();
        }

        public IEnumerable<Picture> GetAllPictures()
        {
           return  dbContext.Pictures.ToList();
        }


        public Picture GetPicture(int id)
        {
            return dbContext.Pictures.Where(x => x.ID == id).SingleOrDefault();
        }

        public Picture CreatePicture(string name, string description,byte[] content, double longitude, double latidude)
        {
            var newPicture = new Picture();
            var newId = GetNextValidPictureId();
            newPicture.ID = newId;
            newPicture.Description = description;
            newPicture.Name = name;
            newPicture.Details = new PictureDetails();
            newPicture.Details.Content = content;
            newPicture.Details.Latitude = latidude;
            newPicture.Details.Longitude = longitude;

            dbContext.Pictures.Add(newPicture);
            dbContext.SaveChanges();

            return newPicture;
        }

        private int GetNextValidPictureId()
        {
            var currentMaxId = dbContext.Pictures.Max(x => x.ID);
            var newId = currentMaxId + 1;
            return newId;
        }

        public void DeletePicture(int id)
        {

           
            var picture = dbContext.Pictures.Where(x => x.ID == id).SingleOrDefault();

            if (picture != null)
            {
                dbContext.PictureDetails.Remove(picture.Details);
                dbContext.Pictures.Remove(picture);
                dbContext.SaveChanges();
            }

        }

        public void UpdatePicture(Picture picture)
        {
            var pictureEntity = dbContext.Pictures.Where(x => x.ID == picture.ID).SingleOrDefault();
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