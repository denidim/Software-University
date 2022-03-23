namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const int MIN_ATTACK_HP = 30;
        private const string name = "Pencho";
        private const int damage = 40;
        private const int hp = 100;

        [SetUp]
        public void Ctor_Intit()
        {
            warrior = new Warrior(name, damage, hp);
        }

        //========================================
        //Ctor + Getters TEST
        //========================================

        [Test]
        public void Ctor_Init_Warrior_And_Getters_Should_Work()
        {
            Assert.IsNotNull(warrior);

            Assert.AreEqual(name, warrior.Name);

            Assert.AreEqual(damage, warrior.Damage);

            Assert.AreEqual(hp, warrior.HP);
        }

        //========================================
        //Setters TEST
        //========================================

        [Test]
        public void Setters_Must_Be_Private()
        {
            var warriorType = typeof(Warrior);
            var propertiesWithPublicSetters = warriorType
                .GetProperties()
                .Where(p => p.SetMethod.IsPublic)
                .ToArray();

            Assert.AreEqual(0, propertiesWithPublicSetters.Length);
        }

        //========================================
        //Setters Validation TEST
        //========================================

        [Test]
        [TestCase(null, damage, hp)]
        [TestCase("", damage, hp)]
        [TestCase(name, 0, hp)]
        [TestCase(name, -1, hp)]
        [TestCase(name, damage, -1)]

        public void Properties_Should_Throw_Ex(
            string name,
            int damage,
            int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        //========================================
        //Attack Method TEST
        //========================================

        [Test]
        public void Attack_Your_Hp_To0_Small_For_Attack_Throw_Ex()
        {
            const int testHp = 10;

            warrior = new Warrior(name,damage,testHp);

            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(new Warrior(name,damage,hp)),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void Attack_Enemy_Hp_Too_Small_For_Attack_Throw_Ex()
        {
            const int testHp = 10;

            warrior = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(new Warrior(name, damage, testHp)),
                $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void Attack_Strong_Enemy_Throw_Ex()
        {
            const int testHp = 35;

            warrior = new Warrior(name, damage, testHp);

            Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(new Warrior(name, damage, hp)),
                $"You are trying to attack too strong enemy");
        }


        [Test]
        public void Attack_Should_Work_Nornaly_When_Warrior_Has_Twise_More_Hp_Than_Dmg()
        {
            var expected = warrior.HP - warrior.Damage * 2;

            warrior.Attack(warrior);

            Assert.AreEqual(expected, warrior.HP);
        }

        [Test]
        public void Attack_Should_Work_Nornaly_When_Warrior_Has_Equal_Hp_To_Dmg()
        {
            const int testHp = 40;

            warrior = new Warrior(name, damage, testHp);

            var expected = warrior.HP - warrior.Damage;

            warrior.Attack(warrior);

            Assert.AreEqual(expected, warrior.HP);
        }
    }
}