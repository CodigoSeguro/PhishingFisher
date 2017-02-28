using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Freezer.Core;

namespace PhishingFisher.ThreadsCrawler
{
   public class CrawlerBait
    {

        public string WebURL; // Direccón URL web 
        public string wasAGoodDay; // 0/1 
        public string XMLData; // Almacenamos codigo HTML
        public string cloned; //Resultado
        public int regID; // ID del registro
        public int similarity;
        public string SSL_KEY;
        public DateTime SSL_EXPIRATION_DATE;

        public string readWebDate(string wURL)
        {
            string sourceCode = "";
          //  try
           // {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                sourceCode = sr.ReadToEnd();
            try
            {

          /*
           * Genero el screenshot con la libreria Freezer
           * Para despues comparar
           */
            var screenshotJob = ScreenshotJobBuilder.Create(WebURL)
              .SetBrowserSize(800, 600)
              .SetCaptureZone(CaptureZone.FullPage)
              .SetTrigger(new WindowLoadTrigger());

            System.Drawing.Image screenshot = screenshotJob.Freeze();
            screenshot.Save("c:/imgWebPhishing/prueba.png", ImageFormat.Png);
            /*
             * Guardo los datos de certificado si los tiene
             */
            X509Certificate cert = request.ServicePoint.Certificate;
            X509Certificate2 cert2 = new X509Certificate2(cert);
            string cn = cert2.GetIssuerName();
            SSL_EXPIRATION_DATE = Convert.ToDateTime(cert2.GetExpirationDateString());
            SSL_KEY = cert2.GetPublicKeyString();
            }
            catch (Exception)
            {

              
            }


            sr.Close();
                response.Close();
                return sourceCode;
            //}
           // catch
           // { sourceCode = "ERROR"; }
          //  return sourceCode;
        }
        /* 
         * Saco las imagenes colgadas en la web
         */
        public void analyzeURL(string webURL){
            String htmlWEB = readWebDate(webURL);
            int i = 0;
            foreach (var splitHTML in htmlWEB.Split('='))
            {
              
                    if (validateImgString(splitHTML)) {

                        string[] splitLink = splitHTML.Split('\"');
                        foreach (var oneSpLink in splitLink)
                        {
                        if (validateImgString(oneSpLink))
                        {
                            i++;
                            string ext ="." + oneSpLink.Split('.')[oneSpLink.Split('.').Length-1];
                            if (oneSpLink.Contains("http://") || oneSpLink.Contains("https://"))
                            {
                                SaveImage(oneSpLink, "c:/imgs/" + i + ext, returnImgFormat(ext));

                            }
                            else
                            {
                                string[] arrRootURL = webURL.Split('/');
                                string rootURL = "";
                                int auxI = 0;
                                foreach (var splitRootURL in arrRootURL)
                                {
                                    if (auxI == arrRootURL.Length-1) { break; }

                                    rootURL = rootURL +splitRootURL +"/";
                                    auxI++;
                                    
                                }
                                SaveImage(rootURL+oneSpLink, "c:/imgWebPhishing/" + i + ext, returnImgFormat(ext));

                            }


                            //Console.Write();
                        }
                    }
                     
                    }
                }

            }
        //  String links = htmlWEB.Split('=')[1];

        private ImageFormat returnImgFormat(string imgExt) {
            string auxLower = imgExt.ToLower();
            switch (auxLower)
            {
               case ".ico":
                return ImageFormat.Icon;
                case ".png":
                    return ImageFormat.Png;
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Png;
                    break;
            }

        }
    public bool validateImgString(string imgURL) {
        string[] arrExtensions = new string[] { ".ico", ".png", ".svg", ".jpg", ".jpeg" };
        foreach (var oneExtension in arrExtensions)
        {
            if (imgURL.Contains(oneExtension))
            {
                return true;
            }

        }
        return false;
    }
      /*
       * Guardo las imagenes que previamente he analizado del codigo HTML
       */
        public void SaveImage(string imageURL,string filename, ImageFormat format)
        {
            try
            {

                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageURL);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                if (bitmap != null)
                    bitmap.Save(filename, format);

                stream.Flush();
                stream.Close();
                client.Dispose();
            }
            catch (Exception)
            {

            }
         
        }
        /*
         * Compruebo si los pixels de las imagenes se parecen
         */
        public double similarityImg(string fname1, string fname2)
        {
            // progressBar1.Visible = true;
            string img1_ref, img2_ref;
            Bitmap img1 = new Bitmap(fname1);
            Bitmap img2 = new Bitmap(fname2);
            double countPixDif = 0;
            double countPixSim = 0;
            bool flag = true;
            // progressBar1.Maximum = img1.Width;
            if (img1.Width == img2.Width && img1.Height == img2.Height)
            {
                for (int i = 0; i < img1.Width; i++)
                {
                    for (int j = 0; j < img1.Height; j++)
                    {
                        img1_ref = img1.GetPixel(i, j).ToString();
                        img2_ref = img2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            countPixDif++;
                            flag = false;
                            break;
                        }
                        countPixSim++;
                    }
                    // progressBar1.Value++;
                }
                //  if (flag == false)
                //   MessageBox.Show("Sorry, Images are not same , " + countPixSim + " wrong pixels found");
                //    else
                //    MessageBox.Show(" Images are same , " + countPixSim+ " same pixels found and " + countPixDif + " wrong pixels found");
            }
            else
                return 0;// no se pueden comparar

         //   this.Dispose();
            Double percentage;

            percentage = (countPixSim / (countPixSim + countPixDif)) * 100;
            return percentage;
        }
        public void readFiles()
        {
            foreach (var dir in Directory.GetDirectories("c:/imgs"))
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    foreach (var item in Directory.GetFiles("c:/imgWebPhishing"))
                    {
                        int cant = Convert.ToInt32(similarityImg(item, file));
                        if (cant > 60)
                        {
                            similarity = cant;
                            cloned = dir.ToString();
                        }
                    }
                }
            }
        }
        public void takeScreenshot(System.Windows.Forms.WebBrowser WBScreenShot)
        {
            //try
            //{

            //    Bitmap docImage = new Bitmap(600, 800);
            //    WBScreenShot.DrawToBitmap(docImage, new Rectangle(WBScreenShot.Location.X, WBScreenShot.Location.Y, WBScreenShot.Width, WBScreenShot.Height));
            //   // this.picDoc.Image = this.picDoc.getSizedImage(docImage);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }

        internal static async Task<string> obtainHTML(HttpResponseMessage respuesta, Uri URL)
        {
            string linea, contenido = "";
            HttpClient cliente = new HttpClient();
            linea = await respuesta.Content.ReadAsStringAsync();
            // linea = linea.Replace("<br>", Environment.NewLine);
            // contenido += linea;
            return contenido;
        }

    }
}
