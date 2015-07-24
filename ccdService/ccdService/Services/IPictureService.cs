using ccdService.Controllers;
using ccdService.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ccdService.Services
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAllPictures();

        Picture GetPicture(int id);

        Picture CreatePicture(string name, string description,byte[] content,double longitude,double latidude);

        void DeletePicture(int id);

        void UpdatePicture(int id,string name, string description, byte[] content, double longitude, double latidude);

    }
}