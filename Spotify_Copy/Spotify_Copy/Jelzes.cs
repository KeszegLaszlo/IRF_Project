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
    public partial class Jelzes : Form
    {
        public Jelzes()
        {
            InitializeComponent();
           
            
        }

        private void Jelzes_Load(object sender, EventArgs e)
        {

        }
        public async void WaitSomeTime(Form item)
        {
            await Task.Delay(500);
            item.Close();
        }
    }
}
