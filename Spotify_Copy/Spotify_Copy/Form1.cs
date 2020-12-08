using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//local adatbázis beolvasása miatt

namespace Spotify_Copy
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            
            CreateUiFieldButton();
            CreateUiFieldLabel();
            ListaFeltoltes();

           // DalInfo adat = new DalInfo("Justin Bieber");
           // adat.meret = 12;
           // panel2.Controls.Add(adat);
        }
        private int IdIndexer = 2;

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\ZeneAdatbazis.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        

        private bool KedvencekKoze()
        {
            /*con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format("insert into KedveltDal (DalFK) values ({0})", IdIndexer);
            cmd.ExecuteNonQuery();
            con.Close();
            */
            con.Open();
            String sytnax = String.Format("SELECT Kedvelt FROM Zene where DalID={0}", IdIndexer);
            cmd = new SqlCommand(sytnax, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            bool temp = (bool)dr[0];
            con.Close();

            return temp;


        }
        private int SorokSzama()
        {

            //Az adatbázisból való beolvasás
            con.Open();
            String sytnax = String.Format("SELECT COUNT(*) FROM Zene");
            cmd = new SqlCommand(sytnax, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            int temp = (int)dr[0];
            con.Close();

            return temp;

        }
        private String LoadMusicData()
        {
           
            //Az adatbázisból való beolvasás
            con.Open();
            String sytnax = String.Format("SELECT DalCíme FROM Zene where DalID={0}",IdIndexer);
            cmd = new SqlCommand(sytnax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            
            String temp = dr[0].ToString();
            con.Close();
          
            return temp;

        }
        private String LoadEloado()
        {
            //Az adatbázisból az előadók való beolvasás
            con.Open();
            String sytnax = String.Format("SELECT Eloadó FROM Zene where DalID={0}",IdIndexer);
            cmd = new SqlCommand(sytnax, con);
            dr = cmd.ExecuteReader();
            dr.Read();

            String temp = dr[0].ToString();
            con.Close();
            return temp;
        }

        private void CreateUiFieldLabel()
        {
            //Itt töltuk fel a tömböt az adatbázisból kiynert adatokkal
            String[] ZeneAdat = new string[2];
            ZeneAdat[0] = LoadEloado();
            ZeneAdat[1] = LoadMusicData();
            byte zeneIndex = 0;
            
            //A szerő és a dal címének a megjelenítése
            // ?? hogyan lehet változtatni a label tulajdonságait kódban, hiszen readonly +középre


            int lineWidht = 10;
           
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    
                    DalInfo sf = new DalInfo(ZeneAdat[zeneIndex]);

                    
                    sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 1))) * lineWidht;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 1))) * lineWidht;
                  
                    panel2.Controls.Add(sf);
                    zeneIndex++;
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

        private void button1_Click(object sender, EventArgs e)
        {
            IdIndexer++;
            LoadMusicData();
            LoadEloado();
            panel2.Controls.Clear();
            CreateUiFieldLabel();
            

        }

        private List<Dal> dalok = new List<Dal>();
        private List<Dal> kedveltDalok = new List<Dal>();

        private void ListaFeltoltes()
        {
            int hatar = SorokSzama();
            for (int i = 0; i < hatar; i++)
            {
                Dal dal = new Dal(IdIndexer, LoadEloado(),LoadMusicData(),KedvencekKoze());
                dalok.Add(dal);
                IdIndexer++;
                
            }
            int torlesHatar = dalok.Count; //Azért kell ,mert a másik for ciklusnál gondot okoz, ha menet közben törli ki

            // kedveltDalok = dalok;
            foreach (Dal item in dalok)
            {
                if (item.Kedvelt==false)
                {
                    //mivel hibát ad ki, ha töröljük a REMOVE paranccsal
                }
                else
                {
                    kedveltDalok.Add(item);
                }
            }


        }

        
        private void button2_Click(object sender, EventArgs e)
        {

           
            

            for (int i = 0; i < kedveltDalok.Count; i++)
            {
                Console.WriteLine(kedveltDalok[i].Eloado + " ");
                
            }
            Console.ReadLine();
        }
    }
}
