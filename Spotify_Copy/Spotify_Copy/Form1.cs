using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Copy
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CreateUiField();
            //LejatszoUI gomb = new LejatszoUI("\uEDB5");
            //panel1.Controls.Add(gomb);
        }

        private void CreateUiField()
        {
            string[] ikonok = new string[6];
            ikonok[0] = "\uEDB5";
            ikonok[1] = "\uEDB4";
            ikonok[2] = "\uEB51";
            ikonok[3] = "\uE892";
            ikonok[4] = "\uE893";
            ikonok[5] = "\uE8B1";

            int lineWidht = 5;
            int ikonIndex = 0;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    LejatszoUI sf = new LejatszoUI(ikonok[ikonIndex]);

                    sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 1))) * lineWidht;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 1))) * lineWidht;
                    panel1.Controls.Add(sf);
                    ikonIndex++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void LoadData()
        {

           
        }
    }
}
