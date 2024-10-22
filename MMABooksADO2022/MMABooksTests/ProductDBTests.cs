using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void TestCreateProduct() /*TODO: fix error, not running*/
        {
            Product p = new Product();
            p.ProductCode = "Z9X8";
            p.Description = "CS234N Study Guide";
            p.OnHandQuantity = 123;
            p.UnitPrice = 123.45m;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("Z9X8", p.ProductCode);
        }
    }
}
