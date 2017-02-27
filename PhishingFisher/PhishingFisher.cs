using PhishingFisher.ThreadsCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhishingFisher
{
    public partial class PhishingFisher : Form
    {
        public PhishingFisher()
        {
            InitializeComponent();
        }

        private void btnFIsherman_Click(object sender, EventArgs e)
        {
            if (urlValidated(tbURL.Text)) {
                readURL(tbURL.Text);
            }
        }

        /*
         * Leo el codigo HTML de la web para analizar, de momento es para hacer pruebas con URL's fijas
         */
         
        private void readURL(string URL){
            CrawlerBait cB = new CrawlerBait();
            cB.analyzeURL(URL);
            rtbTests.Text = cB.readWebDate(URL);
         
               

        }
        /*
         * Valido que sea una URL valida
         */ 
        private bool urlValidated(string URL){
            string[] arrExtensions = new string[] { ".es", ".com","http://","https://"};
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

    }
}
