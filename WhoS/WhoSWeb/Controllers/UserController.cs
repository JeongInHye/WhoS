using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("User/Login")]
        [HttpPost]
        public ArrayList Login([FromForm] string id, [FromForm] string pw)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@id", id);
            hashtable.Add("@pw", pw);
            ArrayList result = new ArrayList();
            try
            {
                DataBase dataBase = new DataBase();
                string sql = "sp_WebLogin";
                result = dataBase.GetArrayList(sql, hashtable);
                dataBase.Close();
                return result;
            }
            catch
            {
                return new ArrayList();
            }
        }
    }
}