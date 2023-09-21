using KpopZtation.Handler;
using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KpopZtation.Controller
{
    public class AlbumController
    {
        public static List<Artist> GetArtistList()
        {
            return AlbumHandler.GetArtistList();
        }

        public static Artist GetArtistById(int id)
        {
            return AlbumHandler.GetArtistById(id);
        }

        public static Album GetAlbumById(int id)
        {
            return AlbumHandler.GetAlbumById(id);
        }

        public static List<Album> GetAlbumList(int id)
        {
            return AlbumHandler.GetAlbumList(id);
        }

        public static string DeleteArtistById(string id)
        {
            return AlbumHandler.DeleteArtist(id);
        }

        public static string DeleteAlbumById(string id)
        {
            return AlbumHandler.DeleteAlbum(id);
        }

        public static string InsertArtist(string name, HttpPostedFile ImageFile, string folderPath)
        {
            var status = ValidateImageAndName(name, ImageFile, folderPath);
            if (status.Equals("Success"))
            {
                return AlbumHandler.InsertArtist(name, ImageFile, folderPath);
            }

            return status;
        }

        public static string UpdateArtist(string name, HttpPostedFile ImageFile, string folderPath, string id)
        {
            var status = ValidateImageAndName(name, ImageFile, folderPath);
            if (status.Equals("Success"))
            {
                return AlbumHandler.UpdateArtist(name, ImageFile, folderPath, id);
            }

            return status;
        }

        public static string InsertAlbum(string name, HttpPostedFile ImageFile, string folderPath, int price, int stock, string description, string id)
        {
            var status = ValidateImageAndName(name, ImageFile, folderPath);
            if (status.Equals("Success"))
            {
                return AlbumHandler.InsertAlbum(name, ImageFile, folderPath, price, stock, description, id);
            }

            return status;
        }

        public static string UpdateAlbum(string name, HttpPostedFile ImageFile, string folderPath, string id, int price, int stock, string description)
        {
            var status = ValidateImageAndName(name, ImageFile, folderPath);
            if (status.Equals("Success"))
            {
                return AlbumHandler.UpdateAlbum(name, ImageFile, folderPath, id, price, stock, description);
            }

            return status;
        }

        public static string ValidateImageAndName(string name, HttpPostedFile ImageFile, string folderPath)
        {
            if (name.Equals(""))
            {
                return "Artist Name must be inserted";
            }

            string fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
            int fileSize = ImageFile.ContentLength;

            if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".jfif")
            {
                if (fileSize <= 2 * 1024 * 1024)
                {
                    return "Success";
                }
                else
                {
                    return "File size should be less than 2MB.";
                }
            }
            else
            {
                return "Invalid file extension. Only .png, .jpg, .jpeg, or .jfif files are allowed.";
            }
        }
    }
}