using Data.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OrderDAL
    {
        sqlConnection con = new sqlConnection();
        
        public IEnumerable<Orders> GetAllOrders()
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders", con.Connection());
            List<Orders> orders = new List<Orders>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ord = new Orders();
                ord.OrderID = int.Parse(reader[0].ToString());
                ord.CustomerID = reader[1].ToString();
                ord.EmployeeID = int.Parse(reader[2].ToString());
                ord.OrderDate = Convert.ToDateTime(reader[3]);
                ord.RequiredDate = Convert.ToDateTime(reader[4]);
                //ord.ShippedDate = Convert.ToDateTime(reader[5]);
                ord.ShipVia = int.Parse(reader[6].ToString());
                ord.Freight = decimal.Parse(reader[7].ToString());
                ord.ShipName = reader[8].ToString();
                ord.ShipAddress = reader[9].ToString();
                ord.ShipCity = reader[10].ToString();
                ord.ShipRegion = reader[11].ToString();
                ord.ShipPostalCode = reader[12].ToString();
                ord.ShipCountry = reader[13].ToString();
                orders.Add(ord);
            }
            reader.Close();
            return orders;
        }

        public Orders GetOrderById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Orders where OrderID='" + int.Parse(id.ToString()) + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var ord = new Orders();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    ord.OrderID = int.Parse(reader[0].ToString());
                    ord.CustomerID = reader[1].ToString();
                    ord.EmployeeID = int.Parse(reader[2].ToString());
                    ord.OrderDate = Convert.ToDateTime(reader[3]);
                    ord.RequiredDate = Convert.ToDateTime(reader[4]);
                    ord.ShippedDate = Convert.ToDateTime(reader[5]);
                    ord.ShipVia = int.Parse(reader[6].ToString());
                    ord.Freight = decimal.Parse(reader[7].ToString());
                    ord.ShipName = reader[8].ToString();
                    ord.ShipAddress = reader[9].ToString();
                    ord.ShipCity = reader[10].ToString();
                    ord.ShipRegion = reader[11].ToString();
                    ord.ShipPostalCode = reader[12].ToString();
                    ord.ShipCountry = reader[13].ToString();
                }
            }
            return ord;
        }

        public Orders CreateOrder(Orders orders)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders (CustomerID,EmployeeID,OrderDate,RequiredDate," +
                "ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) VALUES (@CustomerID,@EmployeeID,@OrderDate," +
                "@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry)", con.Connection());
            //cmd.Parameters.AddWithValue("@OrderID", orders.OrderID.ToString());
            cmd.Parameters.AddWithValue("@CustomerID", orders.CustomerID.ToString());
            cmd.Parameters.AddWithValue("@EmployeeID", orders.EmployeeID.ToString());
            cmd.Parameters.AddWithValue("@OrderDate", Convert.ToDateTime(orders.OrderDate.ToString()));
            cmd.Parameters.AddWithValue("@RequiredDate", Convert.ToDateTime(orders.RequiredDate.ToString()));
            cmd.Parameters.AddWithValue("@ShippedDate", Convert.ToDateTime(orders.ShippedDate.ToString()));
            cmd.Parameters.AddWithValue("@ShipVia", orders.ShipVia.ToString());
            cmd.Parameters.AddWithValue("@Freight", orders.Freight.ToString());
            cmd.Parameters.AddWithValue("@ShipName", orders.ShipName.ToString());
            cmd.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress.ToString());
            cmd.Parameters.AddWithValue("@ShipCity", orders.ShipCity.ToString());
            cmd.Parameters.AddWithValue("@ShipRegion", orders.ShipRegion.ToString());
            cmd.Parameters.AddWithValue("@ShipPostalCode", orders.ShipPostalCode.ToString());
            cmd.Parameters.AddWithValue("@ShipCountry", orders.ShipCountry.ToString());
            cmd.ExecuteNonQuery();
            return orders;
        }

        public Orders UpdateOrder(int id, Orders orders)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Orders set CustomerID=@CustomerID,EmployeeID=@EmployeeID,OrderDate=@OrderDate," +
                "RequiredDate=@RequiredDate,ShipVia=@ShipVia,Freight=@Freight,ShipName=@ShipName,ShipAddress=@ShipAddress" +
                ",ShipCity=@ShipCity,ShipRegion=@ShipRegion,ShipPostalCode=@ShipPostalCode,ShipCountry=@ShipCountry where OrderID='" + int.Parse(id.ToString()) + "'", con.Connection());
            //cmd.Parameters.AddWithValue("@OrderID", Orders.ordloyeeID.ToString());
            cmd.Parameters.AddWithValue("@CustomerID", orders.CustomerID.ToString());
            cmd.Parameters.AddWithValue("@EmployeeID", orders.EmployeeID.ToString());
            cmd.Parameters.AddWithValue("@OrderDate", orders.OrderDate.ToString());
            cmd.Parameters.AddWithValue("@RequiredDate", orders.RequiredDate.ToString());
            //cmd.Parameters.AddWithValue("@ShippedDate", orders.ShippedDate.ToString());
            cmd.Parameters.AddWithValue("@ShipVia", orders.ShipVia.ToString());
            cmd.Parameters.AddWithValue("@Freight", orders.Freight);
            cmd.Parameters.AddWithValue("@ShipName", orders.ShipName.ToString());
            cmd.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress.ToString());
            cmd.Parameters.AddWithValue("@ShipCity", orders.ShipCity.ToString());
            cmd.Parameters.AddWithValue("@ShipRegion", orders.ShipRegion.ToString());
            cmd.Parameters.AddWithValue("@ShipPostalCode", orders.ShipPostalCode.ToString());
            cmd.Parameters.AddWithValue("@ShipCountry", orders.ShipCountry.ToString());
            cmd.ExecuteNonQuery();
            return orders;
        }

        public void DeleteOrder(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE OrderID ='" + int.Parse(id.ToString()) + "'", con.Connection());
            cmd.ExecuteNonQuery();
        }

        public bool IsAnyOrder(int id)
        {
            List<Orders> orders = new List<Orders>();
            SqlCommand cmd = new SqlCommand("Select * from Orders where OrderID='" + int.Parse(id.ToString()) + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ord = new Orders();
                ord.OrderID = int.Parse(reader[0].ToString());
                ord.CustomerID = reader[1].ToString();
                ord.EmployeeID = int.Parse(reader[2].ToString());
                ord.OrderDate = Convert.ToDateTime(reader[3]);
                ord.RequiredDate = Convert.ToDateTime(reader[4]);
                ord.ShippedDate = Convert.ToDateTime(reader[5]);
                ord.ShipVia = int.Parse(reader[6].ToString());
                ord.Freight = decimal.Parse(reader[7].ToString());
                ord.ShipName = reader[8].ToString();
                ord.ShipAddress = reader[9].ToString();
                ord.ShipCity = reader[10].ToString();
                ord.ShipRegion = reader[11].ToString();
                ord.ShipPostalCode = reader[12].ToString();
                ord.ShipCountry = reader[13].ToString();
                orders.Add(ord);
            }
            reader.Close();
            if (orders.Count > 0)
                return true;
            else
                return false;
        }
    }
}
