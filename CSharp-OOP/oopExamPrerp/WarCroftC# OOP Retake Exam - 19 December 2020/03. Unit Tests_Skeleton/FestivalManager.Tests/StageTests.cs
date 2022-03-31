// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        //var song1 = new Song("Ветрове", new TimeSpan(0,3,30));
        //var performer = new Performer("Ivan", "Ivanov", 19);

        //Ctor
        [Test]
        public void Stage_Ctor_Init_Performers()
        {
            Stage stage = new Stage();

            Assert.AreNotEqual(null, stage.Performers);
        }

        //Add Performer
        [Test]
        public void Stage_Add_Performer()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", " Ivanov", 19);
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void Stage_Add_Performer_NullValue()
        {
            Stage stage = new Stage();
            Performer performer = null;
            Assert.Throws < ArgumentNullException>(() => stage.AddPerformer(performer), nameof(performer), "Can not be null!");
        }
        [Test]
        public void Stage_Add_Performer_Age()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", " Ivanov", 17);
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer), "You can only add performers that are at least 18.");
        }

        //Add Song normal/durationMinutes/null
        [Test]
        public void Stage_Add_Song_NullValue()
        {
            Stage stage = new Stage();
            Song song = null;
            Assert.Throws <ArgumentNullException>(() => stage.AddSong(song), nameof(song), "Can not be null!");
        }
        [Test]
        public void Stage_Add_Song_Min()
        {
            Stage stage = new Stage();
            var song1 = new Song("Ветрове", new TimeSpan(0, 0, 30));
            Assert.Throws<ArgumentException>(() => stage.AddSong(song1), "You can only add songs that are longer than 1 minute.");
        }
        [Test]
        public void Stage_Add_Song()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", "Ivanov", 18);
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song1);
            string message = "Ветрове (03:30) will be performed by Ivan Ivanov";
            Assert.AreEqual(message, stage.AddSongToPerformer("Ветрове", "Ivan Ivanov"));
        }

        ////Add Song to Performer normal/durationMinutes/null
        ///
        ///play
        [Test]
        public void Play()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", "Ivanov", 18);
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song1);
            stage.AddSongToPerformer("Ветрове", "Ivan Ivanov");

            string message = $"{stage.Performers.Count} performers played {1} songs";

            Assert.AreEqual(message, stage.Play());
        }

        //get performer null
        [Test]
        public void Get_Performer_Null()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", "Ivanov", 18);
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song1);
            //stage.AddSongToPerformer("Ветрове", "Ivan Ivanov");

            string message = $"{stage.Performers.Count} performers played {1} songs";

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Ветрове", "Ivanov"), "There is no performer with this name.");
        }

        //get song null
        [Test]
        public void Get_Song_Null()
        {
            Stage stage = new Stage();
            var performer = new Performer("Ivan", "Ivanov", 18);
            var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
            stage.AddPerformer(performer);
            stage.AddSong(song1);
            stage.AddSongToPerformer("Ветрове", "Ivan Ivanov");

            string message = $"{stage.Performers.Count} performers played {1} songs";

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("В", "Ivan Ivanov"), "There is no song with this name.");
        }

    }
}