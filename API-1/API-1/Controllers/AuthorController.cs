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
    public class AuthorController : ApiController
    {
        // GET: api/Author
        public IEnumerable<AuthorModels> Get()
        {
            //return new string[] { "value1", "value2" };
            SqlConnection conn = databaseConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<AuthorModels> output = new List<AuthorModels>();

            try
            {
                conn.Open();

                query = "select * from Author";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new AuthorModels(int.Parse(rdr["id"].ToString()),
                        rdr["firstname"].ToString(),
                        rdr["surname"].ToString()));
                    /* output.Add(
                        "{id: " + rdr.GetValue(0) +
                        ", firstname: \"" + rdr.GetValue(1) + "\"" +
                        ", surname: \"" + rdr.GetValue(2) + "\"}"); */
                }
            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
                //output.Add(e.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            conn.Close();

            return output;
        }
    
        // GET: api/Author/5
        public string Get(int id, string firstname, string surname)
        {
            //return "value";
            SqlConnection conn = databaseConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            string output = "no record found";

            try
            {
                conn.Open();

                query = "select * from Author where Author ID = " + id;
                query = "select * from Author where Author First Name = " + firstname;
                query = "select * from Author where Author Surname = " + surname;

                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = "{id: " + rdr.GetValue(0) +
                        ", firstname: \"" + rdr.GetValue(1) + "\"" +
                        ", surname: \"" + rdr.GetValue(2) + "\"}";
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
        

        // POST: api/Author
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Author/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Author/5
        public void Delete(int id)
        {
        }
    }
}
