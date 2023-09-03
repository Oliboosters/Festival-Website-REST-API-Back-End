using ArtistLibrary;
using EksamensProjekt3.Controllers;
using EksamensProjekt3.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EksamensProjekt3UnitTests
{
    [TestClass]
    public class ArtistManagerTests
    {
        private ArtistManager _mgr;

        public ArtistManagerTests()
        {
            _mgr = new ArtistManager();
        }

        [TestMethod]
        public void Get_Artists_Based_On_ID()
        {
            Artist exp = new Artist(2, "Mr. Monkey", "Der er opskrift på abekatte-streger når Mr. Monkey indtager scenen! Hav altid en banan klar!", "https://localhost:44385/Images/MrMonkey.jpg");

            Artist act = _mgr.Get(2);

            var expected = JsonConvert.SerializeObject(exp);
            var actual = JsonConvert.SerializeObject(act);

            Assert.AreEqual(expected, actual);         
        }

        [TestMethod]
        [DataRow(1, "Bobby", "A Guy", "Image")]
        [DataRow(5, "Jack", "Another Guy", "BetterImage")]
        public void CreateMethod_Test(int id, string name, string info, string image)
        {
            Artist newArtist = new Artist(id, name, info, image);
            var oldListSize = _mgr.Get().Count();

            var nowCreated = _mgr.Create(newArtist);
            var newListSize = _mgr.Get().Count();

            Assert.IsTrue(nowCreated);
            Assert.AreEqual(oldListSize + 1, newListSize);

            _mgr.Delete(newArtist.Id);
        }

        [TestMethod]
        public void DeleteMethod_Test()
        {
            Artist newArtist = new Artist(23, "Jon", "Someone", "Img");
            _mgr.Create(newArtist);

            var oldListSize = _mgr.Get().Count();

            _mgr.Delete(_mgr.Get().Last<Artist>().Id);

            var newListSize = _mgr.Get().Count();

            Assert.AreEqual(oldListSize - 1, newListSize);
        }
    }
}
