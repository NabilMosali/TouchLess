using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TouchLess_Answer.Models;


namespace TouchLess_Answer.Controllers
{
    public class TouchLessController : ApiController
    {

        //List<Student> studentList;
        //static StudentRegistration stdregd = null;


        //  List<Activty> activtyList;


        // GET: api/TouchLess
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET: api/TouchLess/5
        // public string Get(int id)
        List<Activtys> GetAllActivtys()
        {
          //  return "value";
            return ActivtyRegistration.getInstance().getAllActives();
        }

        // POST: api/TouchLess
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TouchLess/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TouchLess/5
        public void Delete(int id)
        {
        }
    }
}
