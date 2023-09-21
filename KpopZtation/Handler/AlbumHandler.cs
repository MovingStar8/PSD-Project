using KpopZtation.Factory;
using KpopZtation.Model;
using KpopZtation.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KpopZtation.Handler
{
    public class AlbumHandler
    {
        public static List<Artist> GetArtistList()
        {
            return AlbumRepository.GetArtistList();
        }

        public static Artist GetArtistById(int id)
        {
            return AlbumRepository.GetArtistById(id.ToString());
        }

        public static Album GetAlbumById(int id)
        {
            return AlbumRepository.GetAlbumById(id.ToString());
        }

        public static List<Album> GetAlbumList(int id)
        {
            return AlbumRepository.GetAlbumList(id);
        }

        public static string DeleteArtist(string id)
        {
            try
            {
                Artist artist = AlbumRepository.GetArtistById(id);

                return AlbumRepository.DeleteArtist(artist);
            }
            catch (Exception ex)
            {
                return "Something wrong with deleting process";
            }
        }

        public static string DeleteAlbum(string id)
        {
            try
            {
                Album artist = AlbumRepository.GetAlbumById(id);

                return AlbumRepository.DeleteAlbum(artist);
            }
            catch (Exception ex)
            {
                return "Something wrong with deleting process";
            }
        }

        public static string InsertArtist(string name, HttpPostedFile ImageFile, string folderPath)
        {
            string fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString().Substring(0, 20) + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            ImageFile.SaveAs(filePath);

            return AlbumRepository.InsertArtist(AlbumFactory.CreateArtist(name, fileName));
        }

        public static string UpdateArtist(string name, HttpPostedFile ImageFile, string folderPath, string id)
        {
            string fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString().Substring(0, 20) + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            string imgUrl = "~\\Assets\\Artists\\" + fileName;
            ImageFile.SaveAs(filePath);

            return AlbumRepository.UpdateArtist(AlbumRepository.GetArtistById(id), name, imgUrl);
        }

        public static string InsertAlbum(string name, HttpPostedFile ImageFile, string folderPath, int price, int stock, string description, string id)
        {
            string fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString().Substring(0, 20) + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            ImageFile.SaveAs(filePath);

            return AlbumRepository.InsertAlbum(AlbumFactory.CreateAlbum(name, fileName, price, stock, description, id));
        }

        public static string UpdateAlbum(string name, HttpPostedFile ImageFile, string folderPath, string id, int price, int stock, string description)
        {
            string fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString().Substring(0, 20) + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            string imgUrl = "~\\Assets\\Albums\\" + fileName;
            ImageFile.SaveAs(filePath);

            return AlbumRepository.UpdateAlbum(AlbumRepository.GetAlbumById(id), name, imgUrl, price, stock, description);
        }
    }
}