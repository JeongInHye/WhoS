using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhoSWebAPI.Controllers
{
    public class EnterController : Controller
    {
        private DataBase dataBase;
        private Hashtable hashtable;

        [Route("Enter/ClientName")]
        [HttpGet]
        public ActionResult<ArrayList> ClientName()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("sp_ClientName");

            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                }
                list.Add(arr);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }

        [Route("Enter/EnterAllSelect")]
        [HttpGet]
        public ActionResult<ArrayList> EnterAllSelect()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("sp_EnterAllSelect");

            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (i == 4)
                    {
                        string str = sdr.GetValue(4).ToString();
                        string substring = str.Substring(0, 11);
                        arr[i] = substring;
                    }
                }
                list.Add(arr);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }

        [Route("Enter/ClientNameSelect")]
        [HttpPost]
        public ActionResult<ArrayList> ClientNameSelect([FromForm]string cName)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@cName", cName);
            SqlDataReader sdr = dataBase.Reader("sp_ClientNameSelect", hashtable);
            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (i == 4)
                    {
                        string str = sdr.GetValue(4).ToString();
                        string substring = str.Substring(0, 11);
                        arr[i] = substring;
                    }
                }
                list.Add(arr);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }
    }
}
