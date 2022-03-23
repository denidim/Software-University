 using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var dummy = new Dummy(20, 10);

            dummy.TakeAttack(10);

            Assert.That(dummy.Health, Is.EqualTo(10), "Dummy Health doesn't change after attack.");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            var dummy = new Dummy(0, 10);

            Assert.That(() => dummy.TakeAttack(10),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience(),
                "Dead dummy doesn't give experience");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            var dummy = new Dummy(20, 10);

            Assert.Throws<InvalidOperationException>(()
                => dummy.GiveExperience(), "Target is not dead.");
        }

    }
}