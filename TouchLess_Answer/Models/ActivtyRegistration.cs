using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouchLess_Answer.Models
{
    //This class Activity Registration, this is a singleton class, and it will hold 
    //the list of registered Activities including all the operations for GET, POST and PUT requests.
    public class ActivtyRegistration
    {

        List<Activtys> activetList;
        static ActivtyRegistration act = null;
        private ActivtyRegistration()
        {
            activetList = new List<Activtys>();
        }
        public static ActivtyRegistration getInstance()
        {
            if (act == null)
            {
                act = new ActivtyRegistration();
                return act;
            }
            else
            {
                return act;
            }
        }
        public void Add(Activtys active)
        {
            activetList.Add(active);
        }

        public List<Activtys> getAllActives()
        {
            return activetList;
        }
        public String UpdateActive(Activtys acti)
        {
            for (int i = 0; i < activetList.Count; i++)
            {
                Activtys actit = activetList.ElementAt(i);
                if (actit.OUTAgentMACID.Equals(acti.OUTAgentMACID))
                {
                    activetList[i] = actit;//update the new record
                    return "Update successful";
                }
            }
            return "Update un-successful";
        }

    }
}