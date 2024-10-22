using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        //add instance variables
        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                if(value > 0)
                {
                    customerID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Customer ID must be a positive integer");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least one character and no more than 100 characters");
                }
            }
        }

        public string Address
        {
            get; set;
        }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
