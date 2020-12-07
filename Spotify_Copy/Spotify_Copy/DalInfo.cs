using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Copy
{
    class DalInfo:Label
    {
        public string text { get; set; }
        //public byte meret { get; set; }
        public DalInfo(string text)
        {
            Height = 60;
            Width = 120;
            Font = new Font("Times New Roman", 10);
            
            Text = text;
           
        }


    }
}
