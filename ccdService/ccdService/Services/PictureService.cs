using ccdService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccdService.Controllers;
using ccdService.DB;

namespace ccdService.Services
{
    public class PictureService : IPictureService
    {
        IPictureProvider provider;

        public PictureService(IPictureProvider provider)
        {
            this.provider = provider;
        }

        public Picture CreatePicture(string name, string description, byte[] content, double longitude, double latidude)
        {
            return provider.CreatePicture(name, description, content, longitude, latidude);
        }

        public void DeletePicture(int id)
        {
            provider.DeletePicture(id);
        }

        public IEnumerable<Picture> GetAllPictures()
        {

            return provider.GetAllPictures();

        }

        public Picture GetPicture(int id)
        {
            return provider.GetPicture(id);
        }

        public void UpdatePicture(int id, string name, string description, byte[] content, double longitude, double latidude)
        {
            var picture = provider.GetPicture(id);

            picture.Name = name;
            picture.Description = description;
            picture.Details.Content = content;
            picture.Details.Longitude = longitude;
            picture.Details.Latitude = latidude;

            provider.UpdatePicture(picture);
        }
    }
}