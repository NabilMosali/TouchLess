using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouchLess_Answer.Models
{
    public class Activtys
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
        
        public PlateNumber PlateNumber { get; set; }
        
        // String plateNumber;
        public partial class PlateNumber
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
        }



       
    }
   
}