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
    public class ResController : ControllerBase
    {
        [Route("Res/Select")]
        [HttpPost]
        public ArrayList Select()
        {
            ArrayList resultList = new ArrayList();

            Hashtable ht = new Hashtable();
            ht.Add("no", 1);
            ht.Add("name", "인혜");
            ht.Add("title", "연습1");
            ht.Add("regDate", "2019-03-12");
            resultList.Add(ht);

            ht = new Hashtable();
            ht.Add("no", 2);
            ht.Add("name", "인혜");
            ht.Add("title", "연습2");
            ht.Add("regDate", "2019-03-12");
            resultList.Add(ht);

            return resultList;
        }

        [Route("Res/Insert")]
        [HttpPost]
        public string Insert([FromForm] string name, [FromForm] string t, [FromForm] string enter, [FromForm] string outer, [FromForm] string email)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", name, t, enter, outer, email);
            return "1";
        }

    }
}