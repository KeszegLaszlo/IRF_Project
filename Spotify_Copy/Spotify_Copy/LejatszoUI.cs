using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Copy
{
    class LejatszoUI: Button
    {
        public string text { get; set; }
        public LejatszoUI(string text)
        {
            Height = 70;
            Width = Height;
            BackColor = Color.DarkSlateGray;
            Font = new Font("Segoe MDL2 Assets", 12);
            Text = text;
        }

    }
}
