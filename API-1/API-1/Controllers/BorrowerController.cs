using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using API_1.Models;


namespace API_1.Controllers
{
    public class BorrowerController : ApiController
    {
        // GET: api/Borrower
        public IEnumerable<BorrowerModels> Get()
        {
            //return new string[] { "value1", "value2" };
            SqlConnection conn = databaseConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BorrowerModels> output = new List<BorrowerModels>();

            try
            {
                conn.Open();

                query = "select * from Borrower";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BorrowerModels(int.Parse(rdr["id"].ToString()),
                        rdr["firstname"].ToString(),
                        rdr["surname"].ToString(),
                        rdr["DOB"].ToString()));
                       /* "{id: " + rdr.GetValue(0) +
                        ", firstname: \"" + rdr.GetValue(1) + "\"" +
                        ", surname: \"" + rdr.GetValue(2) + "\"}" +
                        ", dob: \"" + rdr.GetValue(3) + "\"}"); */
                }
            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            conn.Close();

            return output;
        }

        // GET: api/Borrower/5
        public string Get(int id, string firstname, string surname, string dob)
        {
            // return "value";
            SqlConnection conn = databaseConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            string output = "no record found";

            try
            {
                conn.Open();

                query = "select * from Borrower where Borrower ID = " + id;
                query = "select * from Borrower where Borrower First Name = " + firstname;
                query = "select * from Borrower where Borrower Surname = " + surname;
                query = "select * from Borrower where Borrower DOB = " + dob;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = "{id: " + rdr.GetValue(0) +
                        ", firstname: \"" + rdr.GetValue(1) + "\"" +
                        ", surname: \"" + rdr.GetValue(2) + "\"" +
                        ", dob: \"" + rdr.GetValue(3) + "\"}";
                }
            }

            catch (Exception e)
            {
                output = e.Message;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            conn.Close();

            return output;
        }

        // POST: api/Borrower
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrower/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrower/5
        public void Delete(int id)
        {
        }
    }
}
