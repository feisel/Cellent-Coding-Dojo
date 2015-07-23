using ccdService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    public interface IPictureService
    {
        IEnumerable<PictureEntity> GetAllPictures();

        PictureEntity GetPicture(int id);

        PictureEntity CreatePicture(string name, string description,byte[] content);

        void DeletePicture(int id);

        void UpdatePicture(PictureEntity picture);

    }
}