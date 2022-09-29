using StoredProceduresWithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StoredProceduresWithWebAPI.Controllers
{
    public class ValuesController : ApiController

    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);

        Employee emp = new Employee();

        // GET api/values
        public List<Employee> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetallEmployee", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);


            List<Employee> listEmployee = new List<Employee>();
            if (dt.Rows.Count > 0)
            {

                //foreach (var item in collection)
                //{

                //}
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.Name = dt.Rows[i]["Name"].ToString();
                    emp.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    emp.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
                    emp.Active = Convert.ToInt32(dt.Rows[i]["Active"]);
                    listEmployee.Add(emp);

                }

            }

            if (listEmployee.Count > 0)
            {
                return listEmployee;
            }
            else
            {
                return null;
            }
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_GetEmployeeById", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", id);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Employee emp = new Employee();

            if (dt.Rows.Count > 0)
            {

                emp.Name = dt.Rows[0]["Name"].ToString();
                emp.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                emp.Age = Convert.ToInt32(dt.Rows[0]["Age"]);
                emp.Active = Convert.ToInt32(dt.Rows[0]["Active"]);



            }

            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        // POST api/values
        public string Post(Employee employee)
        {
            string massage = "";
            if (employee != null)
            {
                SqlCommand cmd = new SqlCommand("usp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Actice", employee.Active);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    massage = "Data has been inserted";
                }
                else
                {
                    massage = "Error";
                }
            }
            return massage;

        }

        // PUT api/values/5
        public string Put(int id, Employee employee)
        {
            string massage = "";
            if (employee != null)
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Actice", employee.Active);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    massage = "Data has been Updated";
                }
                else
                {
                    massage = "Error";
                }
            }
            return massage;

        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            string massage = "";

            SqlCommand cmd = new SqlCommand("usp_DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                massage = "Data has been Deleted";
            }
            else
            {
                massage = "Error";
            }

            return massage;
        }
    }
}
