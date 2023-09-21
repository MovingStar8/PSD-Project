using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Repository
{
    public class AlbumRepository
    {
        private static DatabaseEntities db = ConnectDb.getDb();

        public static List<Artist> GetArtistList()
        {
            return (from a in db.Artists where !a.ArtistImage.Equals("deleted") select a).ToList();
        }

        public static List<Album> GetAlbumList(int id)
        {
            return (from a in db.Albums where !a.AlbumName.Contains("deleted") && a.ArtistID == id select a).ToList();
        }

        public static string DeleteArtist(Artist artist)
        {
            try
            {
                artist.ArtistName = artist.ArtistName + " deleted";
                db.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with deleting process";
            }
        }

        public static Artist GetArtistById(string id)
        {
            int ids = int.Parse(id);
            return (from a in db.Artists where a.ArtistID == ids select a).FirstOrDefault();
        }

        public static string DeleteAlbum(Album album)
        {
            try
            {
                album.AlbumName = album.AlbumName + " deleted";
                db.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with deleting process";
            }
        }

        public static Album GetAlbumById(string id)
        {
            int ids = int.Parse(id);
            return (from a in db.Albums where a.AlbumID == ids select a).FirstOrDefault();
        }

        public static string InsertArtist(Artist a)
        {
            try
            {
                db.Artists.Add(a);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with inserting process";
            }
        }

        public static string UpdateArtist(Artist a, string name, string imagePath)
        {
            try
            {
                a.ArtistName = name;
                a.ArtistImage = imagePath;

                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Something wrong with updating process";
            }
        }

        public static string InsertAlbum(Album a)
        {
            try
            {
                db.Albums.Add(a);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Something wrong with inserting process";
            }
        }

        public static string UpdateAlbum(Album a, string name, string imagePath, int price, int stock, string description)
        {
            try
            {
                a.AlbumName = name;
                a.AlbumImage = imagePath;
                a.AlbumPrice = price;
                a.AlbumStock = stock;
                a.AlbumDescription = description;

                db.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Something wrong with updating process";
            }
        }
    }
}