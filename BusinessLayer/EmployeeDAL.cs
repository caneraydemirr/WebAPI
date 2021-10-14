using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class EmployeeDAL
    {
        sqlConnection con = new sqlConnection();
        public IEnumerable<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();
            SqlCommand cmd = new SqlCommand("Select * from Employees", con.Connection());

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var emp = new Employees();
                emp.EmployeeID = int.Parse(reader[0].ToString());
                emp.LastName = reader[1].ToString();
                emp.FirstName = reader[2].ToString();
                emp.Title = reader[3].ToString();
                emp.TitleOfCourtesy = reader[4].ToString();
                emp.BirthDate = Convert.ToDateTime(reader[5]);
                emp.HireDate = Convert.ToDateTime(reader[6]);
                emp.Address = reader[7].ToString();
                emp.City = reader[8].ToString();
                emp.Region = reader[9].ToString();
                emp.PostalCode = reader[10].ToString();
                emp.Country = reader[11].ToString();
                emp.HomePhone = reader[12].ToString();
                emp.Extension = reader[13].ToString();
                //emp.Photo = (byte[])reader[14];
                emp.Notes = reader[15].ToString();
                emp.ReportsTo = int.Parse(reader[16].ToString());
                emp.PhotoPath = reader[17].ToString();
                employees.Add(emp);
            }
            reader.Close();
            return employees;
        }

        public Employees GetEmployeeById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Employees where EmployeeID='" + int.Parse(id.ToString()) + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            var emp = new Employees();
            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
 
                    emp.EmployeeID = int.Parse(reader[0].ToString());
                    emp.LastName = reader[1].ToString();
                    emp.FirstName = reader[2].ToString();
                    emp.Title = reader[3].ToString();
                    emp.TitleOfCourtesy = reader[4].ToString();
                    emp.BirthDate = Convert.ToDateTime(reader[5]);
                    emp.HireDate = Convert.ToDateTime(reader[6]);
                    emp.Address = reader[7].ToString();
                    emp.City = reader[8].ToString();
                    emp.Region = reader[9].ToString();
                    emp.PostalCode = reader[10].ToString();
                    emp.Country = reader[11].ToString();
                    emp.HomePhone = reader[12].ToString();
                    emp.Extension = reader[13].ToString();
                    //emp.Photo = (byte[])reader[14];
                    emp.Notes = reader[15].ToString();
                    emp.ReportsTo = int.Parse(reader[16].ToString());
                    emp.PhotoPath = reader[17].ToString();
                }
            }
            return emp;
        }

        public Employees CreateEmployee(Employees employees)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (LastName,FirstName,Title,TitleOfCourtesy," +
                "BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Notes,ReportsTo,PhotoPath) VALUES (@LastName,@FirstName,@Title," +
                "@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Notes,@ReportsTo,@PhotoPath)", con.Connection());
            //cmd.Parameters.AddWithValue("@EmployeeID", employees.EmployeeID.ToString());
            cmd.Parameters.AddWithValue("@LastName", employees.LastName.ToString());
            cmd.Parameters.AddWithValue("@FirstName", employees.FirstName.ToString());
            cmd.Parameters.AddWithValue("@Title", employees.Title.ToString());
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", employees.TitleOfCourtesy.ToString());
            cmd.Parameters.AddWithValue("@BirthDate", employees.BirthDate.ToString());
            cmd.Parameters.AddWithValue("@HireDate", employees.HireDate.ToString());
            cmd.Parameters.AddWithValue("@Address", employees.Address.ToString());
            cmd.Parameters.AddWithValue("@City", employees.City.ToString());
            cmd.Parameters.AddWithValue("@Region", employees.Region.ToString());
            cmd.Parameters.AddWithValue("@PostalCode", employees.PostalCode.ToString());
            cmd.Parameters.AddWithValue("@Country", employees.Country.ToString());
            cmd.Parameters.AddWithValue("@HomePhone", employees.HomePhone.ToString());
            cmd.Parameters.AddWithValue("@Extension", employees.Extension.ToString());
            //cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Notes", employees.Notes.ToString());
            cmd.Parameters.AddWithValue("@ReportsTo", int.Parse(employees.ReportsTo.ToString()));
            cmd.Parameters.AddWithValue("@PhotoPath", employees.PhotoPath.ToString());
            cmd.ExecuteNonQuery();
            return employees;
        }

        public Employees UpdateEmployee(int id, Employees employees)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Employees set LastName=@LastName,FirstName=@FirstName,Title=@Title," +
                "TitleOfCourtesy=@TitleOfCourtesy,BirthDate=@BirthDate,HireDate=@HireDate,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country" +
                ",HomePhone=@HomePhone,Extension=@Extension,Notes=@Notes,ReportsTo=@ReportsTo,PhotoPath=@PhotoPath where EmployeeID='" + int.Parse(id.ToString()) + "'", con.Connection());
            //cmd.Parameters.AddWithValue("@EmployeeID", Employees.EmployeeID.ToString());
            cmd.Parameters.AddWithValue("@LastName", employees.LastName.ToString());
            cmd.Parameters.AddWithValue("@FirstName", employees.FirstName.ToString());
            cmd.Parameters.AddWithValue("@Title", employees.Title.ToString());
            cmd.Parameters.AddWithValue("@TitleOfCourtesy", employees.TitleOfCourtesy.ToString());
            cmd.Parameters.AddWithValue("@BirthDate", employees.BirthDate.ToString());
            cmd.Parameters.AddWithValue("@HireDate", employees.HireDate.ToString());
            cmd.Parameters.AddWithValue("@Address", employees.Address.ToString());
            cmd.Parameters.AddWithValue("@City", employees.City.ToString());
            cmd.Parameters.AddWithValue("@Region", employees.Region.ToString());
            cmd.Parameters.AddWithValue("@PostalCode", employees.PostalCode.ToString());
            cmd.Parameters.AddWithValue("@Country", employees.Country.ToString());
            cmd.Parameters.AddWithValue("@HomePhone", employees.HomePhone.ToString());
            cmd.Parameters.AddWithValue("@Extension", employees.Extension.ToString());
            cmd.Parameters.AddWithValue("@Notes", employees.Notes.ToString());
            cmd.Parameters.AddWithValue("@ReportsTo", employees.ReportsTo.ToString());
            cmd.Parameters.AddWithValue("@PhotoPath", employees.PhotoPath.ToString());
            cmd.ExecuteNonQuery();
            return employees;
        }

        public void DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID ='" + int.Parse(id.ToString()) + "'", con.Connection());
            cmd.ExecuteNonQuery();
        }

        public bool IsAnyEmployee(int id)
        {
            List<Employees> employees = new List<Employees>();
            SqlCommand cmd = new SqlCommand("Select * from Employees where EmployeeID='" + int.Parse(id.ToString()) + "'", con.Connection());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var emp = new Employees();
                emp.EmployeeID = int.Parse(reader[0].ToString());
                emp.LastName = reader[1].ToString();
                emp.FirstName = reader[2].ToString();
                emp.Title = reader[3].ToString();
                emp.TitleOfCourtesy = reader[4].ToString();
                emp.BirthDate = Convert.ToDateTime(reader[5]);
                emp.HireDate = Convert.ToDateTime(reader[6]);
                emp.Address = reader[7].ToString();
                emp.City = reader[8].ToString();
                emp.Region = reader[9].ToString();
                emp.PostalCode = reader[10].ToString();
                emp.Country = reader[11].ToString();
                emp.HomePhone = reader[12].ToString();
                emp.Extension = reader[13].ToString();
                //emp.Photo = (byte[])reader[14];
                emp.Notes = reader[15].ToString();
                emp.ReportsTo = int.Parse(reader[16].ToString());
                emp.PhotoPath = reader[17].ToString();
                employees.Add(emp);
            }
            reader.Close();
            if (employees.Count > 0)
                return true;
            else
                return false;
        }
    }
}
