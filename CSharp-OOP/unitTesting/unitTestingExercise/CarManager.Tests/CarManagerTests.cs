namespace CarManager.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private const string make = "BMW";
        private const string model = "X5";
        private const double fuelConsumption = 2.5;
        private const double fuelCapacity = 65.5;

        [SetUp]
        public void CtorInit()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        //========================================
        //Ctor + Getters TEST 
        //========================================

        [Test]
        public void Ctor_Init_Car_And_Getters_Should_Work()
        {
            Assert.IsNotNull(car);

            Assert.IsNotNull(car.FuelAmount);

            Assert.AreNotEqual(null, car.Make);
            Assert.AreEqual(make, car.Make);

            Assert.AreNotEqual(null, car.Model);
            Assert.AreEqual(model, car.Model);

            Assert.AreNotEqual(null, car.FuelConsumption);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);

            Assert.AreNotEqual(null, car.FuelCapacity);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        //========================================
        //Setters Validation TEST
        //========================================

        [Test]
        [TestCase("", model, fuelConsumption, fuelCapacity)]
        [TestCase(null, model, fuelConsumption, fuelCapacity)]

        [TestCase(make, "", fuelConsumption, fuelCapacity)]
        [TestCase(make, null, fuelConsumption, fuelCapacity)]

        [TestCase(make, model, 0, fuelCapacity)]
        [TestCase(make, model, -5, fuelCapacity)]

        [TestCase(make, model, fuelConsumption, 0)]
        [TestCase(make, model, fuelConsumption, -5)]

        public void Properties_ShouldThrowEx(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        //========================================
        //Private Setters TEST
        //========================================

        [Test]
        public void Setters_MustBePrivate()
        {
            var carType = typeof(Car);

            var publicProp = carType
                .GetProperties()
                .Where(c => c.SetMethod.IsPublic)
                .ToArray();

            Assert.IsEmpty(publicProp);
        }

        [TestCase(0)]
        [TestCase(-1.00)]
        public void Exception_FuelConsumptionCannotBeZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(()
                => new Car("aaa", "modelAAA", fuelConsumption, 50),
                "Fuel consumption cannot be zero or negative!");
        }

        //========================================
        //Refuel Method TEST
        //========================================

        [Test]
        [TestCase(0)]
        [TestCase(-1.00)]
        public void Refuel_ThrowsEx(double amount)
        {
            Assert.Throws<ArgumentException>(()
                => car.Refuel(amount),
                "Fuel amount cannot be negative!");
        }

        [Test]
        public void Refuel_ShouldWorkNormal()
        {
            double amount = car.FuelCapacity / 2;
            car.Refuel(amount);

            Assert.AreEqual(amount, car.FuelAmount);
        }

        [Test]
        [TestCase(65.6)]
        [TestCase(6122)]
        public void Refuel_AmoundShouldNotbeMoreThanCapacity(double amount)
        {
            car.Refuel(amount);

            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        //========================================
        //Drive Method TEST
        //========================================

        [Test]
        [TestCase(50)]
        [TestCase(1000)]
        public void Drive_ThrowsEx(double distance)
        {
            car.Refuel(0.5);

            Assert.Throws<InvalidOperationException>(()
                => car.Drive(distance),
                "You don't have enough fuel to drive!");
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void Drive_FuelDecreaseCorectly(double distance)
        {
            car.Refuel(50);

            car.Drive(distance);

            Assert.AreEqual(50 - (distance / 100) * car.FuelConsumption, car.FuelAmount);
        }
    }
}