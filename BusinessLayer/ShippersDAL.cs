using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class ShippersDAL
    {
        sqlConnection con = new sqlConnection();
        public IEnumerable<Shippers> GetAllShippers()
        {
            List<Shippers> Shippers = new List<Shippers>();
            SqlCommand cmd = new SqlCommand("Select * from Shippers", con.Connection());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ship = new Shippers();
                ship.ShipperID = int.Parse(reader[0].ToString());
                ship.CompanyName = reader[1].ToString();
                ship.Phone = reader[2].ToString();
                Shippers.Add(ship);
            }
            reader.Close();
            return Shippers;
        }

        public Shippers GetShipperById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Shippers where ShipperID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var ship = new Shippers();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    ship.ShipperID = int.Parse(reader[0].ToString());
                    ship.CompanyName = reader[1].ToString();
                    ship.Phone = reader[2].ToString();
                }
            }
            return ship;
        }

        public Shippers CreateShipper(Shippers shippers)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Shippers (CompanyName,Phone) VALUES (@CompanyName,@Phone)", con.Connection());
            //cmd.Parameters.AddWithValue("@ShipperID", int.Parse(shippers.ShipperID.ToString()));
            cmd.Parameters.AddWithValue("@CompanyName", shippers.CompanyName.ToString());
            cmd.Parameters.AddWithValue("@Phone", shippers.Phone.ToString());
            cmd.ExecuteNonQuery();
            return shippers;
        }

        public Shippers UpdateShipper(int id, Shippers shippers)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Shippers set CompanyName=@CompanyName, Phone=@Phone WHERE ShipperID='" +
                int.Parse(id.ToString()) + "'", con.Connection());
            //cmd.Parameters.AddWithValue("@ShipperID", int.Parse(shippers.ShipperID.ToString()));
            cmd.Parameters.AddWithValue("@CompanyName", shippers.CompanyName.ToString());
            cmd.Parameters.AddWithValue("@Phone", shippers.Phone.ToString());
            cmd.ExecuteNonQuery();
            return shippers;
        }

        public void DeleteShipper(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Shippers WHERE ShipperID ='" + int.Parse(id.ToString()) + "'", con.Connection());
            cmd.ExecuteNonQuery();
        }

        public bool IsAnyShipper(int id)
        {
            List<Shippers> Shippers = new List<Shippers>();
            SqlCommand cmd = new SqlCommand("Select * from Shippers where ShipperID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ship = new Shippers();
                ship.ShipperID = int.Parse(reader[0].ToString());
                ship.CompanyName = reader[1].ToString();
                ship.Phone = reader[2].ToString();
                Shippers.Add(ship);
            }
            reader.Close();
            if (Shippers.Count > 0)
                return true;
            else
                return false;
        }
    }
}
