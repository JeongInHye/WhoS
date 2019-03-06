using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhoSWebAPI.Controllers
{
    [ApiController]
    public class ClientController : Controller
    {
        private Hashtable hashtable;
        private DataBase dataBase;

        [Route("Client/Select")]
        [HttpGet]
        public ActionResult<ArrayList> Select()
        {
            dataBase = new DataBase();
            SqlDataReader sdr = dataBase.Reader("sp_ClientSelect");

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

        [Route("Client/Add")]
        [HttpPost]
        public ActionResult<string> Add([FromForm]string Name, [FromForm]string pName, [FromForm]string Call, [FromForm]string Address, [FromForm]string ID, [FromForm]string Password)
        {
            hashtable = new Hashtable();
            hashtable.Add("@cName", Name);
            hashtable.Add("@cPName", pName);
            hashtable.Add("@cCall", Call);
            hashtable.Add("@cAddress", Address);
            hashtable.Add("@cID", ID);
            hashtable.Add("@cPassword", Password);


            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_ClientAdd", hashtable) == 1)
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
