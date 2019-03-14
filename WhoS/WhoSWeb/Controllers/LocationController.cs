using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    public class LocationController : ControllerBase
    {
        private DataBase dataBase;
        private Hashtable hashtable;

        [Route("Location/AllSelect")]
        [HttpGet]
        public ActionResult<ArrayList> LocationAllSelect()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("sp_LocationAllSelect");

            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (i == 3)
                    {
                        string str = sdr.GetValue(3).ToString();
                        string substring = str.Substring(0, 11);
                        arr[i] = substring;
                    }
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

        [Route("Location/LocationBtn")]
        [HttpPost]
        public ActionResult<ArrayList> ClientEdeitSelect([FromForm] string lNo)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@lNo", lNo);
            SqlDataReader sdr = dataBase.Reader("sp_LocationBtn", hashtable);
            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    arr[i] = sdr.GetValue(i).ToString();
                    if (i == 3)
                    {
                        string str = sdr.GetValue(3).ToString();
                        string substring = str.Substring(0, 11);
                        arr[i] = substring;
                    }
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

        [Route("test/test")]
        [HttpGet]
        public ActionResult<ArrayList> test()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("test");

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
    }
}