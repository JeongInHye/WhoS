using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WhoSWebAPI.Controllers
{
    public class EnterOutController : Controller
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

        [Route("Enter/EnterSelectNum")]
        [HttpPost]
        public ActionResult<ArrayList> EnterSelectNum([FromForm] int pNum)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@pNum", pNum);
            SqlDataReader sdr = dataBase.Reader("sp_EnterSelectNum", hashtable);
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
            SqlDataReader sdr = dataBase.Reader("sp_EnterClientNameSelect", hashtable);
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

        [Route("Enter/LocationAdd")]
        [HttpPost]
        public ActionResult<string> LocationAdd([FromForm]string pNum,[FromForm]string lNo)
        {
            hashtable = new Hashtable();
            hashtable.Add("@pNum", pNum);
            hashtable.Add("@lNo", lNo);

            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_LocationAdd", hashtable) == 1)
            {
                dataBase.Close();
                return "1";
            }
            else
            {
                dataBase.Close();
                return "0";
            }
        }

        [Route("Out/AllSelect")]
        [HttpGet]
        public ActionResult<ArrayList> OutAllSelect()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("sp_OutAllSelect");

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

        [Route("Out/ClientNameSelect")]
        [HttpPost]
        public ActionResult<ArrayList> OutClientNameSelect([FromForm]string cName)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@cName", cName);
            SqlDataReader sdr = dataBase.Reader("sp_OutClientNameSelect", hashtable);
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

        [Route("Out/OutSelectNum")]
        [HttpPost]
        public ActionResult<ArrayList> OutSelectNum([FromForm] int pNum)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@pNum", pNum);
            SqlDataReader sdr = dataBase.Reader("sp_OutSelectNum", hashtable);
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

        [Route("Out/OutCom")]
        [HttpPost]
        public ActionResult<string> OutCom([FromForm]string pNum)
        {
            hashtable = new Hashtable();
            hashtable.Add("@pNum", pNum);

            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_OutCom", hashtable) == 1)
            {
                dataBase.Close();
                return "1";
            }
            else
            {
                dataBase.Close();
                return "0";
            }
        }

    }
}
