using ccdService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ccdService.Controllers;

namespace ccdService.Services
{
    public class PictureService : IPictureService
    {
        IPictureProvider provider;

        public PictureService(IPictureProvider provider)
        {
            this.provider = provider;
        }

        public PictureEntity CreatePicture(string name, string description, byte[] content)
        {
            return provider.CreatePicture(name, description, content);
        }

        public void DeletePicture(int id)
        {
            provider.DeletePicture(id);
        }

        public IEnumerable<PictureEntity> GetAllPictures()
        {

            return provider.GetAllPictures();

        }

        public PictureEntity GetPicture(int id)
        {
            return provider.GetPicture(id);
        }

        public void UpdatePicture(PictureEntity picture)
        {
            provider.UpdatePicture(picture);
        }
    }
}