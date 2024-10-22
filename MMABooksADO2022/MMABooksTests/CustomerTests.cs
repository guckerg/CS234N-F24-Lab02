using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using NUnit.Framework.Constraints;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void SetUp()
        {
            def = new();
            c = new(1, "Donald Duck", "101 Main Street", "Orlando", "FL", "10001");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreEqual("Donald Duck", c.Name);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreEqual("Orlando", c.City);
            Assert.AreEqual("FL", c.State);
            Assert.AreEqual("10001", c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Daisie Duck";
            Assert.AreNotEqual("Donald Duck", c.Name);
            Assert.AreEqual("Daisie Duck", c.Name);
        }

        [Test]
        public void TestNameSetteTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "");
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "0123456789" +
            "123456789012345678901234567890123456789012345678901234567890123456789" +
            "123456789012345678901234567890123456789012345678901234567890123456789");
        }
    }
}
