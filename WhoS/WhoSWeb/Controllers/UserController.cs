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
        public Hashtable Login([FromForm] String id, [FromForm] String password)
        {
            Hashtable resultMap = new Hashtable();

            if ("root" == id)
            {
                if ("1234" == password)
                {
                    resultMap.Add("state", 1);
                }
                else if ("5678" == password)
                {
                    resultMap.Add("state", 2);
                }
                else
                {
                    resultMap.Add("state", 0);
                }
            }
            else
            {
                resultMap.Add("state", 0);
            }

            return resultMap;
        }
    }
}