using PhishingFisher.ThreadsCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Freezer.Core;
using System.Drawing.Imaging;

namespace PhishingFisher
{
    public partial class PhishingFisher : Form
    {
        private string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";
        public PhishingFisher()
        {
            InitializeComponent();
        }

        private void btnFIsherman_Click(object sender, EventArgs e)
        {
            if (urlValidated(tbURL.Text))
            {
                readURL(tbURL.Text);
            }
        }

        /*
         * Leo el codigo HTML de la web para analizar, de momento es para hacer pruebas con URL's fijas
         */

        private void readURL(string URL)
        {
            CrawlerBait cB = new CrawlerBait();
            cB.analyzeURL(URL);

            string html_body = cB.readWebDate(URL);
            cB.readFiles();
            int cant = cB.similarity;
            insertAllSites(URL, 3, "");
            List<string> IDs = selectAllSites(URL);
            insertVIPS(IDs[0], URL, html_body, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), cB.SSL_KEY, cB.SSL_EXPIRATION_DATE.ToString("yyyy-MM-dd H:mm:ss"));


        }
        /*
         * Valido que sea una URL valida
         */
        private bool urlValidated(string URL)
        {
            string[] arrExtensions = new string[] { ".es", ".com", "http://", "https://" };
            foreach (var oneExten in arrExtensions)
            {
                if (URL.Contains(oneExten))
                {
                    return true;
                }
            }
            return false;

        }
        /*
         * 
         * 
         * 
         */
      
        private void btnCompareImg_Click(object sender, EventArgs e)
        {
            //var screenshotJob = ScreenshotJobBuilder.Create(tbURL.Text)
            //.SetBrowserSize(600, 300)
            //.SetCaptureZone(CaptureZone.VisibleScreen)
            //.SetTrigger(new WindowLoadTrigger());

            //System.Drawing.Image screenshot = screenshotJob.Freeze();
            //screenshot.Save("c:/imgs/Phishing.png", ImageFormat.Png);
            CrawlerBait cB = new CrawlerBait();
            cB.similarityImg("c:/imgs/Paypal.png", "c:/imgs/Phishing.png");
        }


        /********************************************************************************
         * Insercción de datos esto irá en un WebService, de momento lo dejaremos así para tener datos reales
         *********************************************************************************/
        public void insertAllSites(string webURL,int Danger,string Cloned)
        {
      //  string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";

            string sql = " insert into all_sites(URL,Danger,Cloned) values('"+webURL+"',"+Danger+",'"+Cloned+"')";
            // string sql = " insert into vip_sites("
            MySqlConnection cnx = new MySqlConnection(MyConnection2);
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            comm.ExecuteNonQuery();
   
            //System.Data.SqlClient.SqlDataReader rst = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
          
        }
        public void insertVIPS(string id,string webURL,string HTML_BODY,string LAST_HTML_CHECK,string SSL_KEY,string SSL_EXPIRATION_DATE)
        {
          //string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";

            string sql = " insert into vip_sites(ID,URL,HTML_BODY,LAST_HTML_CHECK,SSL_KEY,SSL_EXPIRATION_DATE) values("+id+",'" + webURL + "'," + "'<>'" + ",'" + LAST_HTML_CHECK + "','"+SSL_KEY+ "','"+SSL_EXPIRATION_DATE+ "')";
            // string sql = " insert into vip_sites("
                MySqlConnection conn = new MySqlConnection(MyConnection2);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            comm.ExecuteNonQuery();

            //System.Data.SqlClient.SqlDataReader rst = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);

        }

        public List<string> selectAllSites(string webURL)
        {
         //   string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";
            // string sql = "Select * From all_sites Where URL like '%"+webURL+"'%";
            string sql = "Select * from all_sites where URL like '%" + webURL + "%'";
            List<string> datos = new List<string>();
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
           
     

	
	        MySqlDataReader myreader = comm.ExecuteReader();
	 

	        if (myreader.Read())
	        {
		       
		        datos.Add(myreader["ID"].ToString());

	        }

            return datos;
        }
       
        public List<CrawlerBait> selectAllNewSites()
        {
        //    string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";
            // string sql = "Select * From all_sites Where URL like '%"+webURL+"'%";
            string sql = "Select * from all_sites where Danger = 3";
            List<CrawlerBait> Baits = new List<CrawlerBait>();
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;




            MySqlDataReader myreader = comm.ExecuteReader();


            while (myreader.Read())
            {
                CrawlerBait cb = new CrawlerBait(); ;
                cb.WebURL = myreader["URL"].ToString();
                cb.regID = Convert.ToInt32(myreader["ID"].ToString());
                Baits.Add(cb);

            }

            return Baits;
        }

        public void updateAllSites(int similarity, int Danger, string Cloned,int ID)
        {
            // string m_strConnectionString = "Persist Security Info=False;Initial Catalog=phishingFisher;Data Source=codigoseguro.com;User ID=desarrollo;Password=eLuv326!";
            //     string MyConnection2 = "datasource=codigoseguro.com;port=3306;username=desarrollo;password=eLuv326!;database=phishingFisher";

            string sql = "update all_sites set similarity =" + similarity;
                sql = sql + " , Danger =" + Danger + " , Cloned='" + Cloned;
            sql = sql + " where Id =" + ID;
            // string sql = " insert into vip_sites("
            MySqlConnection cnx = new MySqlConnection(MyConnection2);
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;
            comm.ExecuteNonQuery();

            //System.Data.SqlClient.SqlDataReader rst = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);

        }
        /*
         * Esta parte irá en un Servicio de Windows, de momento se correra en este formulario
         *
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            serviceProcess();


        }
        public void serviceProcess()
        {
          //  test();
            List<CrawlerBait> Baits = selectAllNewSites();
            foreach (var bait in Baits)
            {
                // Esto será un metodo private pero de momento lo devuelvo como atributo
                //Es una chapuza pero igual me hace falta de momento opara hacer poruebas.
                bait.readWebDate(bait.WebURL);
               // bait.analyzeURL(bait.WebURL);
                bait.readFiles();
                if(bait.similarity > 60){
                  //  updateAllSites(bait.similarity, 2, bait.cloned,bait.regID);

                }
            }
        }

        
        public void test()
        {
           
            es.codigoseguro.WebService1 wsp = new es.codigoseguro.WebService1();
            es.codigoseguro.AuthHeader aoth = new es.codigoseguro.AuthHeader();
          //  wsp.selectAllNewSites();
            aoth.Username = "hack232";
            aoth.Password = "hack232";
            wsp.AuthHeaderValue = aoth;
            wsp.selectAllNewSites();
        }
      
    }
    }

