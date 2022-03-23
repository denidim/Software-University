namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        private Warrior warrior;

        private const int MIN_ATTACK_HP = 30;
        private const string name = "Pencho";
        private const int damage = 40;
        private const int hp = 100;
        

        [SetUp]
        public void Ctor_Intit()
        {
            arena = new Arena();
            warrior = new Warrior(name, damage, hp);
        }

        //========================================
        //Ctor TEST
        //========================================

        [Test]
        public void Ctor_Init_Arena_And_Getters_Should_Work()
        {
            Assert.IsNotNull(arena);
        }

        //========================================
        //Enroll Method TEST
        //========================================

        [Test]
        public void Enroll_Existing_Name_Throws_Ex()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior),
                "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Enroll_Adds_Warriors()
        {
            arena.Enroll(warrior);
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            Assert.AreEqual(3, arena.Count);
        }

        //========================================
        //Readonly Collection TEST
        //========================================

        [Test]
        public void IReadonly_Collection_Should_Work()
        {
            arena.Enroll(warrior);
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            var count = arena.Warriors.Count;

            Assert.AreEqual(count, arena.Count);
        }

        //========================================
        //Fight Method TEST
        //========================================

        [Test]
        public void Fight_Normal()
        {
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", "Pesho"),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        [TestCase("MissingName")]
        public void Fight_Attacker_Missing_Name(string missingName)
        {
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(missingName, "Pesho"),
                $"There is no fighter with name {missingName} enrolled for the fights!");
        }

        [Test]
        [TestCase("MissingName")]
        public void Fight_Defender_Missing_Name(string missingName)
        {
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", missingName),
                $"There is no fighter with name {missingName} enrolled for the fights!");
        }

        [Test]
        [TestCase("MissingName")]
        public void Fight_Both_Missing_Name(string missingName)
        {
            arena.Enroll(new Warrior("Ivan", 10, 30));
            arena.Enroll(new Warrior("Pesho", 10, 30));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(missingName, missingName),
                $"There is no fighter with name {missingName} enrolled for the fights!");
        }
    }
}
