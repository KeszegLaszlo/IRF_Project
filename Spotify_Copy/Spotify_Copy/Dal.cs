using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Copy
{
    
    class Dal
    {
        public int ID { get; set; }

        public string Eloado { get; set; }

        public string DalCime { get; set; }

        public bool Kedvelt { get; set; }

        public Dal(int ID,string Eloado,string DalCime,bool Kedvelt)
        {
            this.ID = ID;
            this.Eloado = Eloado;
            this.DalCime = DalCime;
            this.Kedvelt = Kedvelt;
        }
    }
}
