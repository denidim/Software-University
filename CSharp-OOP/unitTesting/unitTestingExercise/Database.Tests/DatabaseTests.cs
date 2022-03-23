namespace Database.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        //========================================
        //Ctor + Getters TEST 
        //========================================

        [Test]
        [TestCase(1, 5)]
        [TestCase(1, 15)]
        public void Constructor_Should_Add_All_Items(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database database = new Database(elements);

            Assert.AreEqual(count, database.Count);
        }

        //========================================
        //Add Method TEST 
        //========================================

        [Test]
        [TestCase(3)]
        [TestCase(16)]
        [TestCase(0)]
        public void Add_Element_At_The_Next_Free_Cell(int count)
        {
            Database database = new Database();

            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(count, database.Count);
        }

        //========================================
        //Remove Method TEST 
        //========================================

        [Test]
        public void Remove_At_Last_Index()
        {
            Database database = new Database();

            database.Add(1);

            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void Remove_From_Empty_Database_Throws_Ex()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove(),
                "The collection is empty!");
        }

        //========================================
        //Fetch Method TEST 
        //========================================

        [Test]
        public void Fetch_Should_Return_Array()
        {
            Database database = new Database();

            database.Add(1);

            database.Add(2);

            int[] result = database.Fetch();

            Assert.IsInstanceOf<Array>(result);
        }

        //========================================
        //Check Capacity TEST 
        //========================================

        [Test]
        public void Array_Capacity_Exceeded_Throws_Ex()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(()
               => database.Add(1),
               "Array's capacity must be exactly 16 integers!");
        }
    }
}
