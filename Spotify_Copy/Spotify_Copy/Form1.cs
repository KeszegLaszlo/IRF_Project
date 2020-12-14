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
        //Változók
        private int IdIndexer = 1;
        private List<Dal> dalok = new List<Dal>();
        private List<Dal> kedveltDalok = new List<Dal>();


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Temp\\ZeneAdatbazis.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();


            CreateUiFieldButton();
            CreateUiFieldLabel();
            ListaFeltoltes();

            // DalInfo adat = new DalInfo("Justin Bieber");
            // adat.meret = 12;
            // panel2.Controls.Add(adat);
        } //Konstruktor

        private void CSV(List<Dal> dal, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, false))
                {

                    for (int i = 0; i < dal.Count; i++)
                    {
                        file.WriteLine(dal[i].Eloado.ToString() + "," + dal[i].DalCime.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
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
                String sytnax = String.Format("SELECT DalCíme FROM Zene where DalID={0}", IdIndexer);
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
            String sytnax = String.Format("SELECT Eloado FROM Zene where DalID={0}", IdIndexer);
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
            panel2.BackColor = Color.Lavender;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 1; col++)
                {

                    DalInfo sf = new DalInfo(ZeneAdat[zeneIndex]);


                    sf.Left = col * +sf.Width + (int)(Math.Floor((double)(col / 1))) * lineWidht;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 1))) * lineWidht;

                    panel2.Controls.Add(sf);
                    zeneIndex++;
                }
            }
        }

        private void CreateUiFieldButton()
        {
            panel1.BackColor = Color.LightBlue;
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

                    if (ikonok[ikonIndex] == "\uEB51")
                    {
                        sf.MouseClick += Form1_MouseClick;
                        if (KedvencekKoze())
                        {
                            sf.BackColor = Color.Red;
                        }
                        else
                        {
                            sf.BackColor = Color.DarkSlateGray;
                        }
                    }
                    else if (ikonok[ikonIndex] == "\uE892")
                    {
                        sf.MouseClick += ElozoZene;
                    }
                    else if (ikonok[ikonIndex] == "\uE893")
                    {
                        sf.MouseClick += KovetkezoZene;
                    }
                    else if (ikonok[ikonIndex] == "\uE724	")
                    {
                        panel1.Width = sf.Right;
                        panel2.Width = sf.Right;

                        sf.MouseClick += ExportCSV;


                    }
                    ikonIndex++;
                }
            }


        }

        private void ExportCSV(object sender, MouseEventArgs e)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            IdIndexer = 1;
            CreateUiFieldButton();
            CreateUiFieldLabel();
            
            ListaFeltoltes();
            
            CSV(dalok, "Kedvelt_dalok.txt");

            MessageBox.Show("A kedvelt dalok sikeresen kimentve fájlba.");
        }

        private void KovetkezoZene(object sender, MouseEventArgs e)
        {
            if (IdIndexer<SorokSzama())
            {
                IdIndexer++;
                LoadMusicData();
                LoadEloado();
                panel2.Controls.Clear();
                //nem optimális, hogy mindig újraírjuk a panelt...
                panel1.Controls.Clear();
                CreateUiFieldButton();
                CreateUiFieldLabel();
                //IdIndexer++;
            }
            else
            {
                IdIndexer = 0;//Azért 0,hogy ne maradjon ki az első elem
                IdIndexer++;
                LoadMusicData();
                LoadEloado();
                panel2.Controls.Clear();
             
                panel1.Controls.Clear();
                CreateUiFieldButton();
                CreateUiFieldLabel();
               
            }

        }

        private void ElozoZene(object sender, MouseEventArgs e)
        {
            if (IdIndexer>1)
            {
                IdIndexer--;
                LoadMusicData();
                LoadEloado();
                panel2.Controls.Clear();
                panel1.Controls.Clear();

                CreateUiFieldButton();
                CreateUiFieldLabel();
            }
            else
            {
                IdIndexer = SorokSzama()+1;//Hogy ne maradjon ki az utolsó elem

                IdIndexer--;
                LoadMusicData();
                LoadEloado();
                panel2.Controls.Clear();
                panel1.Controls.Clear();

                CreateUiFieldButton();
                CreateUiFieldLabel();
            }
            

        }

        private void Kedvel()
        {
            bool teszt = !KedvencekKoze();
            con.Open();
            String sytnax = String.Format("UPDATE Zene SET Kedvelt = '{0}'  Where DalID={1}", teszt.ToString(), IdIndexer);
            cmd = new SqlCommand(sytnax, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        //Kedvel gomb eseménye
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


            Kedvel();
            panel1.Controls.Clear();
            CreateUiFieldButton();




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {


        }




        private void ListaFeltoltes()
        {
            try
            {
                dalok.Clear();
                int hatar = SorokSzama();
                IdIndexer = 1;
                for (int i = 0; i < hatar; i++)
                {
                    Dal dal = new Dal(IdIndexer, LoadEloado(), LoadMusicData(), KedvencekKoze());
                    dalok.Add(dal);

                    IdIndexer++;
                }
                int torlesHatar = dalok.Count; //Azért kell ,mert a másik for ciklusnál gondot okoz, ha menet közben törli ki

                for (int i = dalok.Count - 1; i >= 0; i--)
                {
                    if (dalok[i].Kedvelt == false)
                    {
                        dalok.RemoveAt(i);
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            



            //dalok.ForEach(i => Console.WriteLine(i));
            // kedveltDalok = dalok;

            /*
             foreach (Dal item in dalok)
             {
                 if (item.Kedvelt==false)
                 {
                     dalok.Remove(item);
                 }
                 else
                 {

                 }
             }
             KedveltListaFeltoltes();
             */
            IdIndexer = 1;

        }





    }
}
