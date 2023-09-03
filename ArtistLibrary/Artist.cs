using System;

namespace ArtistLibrary
{
    public class Artist
    {

        public static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImagePath { get; set; }


        public Artist(int id, string name, string info, string imagePath)
        {

            Id = id;
            Name = name;
            Info = info;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return "Artist: " + Name + "Information: " + Info;
        }
    }
}
