using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {
        [SetUp]
        public void SetUp()
        {
            //not setting up anything yet
        }

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            //Arrange
            Customer oldCustomer = new Customer();
            oldCustomer.CustomerID = 1;
            oldCustomer.Name = "Gabe Gucker";
            oldCustomer.Address = "349 Strawberry Lane";
            oldCustomer.City = "Ketchikan";
            oldCustomer.State = "Alaska";
            oldCustomer.ZipCode = "99901";

            Customer newCustomer = new Customer();
            newCustomer.Name = "Gabriel Gucker";
            newCustomer.Address = "393 Lenore Loop";
            newCustomer.City = "Eugene";
            newCustomer.State = "Oregon";
            newCustomer.ZipCode = "97404";

            //Act
            bool result = CustomerDB.UpdateCustomer(oldCustomer, newCustomer);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            
        }
    }
}
