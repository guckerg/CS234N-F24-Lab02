using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string productCode, string description, int onHandQuantity, decimal unitPrice)
        {
            ProductCode = productCode;
            Description = description;
            OnHandQuantity = onHandQuantity;
            UnitPrice = unitPrice;
        }

        private string productCode;
        private string description;
        private int onHandQuantity;
        private decimal unitPrice;

        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                {
                    productCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least one character and no more than 100 characters");
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least one character and no more than 100 characters");
                }
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }
            set
            {
                if (value >= 0)
                {
                    onHandQuantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Quantity cannot be negative value");
                }
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value >= 0)
                {
                    unitPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Unit Price cannot be negative value");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
