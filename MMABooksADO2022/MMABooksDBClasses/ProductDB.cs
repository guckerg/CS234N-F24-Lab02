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
                = "SELECT Description, ProductCode, OnHandQuantity, UnitPrice "
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
                    product.ProductCode = (string)custReader["ProductCode"];
                    product.Description = (string)custReader["Description"];
                    product.OnHandQuantity = Convert.ToInt32(custReader["OnHandQuantity"]);
                    product.UnitPrice = Convert.ToDecimal(custReader["UnitPrice"]);
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

        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(Description, ProductCode, OnHandQuantity, UnitPrice) " +
                "VALUES (@Description, @ProductCode, @OnHandQuantity, @UnitPrice)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProdutCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                string productCode = (string)selectCommand.ExecuteScalar();
                return productCode;
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

        public static bool UpdateProduct(Product oldProduct,
            Product newProduct)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "UnitPrice = @NewUnitPrice, " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND OnHandQuantity = @OldOnHandQuantity " +
                "AND UnitPrice = @OldUnitPrice ";
            // setup the command object
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
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
