using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        private Hashtable hashtable;
        private DataBase dataBase;

        [Route("Main/Select")]
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm]string date)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@date", date);
            SqlDataReader sdr = dataBase.Reader("sp_MainSelect", hashtable);
            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];

                arr[0] = sdr.GetValue(0).ToString();
                arr[1] = sdr.GetValue(1).ToString();
                arr[2] = sdr.GetValue(2).ToString();
                arr[3] = sdr.GetValue(3).ToString();
                arr[4] = sdr.GetValue(4).ToString();
                if (sdr.GetValue(5).ToString() == "N" && sdr.GetValue(6).ToString() == "N")
                {
                    arr[5] = "입고해야됨";
                }
                if (sdr.GetValue(5).ToString() == "Y" && sdr.GetValue(6).ToString() == "N")
                {
                    arr[5] = "출고해야됨";
                }
                list.Add(arr);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }

        [Route("Main/MainSelectNum")]
        [HttpPost]
        public ActionResult<ArrayList> Select([FromForm]string pNum, [FromForm]string cName)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();

            hashtable.Add("@pNum", pNum);
            hashtable.Add("@cName", cName);

            SqlDataReader sdr = dataBase.Reader("sp_MainSelectNum", hashtable);

            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];

                arr[0] = sdr.GetValue(0).ToString();
                arr[1] = sdr.GetValue(1).ToString();
                arr[2] = sdr.GetValue(2).ToString();
                arr[3] = sdr.GetValue(3).ToString();
                arr[4] = sdr.GetValue(4).ToString();
                if (sdr.GetValue(5).ToString() == "N" && sdr.GetValue(6).ToString() == "N")
                {
                    arr[5] = "입고해야됨";
                }
                if (sdr.GetValue(5).ToString() == "Y" && sdr.GetValue(6).ToString() == "N")
                {
                    arr[5] = "출고해야됨";
                }
                list.Add(arr);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }
    }
}
