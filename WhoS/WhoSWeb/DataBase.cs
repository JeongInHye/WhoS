using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class DataBase
    {
        private SqlConnection connection;
        private bool status;

        public DataBase()
        {
            status = Connection();
        }

        private bool Connection()
        {
            string host = "(localdb)\\ProjectsV13";
            string user = "root";
            string pwd = "1234";
            string db = "WhoS";

            string connStr = string.Format("server={0};uid={1};password={2};database={3};", host, user, pwd, db);
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                connection = conn;
                return true;

            }
            catch
            {
                conn.Close();
                connection = null;
                return false;
            }
        }

        public void Close()
        {
            if (status)
            {
                connection.Close();
            }
        }

        public SqlDataReader Reader(string sql)
        {
            if (status)
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.StoredProcedure;
                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader Reader(string sql, Hashtable hashtable)
        {
            if (status)
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in hashtable)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool ReaderClose(SqlDataReader sdr)
        {
            try
            {
                sdr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int NonQuery(string sql, Hashtable ht)
        {
            if (status)
            {
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }
                    int cnt = comm.ExecuteNonQuery();
                    Console.WriteLine("------------------>>>>>>>>" + cnt);
                    return cnt;
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
