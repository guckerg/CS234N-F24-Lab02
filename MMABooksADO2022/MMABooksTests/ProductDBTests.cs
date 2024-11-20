using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestAddProduct()
        {
            Product p = new Product();
            p.ProductCode = "ABC1";
            p.Description = "testing product";
            p.UnitPrice = 12.34m;
            p.OnHandQuantity = 1234;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("ABC1", p.ProductCode);
        }

        [Test]
        public void TestUpdateProduct() //TODO: update copied method to UPDATE
        {
            Product p = new Product();
            p.ProductCode = "ABC1";
            p.Description = "testing product";
            p.UnitPrice = 12.34m;
            p.OnHandQuantity = 1234;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("ABC1", p.ProductCode);
        }

        [Test]
        public void TestDeleteProduct()
        {
            Product p = new Product();
            p.ProductCode = "ABC1";
            p.Description = "testing product";
            p.UnitPrice = 12.34m;
            p.OnHandQuantity = 1234;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("ABC1", p.ProductCode);
        }
    }
}
