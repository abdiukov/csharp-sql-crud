using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject_
{
    /// <summary>
    /// UnitTest1 is used to check that the database is capable of inserting, updating and deleting.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private Repository _repo;
        private IEnumerable<Person> _person;
        private Person testPerson;

        /// <summary>
        /// Init() is used to link the test to the database.
        /// In order to execute this, a connection string was created in App.Config for UnitTest project.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _repo = new Repository();
        }


        /// <summary>
        /// The test below should be performed after the query 'EXEC RESET_DB' has been run in SSMS.
        /// Or in other words, after the database has been reset.
        /// Test2B checks that the amount of persons entered into the database equals to 4 and it checks that the GetPeople() method is operational.
        /// </summary>
        [TestMethod]
        public void Test2B()
        {
            _person = _repo.GetPeople();
            int expected = 4;
            int Actual = System.Linq.Enumerable.Count(_person);
            Assert.AreEqual(expected, Actual);
        }


        /// <summary>
        /// Test3B checks that a person can be inserted into the DataBase
        /// It checks that upon executing the command InsertPerson, 1 row has been affected.
        /// </summary>
        [TestMethod]
        public void Test3B()
        {
            testPerson = new Person()
            {
                FirstName = "Sue",
                LastName = "White",
                Weight = 6.1,
                Height = 65
            };

            int rowsAffected = _repo.InsertPerson(testPerson);
            Assert.AreEqual(1, rowsAffected);
        }


        /// <summary>
        /// Test 4B checks the UpdatePerson() method.
        /// It checks that upon executing the command UpdatePerson, 1 row has been affected.
        /// </summary>
        [TestMethod]
        public void Test4B()
        {
            testPerson = new Person()
            {
                Id = 2,
                FirstName = "Sally",
                LastName = "Blue",
                Weight = 5.3,
                Height = 51
            };

            int rowsAffected = _repo.UpdatePerson(testPerson);
            Assert.AreEqual(1, rowsAffected);
        }



        /// <summary>
        /// Test 5B checks the DeletePerson() method.
        /// It checks that upon executing the command DeletePerson, 1 row has been affected.
        /// </summary>
        [TestMethod]
        public void Test5B()
        {
            testPerson = _repo.GetPeople().First(p => p.Id == 4);
            int rowsAffected = _repo.DeletePerson(testPerson);

            Assert.AreEqual(1, rowsAffected);
        }
    }

}

