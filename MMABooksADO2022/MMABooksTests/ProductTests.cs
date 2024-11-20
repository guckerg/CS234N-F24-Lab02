using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using NUnit.Framework.Constraints;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void SetUp()
        {
            def = new();
            p = new("A1B2","Description Test", 150, 49.50m);
        }

        [Test]
        public void TestConstructor() /*TODO: fix error, not running*/
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0, def.OnHandQuantity);
            Assert.AreEqual(0m, def.UnitPrice);

            Assert.IsNotNull(p);
            Assert.AreEqual("Description test", p.Description);
            Assert.AreEqual("A1B2", p.ProductCode);
            Assert.AreEqual(150, p.OnHandQuantity);
            Assert.AreEqual(49.50m, p.UnitPrice);
        }


        [Test]
        public void TestProductCodeSetter()
        {
            p.ProductCode = "A3B4";
            Assert.AreNotEqual("AA11", p.ProductCode);
            Assert.AreEqual("A3B4", p.ProductCode);
        }

        [Test]
        public void TestProductCodeOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "");
        }

        [Test]
        public void TestDescriptionSetter()
        {
            p.Description = "Jumbo Cupcake";
            Assert.AreNotEqual("mini tart", p.Description);
            Assert.AreEqual("Jumbo Cupcake", p.Description);
        }

        [Test]
        public void TestDescriptionOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "");
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "0123456789" +
            "123456789012345678901234567890123456789012345678901234567890123456789" +
            "123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestOnHandQuantitySetter()
        {
            p.OnHandQuantity = 374;
            Assert.AreNotEqual(45, p.OnHandQuantity);
            Assert.AreEqual(374, p.OnHandQuantity);
        }

        [Test]
        public void TestOnHandQuantityOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.OnHandQuantity = -5);
        }

        [Test]
        public void TestUnitPriceSetter() /*TODO: fix error, not running*/
        {
            p.UnitPrice = 123.45m;
            Assert.AreNotEqual(30, p.UnitPrice);
            Assert.AreEqual(123.45m, p.UnitPrice);
        }

        [Test]
        public void TestUnitPriceSetterOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = -5);
        }
    }
}
