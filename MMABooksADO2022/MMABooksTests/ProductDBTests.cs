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
            p.OnHandQuantity = 5678;

            Product p2 = ProductDB.AddProduct(p);
            Assert.AreEqual("ABC1", p.ProductCode);
            Assert.AreEqual("testing product", p.Description);
            Assert.AreEqual(12.34m, p.UnitPrice);
            Assert.AreEqual(5678, p.OnHandQuantity);
        }

        [Test]
        public void TestUpdateProduct()
        {
            //Arrange
            Product oldProduct = new Product();
            oldProduct.ProductCode = "A4CS";
            oldProduct.Description = "Murach's ASP.NET 4 Web Programming with C# 2010";
            oldProduct.UnitPrice = 56.5000m;
            oldProduct.OnHandQuantity = 4637;

            Product newProduct = new Product();
            newProduct.ProductCode = "XYZ9";
            newProduct.Description = "test update product";
            newProduct.UnitPrice = 43.21m;
            newProduct.OnHandQuantity = 1234;

            //Act
            bool result = ProductDB.UpdateProduct(oldProduct, newProduct);


            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void TestDeleteProduct()
        {
            //TODO: Write unit test for DeleteProduct()
        }
    }
}
