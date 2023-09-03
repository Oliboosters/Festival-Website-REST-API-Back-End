using ArtistLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamensProjekt3.Managers
{
    interface IManageArtists
    {
        IEnumerable<Artist> Get();
        Artist Get(int id);
        bool Create(Artist value);
        bool Update(int id, Artist value);
        Artist Delete(int id);
    }
}
