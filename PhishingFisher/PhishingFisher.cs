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
        public string UserAPI = System.Configuration.ConfigurationManager.AppSettings.Get("UserAPI");
        public string PasswordAPI = System.Configuration.ConfigurationManager.AppSettings.Get("PasswordAPI");
        private es.codigoseguro.WebService1 wsp = new es.codigoseguro.WebService1();
        private es.codigoseguro.AuthHeader aoth = new es.codigoseguro.AuthHeader();
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
         * Boton para realizar pruebas
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
            wsp.insertAllSites(webURL, Danger, Cloned); 
        }
        public void insertVIPS(string id,string webURL,string HTML_BODY,string LAST_HTML_CHECK,string SSL_KEY,string SSL_EXPIRATION_DATE)
        {
            wsp.insertVIPS(id, webURL, HTML_BODY, LAST_HTML_CHECK, SSL_KEY, SSL_EXPIRATION_DATE);
        }

        public List<string> selectAllSites(string webURL)
        {
           List <string> datos = new List<string>(wsp.selectAllSites(webURL));
            return datos;
        }
       
        public List<CrawlerBait> selectAllNewSites()
        {
            wsp.AuthHeaderValue = aoth;
            List<CrawlerBait> datos = new List<CrawlerBait>();
            foreach (var item in wsp.selectAllNewSites())
            {
                CrawlerBait cB = new CrawlerBait();
                cB.WebURL = item.WebURL;
                cB.regID = item.regID;
                datos.Add(cB);
            }
            return datos;
        }

        public void updateAllSites(int similarity, int Danger, string Cloned,int ID)
        {

            wsp.updateAllSites(similarity, Danger, Cloned, ID);
        }
        /*
         * Esta parte irá en un Servicio de Windows, de momento se correra en este formulario
         *
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            aoth.Username = UserAPI;
            aoth.Password = PasswordAPI;
            wsp.AuthHeaderValue = aoth;
            serviceProcess();
            timer1.Enabled = true;
        }
        public void serviceProcess()
        {
          //  test();
            List<CrawlerBait> Baits = selectAllNewSites();
            foreach (var bait in Baits)
            {
                /*
                 * Esto será un metodo private pero de momento lo devuelvo como atributo
                 * Es una chapuza pero igual me hace falta de momento opara hacer poruebas.
                 */
                bait.readWebDate(bait.WebURL);
               // bait.analyzeURL(bait.WebURL);
                bait.readFiles();
                if(bait.similarity > 60){
                    //  updateAllSites(bait.similarity, 2, bait.cloned,bait.regID);
                    MessageBox.Show(bait.WebURL + " tiene un " +bait.similarity.ToString()+" de similitud");
                }
            }
        }

        
        public void test()
        {
           
        
        }
      
    }
    }

