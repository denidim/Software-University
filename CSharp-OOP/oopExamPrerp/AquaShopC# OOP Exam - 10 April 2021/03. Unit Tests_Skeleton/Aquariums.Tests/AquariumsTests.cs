namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private const string name = "AqName";

        private const int capacity = 5;

        private const string fishName1 = "Nemo";

        private const string fishName2 = "Pesho";

        private Fish fish1 = new Fish(fishName1);

        private Fish fish2 = new Fish(fishName2);


        [Test]
        public void CtorTest()
        {
            Aquarium aquarium = new Aquarium(name,capacity);

            Assert.AreEqual(aquarium.Name,name);

            Assert.AreEqual(aquarium.Capacity, capacity);
        }

        [Test]
        public void WrongNameTest()
        {
            string name = "";

            Assert.Throws<ArgumentNullException>(()=> new Aquarium(null, capacity),$"{nameof(name)} Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, capacity), $"{nameof(name)} Invalid aquarium name!");
        }

        [Test]
        public void WrongCapacityTest()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, -1), $"Invalid aquarium capacity!");
        }

        [Test]
        public void Count()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void AddFishTest()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void AddFishThrowsException()
        {
            Aquarium aquarium = new Aquarium(name, 0);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish1));
        }

        [Test]
        public void RemoveFishThrowsException()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            string wrongName = "wrongName";

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(wrongName));
        }

        [Test]
        public void RemoveFishTest()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            aquarium.RemoveFish(fishName1);

            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void SellFishThrowsException()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            string wrongName = "wrongName";

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(wrongName));
        }

        [Test]
        public void SellFishReturnFish()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            Assert.AreEqual(fish1.Available, true);

            Fish fish = aquarium.SellFish(fishName1);

            Assert.AreEqual(fish.Name, fishName1);

            Assert.AreEqual(fish.Available, false);
        }


        [Test]
        public void Report()
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            aquarium.Add(fish1);

            aquarium.Add(fish2);

            string fishNames = $"{fishName1}, {fishName2}";

            string report = $"Fish available at {name}: {fishNames}";

            Assert.AreEqual(report,aquarium.Report());
        }
    }
}
