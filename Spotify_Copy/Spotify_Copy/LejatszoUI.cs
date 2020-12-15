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
            MouseDown += LejatszoUI_MouseDown;
            MouseClick += LejatszoUI_MouseClick;
            Text = text;
        }

        private void LejatszoUI_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Text == "\uEDB5")
            {
                Form1 fr = new Form1();
                

            }
        }

        public void LejatszoUI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&& Text == "\uEB51")
            {
                BackColor = Color.DarkSlateGray;
            }
            else if (e.Button == MouseButtons.Right && Text == "\uEB51")
            {
                BackColor = Color.Red;

            }
        }
    }
}
