using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouchLess_Answer.Models
{
    //  The second  class ActivtyRegistrationReply, this class will
    //     be used to reply message to the client application as response.
    public class ActivtyRegistrationReply
    {
        String type;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        String outagentmacid;
        public String OUTAgentMACID
        {
            get { return outagentmacid; }
            set { outagentmacid = value; }
        }

        // String plateNumber;
        public class PlateNumber
        {
            String image;
            public String Image
            {
                get { return image; }
                set { image = value; }
            }

            String number;
            public String Number
            {
                get { return number; }
                set { number = value; }
            }

            int timeStamp;
            public int TimeStamp
            {
                get { return timeStamp; }
                set { timeStamp = value; }
            }
            String registrationStatus;
            public String RegistrationStatus
            {
                get { return registrationStatus; }
                set { registrationStatus = value; }
            }


        }
    }
}