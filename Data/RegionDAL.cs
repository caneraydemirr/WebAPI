using System.Collections.Generic;
using System.Data.SqlClient;
using DataLayer;

namespace DataLayer
{
    public class RegionDAL
    {
        sqlConnection con = new sqlConnection();
        public IEnumerable<Regions> GetAllRegions()
        {
            List<Regions> regions = new List<Regions>();
            SqlCommand cmd = new SqlCommand("Select * from Region", con.Connection());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var reg = new Regions();
                reg.RegionID = int.Parse(reader[0].ToString()); // Probably needs fixing
                reg.RegionDescription = reader[1].ToString(); // Probably needs fixing
                regions.Add(reg);
            }
            reader.Close();
            return regions;
        }

        public Regions GetRegionById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Region where RegionID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var reg = new Regions();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    reg.RegionID = int.Parse(reader[0].ToString());
                    reg.RegionDescription = reader[1].ToString();
                }
            }
            return reg;
        }

        public Regions CreateRegion(Regions regions)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Region (RegionID,RegionDescription) VALUES (@RegionID,@RegionDescription)", con.Connection());
            cmd.Parameters.AddWithValue("@RegionID", int.Parse(regions.RegionID.ToString()));
            cmd.Parameters.AddWithValue("@RegionDescription", regions.RegionDescription.ToString());
            cmd.ExecuteNonQuery();
            return regions;
        }

        public Regions UpdateRegion(int id, Regions regions)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Region set RegionID=@RegionID, RegionDescription=@RegionDescription WHERE RegionID='" + 
                int.Parse(id.ToString()) + "'", con.Connection());
            cmd.Parameters.AddWithValue("@RegionID", int.Parse(regions.RegionID.ToString()));
            cmd.Parameters.AddWithValue("@RegionDescription", regions.RegionDescription.ToString());
            cmd.ExecuteNonQuery();
            return regions;
        }

        public void DeleteRegion(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Region WHERE RegionID ='"+id+"'", con.Connection());
            cmd.ExecuteNonQuery();
            sqlConnection sqlConn = new sqlConnection();
            //sqlConn.con.Close();
        }

        public bool IsAnyRegion(int id)
        {
            List<Regions> regions = new List<Regions>();
            SqlCommand cmd = new SqlCommand("Select * from Region where RegionID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var reg = new Regions();
                reg.RegionID = int.Parse(reader[0].ToString()); // Probably needs fixing
                reg.RegionDescription = reader[1].ToString(); // Probably needs fixing
                regions.Add(reg);
            }
            reader.Close();
            if (regions.Count > 0)
                return true;
            else
                return false;
        }
    }
}
