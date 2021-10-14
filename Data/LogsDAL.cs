using Data;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LogsDAL
    {
        sqlConnection con = new sqlConnection();
        public IEnumerable<Logs> GetAllLogs()
        {
            List<Logs> logList = new List<Logs>();
            SqlCommand cmd = new SqlCommand("Select * from Logs", con.Connection());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var log = new Logs();
                log.LogID = int.Parse(reader[0].ToString());
                log.Name = reader[1].ToString();
                log.Date = Convert.ToDateTime(reader[2].ToString());
                log.UserName = reader[3].ToString();
                log.Type = reader[4].ToString();
                logList.Add(log);
            }
            reader.Close();
            return logList;
        }

        public Logs GetlogperById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Logs where logID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var log = new Logs();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    log.LogID = int.Parse(reader[0].ToString());
                    log.Name = reader[1].ToString();
                    log.Date = Convert.ToDateTime(reader[2].ToString());
                    log.UserName = reader[3].ToString();
                    log.Type = reader[4].ToString();
                }
            }
            return log;
        }

        public Logs Createlogper(Logs logs)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Logs (Name,Date,UserName,Type) VALUES (@Name,@Date,@UserName,@Type)", con.Connection());
            cmd.Parameters.AddWithValue("@Name", logs.Name.ToString());
            cmd.Parameters.AddWithValue("@Date", logs.Date.ToString());
            cmd.Parameters.AddWithValue("@UserName", logs.UserName.ToString());
            cmd.Parameters.AddWithValue("@Type", logs.Type.ToString());
            cmd.ExecuteNonQuery();
            return logs;
        }

        public Logs Updatelogper(int id, Logs logs)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Logs set Name=@Name, Date=@Date, UserName=@UserName, Type=@Type WHERE logID='" +
                int.Parse(id.ToString()) + "'", con.Connection());
            cmd.Parameters.AddWithValue("@Name", logs.Name.ToString());
            cmd.Parameters.AddWithValue("@Date", logs.Date.ToString());
            cmd.Parameters.AddWithValue("@UserName", logs.UserName.ToString());
            cmd.Parameters.AddWithValue("@Type", logs.Type.ToString());
            cmd.ExecuteNonQuery();
            return logs;
        }

        public void Deletelogper(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Logs WHERE logID ='" + int.Parse(id.ToString()) + "'", con.Connection());
            cmd.ExecuteNonQuery();
        }

        public bool IsAnylogper(int id)
        {
            List<Logs> logList = new List<Logs>();
            SqlCommand cmd = new SqlCommand("Select * from Logs where logID='" + id + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var log = new Logs();
                log.LogID = int.Parse(reader[0].ToString());
                log.Name = reader[1].ToString();
                log.Date = Convert.ToDateTime(reader[2].ToString());
                log.UserName = reader[3].ToString();
                log.Type = reader[4].ToString();
                logList.Add(log);
            }
            reader.Close();
            if (logList.Count > 0)
                return true;
            else
                return false;
        }
    }
}
