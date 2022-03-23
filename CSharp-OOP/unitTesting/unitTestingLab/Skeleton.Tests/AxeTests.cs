using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [Test]
        public void AxeLoseDurabilityAfterAttack()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Duranility doesn't change after attack.");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            axe = new Axe(10, 0);
            dummy = new Dummy(20, 10);


            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException.
                With.Message.EqualTo("Axe is broken."));

            //Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");

            //var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));

            //Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}