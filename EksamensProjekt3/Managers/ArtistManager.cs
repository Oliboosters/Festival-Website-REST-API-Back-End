using ArtistLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EksamensProjekt3.Controllers;

namespace EksamensProjekt3.Managers
{
    public class ArtistManager : IManageArtists
    {
        /*
        DatabaseContext Context;

        public ArtistManager(DatabaseContext context)
        {
            Context = context;
        }

        public bool Create(Artist value)
        {
            List<Artist> artistlist = Context.FestivalArtists.ToList();
            value.Id = artistlist.Last().Id + 1;
            Context.Add(value);
            Context.SaveChanges(); 
            return true;
        }

        public Artist Delete(int id)
        {
            Artist artistToDelete = Get(id);
            Context.FestivalArtists.Remove(artistToDelete);
            Context.SaveChanges();
            return artistToDelete;
        }

        public IEnumerable<Artist> Get()
        {
            return Context.FestivalArtists;
        }

        public Artist Get(int id)
        {
            
            if (Context.FestivalArtists.FirstOrDefault(p => p.Id == id) != null)
            {
                return Context.FestivalArtists.FirstOrDefault(p => p.Id == id);
            }
            throw new KeyNotFoundException($"Id {id} findes ikke");
        }

        public bool Update(int id, Artist value)
        {
            if (Get(id) != null)
            {
                Get(id).Name = value.Name;
                Get(id).Info = value.Info;
                Context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id {id} findes ikke");
            }
            return false;
        }*/

        private static List<Artist> artistList = new List<Artist>()
        {
            new Artist
            (
                1,
                "Madoka",
                "En mystisk dame fra en fjerntliggende virkelighed! Den tidligere troldkvinde Madoka er kendt for sin nærmest hypnotiske musik og fængende stemme. Spøjs musik for dem som søger det ukendte!",
                "https://localhost:5001/Images/Madoka.jpg"
            ),
            new Artist
            (
                2,
                "Mr. Monkey",
                "Der er opskrift på abekatte-streger når Mr. Monkey indtager scenen! Den musikalske abekat som tog internettet med storm sidste sommer er nu tilbage med mere hard-core jungle-rock! Hav altid en banan klar!",
                "https://localhost:5001/Images/MrMonkey.jpg"
            ),
            new Artist
            (
                3,
                "Ricky",
                "Den store superstjerne Ricky er tilbage! Ricky er endnu engang klar til at give den maks gas ved dette års festival. Han bringer selvfølgelig stadig sin trofaste elektriske-guitar - Simone - så forbered jer på både elektrisk shock og ren turbulens!",
                "https://localhost:5001/Images/Ricky.jpg"
            ),
            new Artist
            (
                4,
                "The Jazz Bois",
                "Smooth Jazz af højste kvalitet! De legendariske Jazz Bois er kommet hele vejen fra USA for at spiller for os ved dette års festival. Forbedred jer på en groovy melodi der er som balsam for sjælen!",
                "https://localhost:5001/Images/TheJazzBois.jpg"
            )
        };

        public bool Create(Artist value)
        {
            value.Id = artistList.Last().Id + 1;
            artistList.Add(value);
            return true;
        }

        public Artist Delete(int id)
        {
            Artist artistToDelete = Get(id);
            artistList.Remove(artistToDelete);
            return artistToDelete;
        }

        public IEnumerable<Artist> Get()
        {
            return new List<Artist>(artistList);
        }

        public Artist Get(int id)
        {
            return artistList.Find(p => p.Id == id);
        }

        public bool Update(int id, Artist value)
        {
            Artist artist = Get(id);

            if (artist != null)
            {
                artist.Name = value.Name;
                artist.Info = value.Info;

                return true;
            }
            else return false;
        }
    }       
}
