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
            CreateUiFieldButton();
            CreateUiFieldLabel();
            LoadMusicData();
           // DalInfo adat = new DalInfo("Justin Bieber");
           // adat.meret = 12;
           // panel2.Controls.Add(adat);
        }

        private List<Dal> _sudokus = new List<Sudoku>();
        private void LoadMusicData()
        {
            throw new NotImplementedException();
        }

        private void CreateUiFieldLabel()
        {
            //A szerő és a dal címének a megjelenítése
            // ?? hogyan lehet változtatni a label tulajdonságait kódban, hiszen readonly +középre

            
            int lineWidht = 10;
            
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    
                    DalInfo sf = new DalInfo("Justin Bieber");

                    
                    sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 1))) * lineWidht;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 1))) * lineWidht;
                    panel2.Controls.Add(sf);
                    
                }
            }
        }

        private void CreateUiFieldButton()
        {
            string[] ikonok = new string[6];
            ikonok[0] = "\uEDB5";
            ikonok[1] = "\uEDB4";
            ikonok[2] = "\uEB51";
            ikonok[3] = "\uE892";
            ikonok[4] = "\uE893";
            ikonok[5] = "\uE724	";

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
