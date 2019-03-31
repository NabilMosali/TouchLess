using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TouchLess_Answer.Models;

namespace TouchLess_Answer.Controllers
{
    public class ActivtyRetriveControllerController : ApiController
    {

        //GET api/activtyretrive
      
            public List<Activtys> GetAllActivtys()
            {
                 return ActivtyRegistration.getInstance().getAllActives();
            }
        


    }
}
