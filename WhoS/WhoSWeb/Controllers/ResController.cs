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
    public class ResController : ControllerBase
    {
        private Hashtable hashtable;
        private DataBase dataBase;

        [Route("Res/Select")]
        [HttpPost]
        public ArrayList Select([FromForm]string cNo)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            string str = "", substring = "";

            hashtable.Add("@cNo", cNo);
            SqlDataReader sdr = dataBase.Reader("sp_WebProductSelect", hashtable);
            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                string[] arr = new string[sdr.FieldCount];
                hashtable = new Hashtable();

                hashtable.Add("pName", sdr.GetValue(0).ToString());
                hashtable.Add("pWeight", sdr.GetValue(1).ToString());

                str = sdr.GetValue(2).ToString();
                substring = str.Substring(0, 10);
                hashtable.Add("EnterDate", substring);

                str = sdr.GetValue(3).ToString();
                substring = str.Substring(0, 10);
                hashtable.Add("OutDate", substring);

                hashtable.Add("pNum", sdr.GetValue(4).ToString());

                if (sdr.GetValue(5).ToString()=="N" && sdr.GetValue(6).ToString() == "N")
                {
                    hashtable.Add("text", "입고 전");
                }
                else if (sdr.GetValue(5).ToString() == "Y" && sdr.GetValue(6).ToString() == "N")
                {
                    hashtable.Add("text", "출고 전");
                }
                else if (sdr.GetValue(5).ToString() == "Y" && sdr.GetValue(6).ToString() == "Y")
                {
                    hashtable.Add("text", "거래완료");
                }
                list.Add(hashtable);
            }
            dataBase.ReaderClose(sdr);
            dataBase.Close();
            return list;
        }

        [Route("Res/Insert")]
        [HttpPost]
        public string Insert([FromForm]string cNo, [FromForm] string pName, [FromForm] string pWeight, [FromForm] string EnterDate, [FromForm] string OutDate)
        {
            Console.WriteLine("{0}, {1}, {2}, {3},{4}", cNo, pName, pWeight, EnterDate, OutDate);

            hashtable = new Hashtable();
            hashtable.Add("@cNo", cNo);
            hashtable.Add("@pName", pName);
            hashtable.Add("@pWeight", pWeight);
            hashtable.Add("@EnterDate", EnterDate);
            hashtable.Add("@OutDate", OutDate);

            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_AddProduct", hashtable) == 1)
            {
                dataBase.Close();
                Console.WriteLine("성공");
                return "1";
            }
            else
            {
                dataBase.Close();
                Console.WriteLine("실패");
                return "0";
            }
        }
    }
}