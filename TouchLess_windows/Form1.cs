using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchLess_windows;

namespace TouchLess_windows
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
          
            
            // serialize JSON to a string and then write string to a file


            //            // serialize JSON to a string and then write string to a file
           // File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(cn));

            //// serialize JSON directly to a file
            //using (StreamWriter file = File.CreateText(@"c:\movie.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //        serializer.Serialize(file, movie);
            //}
        }
    }
}
