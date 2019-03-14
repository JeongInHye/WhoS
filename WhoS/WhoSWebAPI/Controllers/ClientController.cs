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


        [Route("Client/Delete")]
        [HttpPost]
        public ActionResult<string> Delete([FromForm]int cNo)
        {
            hashtable = new Hashtable();
            hashtable.Add("@cNo", cNo);

            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_ClientDelete", hashtable) == 1)
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

        [Route("Client/ClientEdeitSelect")]
        [HttpPost]
        public ActionResult<ArrayList> ClientEdeitSelect([FromForm] int cNo)
        {
            dataBase = new DataBase();
            hashtable = new Hashtable();
            hashtable.Add("@cNo", cNo);
            SqlDataReader sdr = dataBase.Reader("sp_ClientEditSelect", hashtable);
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

        [Route("Client/Edit")]
        [HttpPost]
        public ActionResult<string> Edit([FromForm]int cNo, [FromForm]string cName, [FromForm]string cPName, [FromForm]string cCall, [FromForm]string cAddress, [FromForm]string cID, [FromForm]string cPassword)
        {
            hashtable = new Hashtable();
            hashtable.Add("@cNo", cNo);
            hashtable.Add("@cName", cName);
            hashtable.Add("@cPName", cPName);
            hashtable.Add("@cCall", cCall);
            hashtable.Add("@cAddress", cAddress);
            hashtable.Add("@cID", cID);
            hashtable.Add("@cPassword", cPassword);

            dataBase = new DataBase();
            if (dataBase.NonQuery("sp_ClientEdit", hashtable) == 1)
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
