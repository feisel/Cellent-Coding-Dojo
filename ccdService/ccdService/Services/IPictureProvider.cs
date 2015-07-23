using ccdService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    internal interface IPictureProvider
    {
        IEnumerable<Picture> GetAllPictures();

        Picture GetPicture(int id);

        Picture CreatePicture(string name, string description, byte[] content);

        void DeletePicture(int id);
    }
}