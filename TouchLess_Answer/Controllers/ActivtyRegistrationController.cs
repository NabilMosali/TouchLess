using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TouchLess_Answer.Models;


namespace TouchLess_Answer.Controllers
{
    public class ActivtyRegistrationController : ApiController
    {
        public ActivtyRegistrationReply registerAtivty(Activtys regd)
        {
            Console.WriteLine("In registerActivty");
            ActivtyRegistrationReply regreply = new ActivtyRegistrationReply();
            ActivtyRegistration.getInstance().Add(regd);
            regreply.Type = regd.Type;
            regreply.OUTAgentMACID = regd.OUTAgentMACID;
         //   Activtys aa=new Activtys()

            //regreply.RegistrationStatus = "Successful";

            return regreply;
        }



    }
}
