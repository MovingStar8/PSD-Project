using KpopZtation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtation.Factory
{
    public class AlbumFactory
    {
        public static Artist CreateArtist(string name, string imageName)
        {
            return new Artist
            {
                ArtistName = name,
                ArtistImage = "~\\Assets\\Artists\\" + imageName
            };
        }

        public static Album CreateAlbum(string name, string imageName, int price, int stock, string description, string id)
        {
            return new Album
            {
                ArtistID = int.Parse(id),
                AlbumName = name,
                AlbumImage = "~\\Assets\\Albums\\" + imageName,
                AlbumPrice = price,
                AlbumStock = stock,
                AlbumDescription = description
            };
        }
    }
}