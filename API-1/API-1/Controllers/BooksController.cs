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
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<BookModels> Get()
        {
            //return new string[] { "value1", "value2" };
            SqlConnection conn = databaseConnections.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BookModels> output = new List<BookModels>();

            try
            {
                conn.Open();

                query = "select * from Books";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BookModels(int.Parse(rdr["isbn"].ToString()),
                        rdr["title"].ToString(),
                        int.Parse(rdr["borrower"].ToString()),
                        int.Parse(rdr["author"].ToString())));
                    /*output.Add(
                        "{isbn: " + rdr.GetValue(0) +
                        ", title: \"" + rdr.GetValue(1) + "\"" +
                        ", borrower: \"" + rdr.GetValue(2) + "\"}" +
                        ", author: \"" + rdr.GetValue(3) + "\"}");*/
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

        // GET: api/Books/5
        public string Get(int isbn, string title, int borrower, int author)
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

                query = "select * from Books where ISBN = " + isbn;
                query = "select * from Books where Title = " + title;
                query = "select * from Books where Borrower = " + borrower;
                query = "select * from Books where Author = " + author;

                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = "{isbn: " + rdr.GetValue(0) +
                        ", title: \"" + rdr.GetValue(1) + "\"" +
                        ", borrower: \"" + rdr.GetValue(2) + "\" +" +
                        ", author: \"" + rdr.GetValue(3) + "\"}";
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

        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
