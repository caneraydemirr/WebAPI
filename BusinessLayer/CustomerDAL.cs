using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CustomerDAL
    {
        sqlConnection con = new sqlConnection();
        public IEnumerable<Customers> GetAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            SqlCommand cmd = new SqlCommand("Select * from Customers", con.Connection());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cus = new Customers();
                cus.CustomerID = reader[0].ToString();
                cus.CompanyName = reader[1].ToString();
                cus.ContactName = reader[2].ToString();
                cus.ContactTitle = reader[3].ToString();
                cus.Address = reader[4].ToString();
                cus.City = reader[5].ToString();
                cus.Region = reader[6].ToString();
                cus.PostalCode = reader[7].ToString();
                cus.Country = reader[8].ToString();
                cus.Phone = reader[9].ToString();
                cus.Fax = reader[10].ToString();
                customers.Add(cus);
            }
            reader.Close();
            return customers;
        }

        public Customers GetCustomerById(string id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Customers where CustomerID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var cus = new Customers();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    cus.CustomerID = reader[0].ToString();
                    cus.CompanyName = reader[1].ToString();
                    cus.ContactName = reader[2].ToString();
                    cus.ContactTitle = reader[3].ToString();
                    cus.Address = reader[4].ToString();
                    cus.City = reader[5].ToString();
                    cus.Region = reader[6].ToString();
                    cus.PostalCode = reader[7].ToString();
                    cus.Country = reader[8].ToString();
                    cus.Phone = reader[9].ToString();
                    cus.Fax = reader[10].ToString();
                }
            }
            return cus;
        }

        public Customers CreateCustomer(Customers customers)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address," +
                "City,Region,PostalCode,Country,Phone,Fax) VALUES (@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address," +
                "@City,@Region,@PostalCode,@Country,@Phone,@Fax)", con.Connection());
            cmd.Parameters.AddWithValue("@CustomerID", customers.CustomerID.ToString());
            cmd.Parameters.AddWithValue("@CompanyName", customers.CompanyName.ToString());
            cmd.Parameters.AddWithValue("@ContactName", customers.ContactName.ToString());
            cmd.Parameters.AddWithValue("@ContactTitle", customers.ContactTitle.ToString());
            cmd.Parameters.AddWithValue("@Address", customers.Address.ToString());
            cmd.Parameters.AddWithValue("@City", customers.City.ToString());
            cmd.Parameters.AddWithValue("@Region", customers.Region.ToString());
            cmd.Parameters.AddWithValue("@PostalCode", customers.PostalCode.ToString());
            cmd.Parameters.AddWithValue("@Country", customers.Country.ToString());
            cmd.Parameters.AddWithValue("@Phone", customers.Phone.ToString());
            cmd.Parameters.AddWithValue("@Fax", customers.Fax.ToString());
            cmd.ExecuteNonQuery();
            return customers;
        }

        public Customers UpdateCustomer(string id, Customers customers)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Customers set CustomerID=@CustomerID, CompanyName=@CompanyName, ContactName=@ContactName," +
                "ContactTitle=@ContactTitle, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country," +
                "Phone=@Phone, Fax=@Fax WHERE CustomerID='" + id.ToString() + "'", con.Connection());
            cmd.Parameters.AddWithValue("@CustomerID", customers.CustomerID.ToString());
            cmd.Parameters.AddWithValue("@CompanyName", customers.CompanyName.ToString());
            cmd.Parameters.AddWithValue("@ContactName", customers.ContactName.ToString());
            cmd.Parameters.AddWithValue("@ContactTitle", customers.ContactTitle.ToString());
            cmd.Parameters.AddWithValue("@Address", customers.Address.ToString());
            cmd.Parameters.AddWithValue("@City", customers.City.ToString());
            cmd.Parameters.AddWithValue("@Region", customers.Region.ToString());
            cmd.Parameters.AddWithValue("@PostalCode", customers.PostalCode.ToString());
            cmd.Parameters.AddWithValue("@Country", customers.Country.ToString());
            cmd.Parameters.AddWithValue("@Phone", customers.Phone.ToString());
            cmd.Parameters.AddWithValue("@Fax", customers.Fax.ToString());
            cmd.ExecuteNonQuery();
            return customers;
        }

        public void DeleteCustomer(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID ='" + id + "'", con.Connection());
            cmd.ExecuteNonQuery();
        }

        public bool IsAnyCustomer(string id)
        {
            List<Customers> customers = new List<Customers>();
            SqlCommand cmd = new SqlCommand("Select * from Customers where CustomerID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cus = new Customers();
                cus.CustomerID = reader[0].ToString(); // Probably needs fixing
                cus.CompanyName = reader[1].ToString(); // Probably needs fixing
                customers.Add(cus);
            }
            reader.Close();
            if (customers.Count > 0)
                return true;
            else
                return false;
        }
    }
}
