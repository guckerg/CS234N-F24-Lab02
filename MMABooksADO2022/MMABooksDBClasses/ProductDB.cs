using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, OnHandQuantity, UnitPrice "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = custReader["ProductCode"].ToString();
                    product.Description = custReader["Description"].ToString();
                    product.OnHandQuantity = (int)custReader["OnHandQuantity"];
                    product.UnitPrice = (decimal)custReader["UnitPrice"];

                    custReader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static Product AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            try
            {
                connection.Open();
                string selectStatement
                = "SELECT ProductCode, Description, OnHandQuantity, UnitPrice "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Product p = new Product();
                    p.ProductCode = custReader["ProductCode"].ToString();
                    p.Description = custReader["Description"].ToString();
                    p.OnHandQuantity = (int)custReader["OnHandQuantity"];
                    p.UnitPrice = (decimal)custReader["UnitPrice"];

                    custReader.Close();
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            // get a connection to the database
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND OnHandQuantity = @OnHandQuantity " +
                "AND UnitPrice = @UnitPrice ";
            // set up the command object
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            try
            {
                // open the connection
                connection.Open();
                // execute the command
                MySqlDataReader reader = deleteCommand.ExecuteReader();
                // if the number of records returned = 1, return true otherwise return false
                if (reader.HasRows)
                {
                    deleteCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity ";
            // setup the command object
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue
                ("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue
                ("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue
                ("@NewOnHandQuantity", newProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue
                ("@OldProductCode", newProduct.ProductCode);
            updateCommand.Parameters.AddWithValue
                ("@OldDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue
                ("@OldUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue
                ("@OldOnHandQuantity", newProduct.OnHandQuantity);
            try
            {
                // open the connection
                connection.Open();
                // execute the command
                MySqlDataReader reader = updateCommand.ExecuteReader();
                // if the number of records returned = 1, return true otherwise return false
                if (reader.HasRows)
                {
                    updateCommand.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }
    }
}
