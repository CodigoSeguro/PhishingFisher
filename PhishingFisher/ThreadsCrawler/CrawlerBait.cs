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

namespace PhishingFisher.ThreadsCrawler
{
    class CrawlerBait
    {

        public string WebURL; // Direccón URL web 
        public string wasAGoodDay; // 0/1 
        public string XMLData; // Almacenamos codigo HTML
        public string msgResult; //Resultado
        public string regID; // ID del registro


        public string readWebDate(string wURL)
        {
            string sourceCode = "";
          //  try
           // {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(wURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                sourceCode = sr.ReadToEnd();
                sr.Close();
                response.Close();
                return sourceCode;
            //}
           // catch
           // { sourceCode = "ERROR"; }
          //  return sourceCode;
        }
        // string linea, contenido = "";
        // HttpClient cliente = new HttpClient();
        // linea = await respuesta.Content.ReadAsStringAsync();

        //  return linea;


        // HttpWebRequest wRequest = WebRequest.Create(wURL) as HttpWebRequest;
        // // para que lo devuelva como si accediéramos con un Smartphone
        //// wRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 4.01; Windows CE; Smartphone; 176x220)";

        // // Obtener la respuesta y abrir el stream de la respuesta recibida.
        // StreamReader reader = new StreamReader(wRequest.GetResponse().GetResponseStream());

        // string res = reader.ReadToEnd();
        // reader.Close();
        // return res;
        // Mostrarlo.
        // Console.WriteLine(res);

        // Cerrar el stream abierto.
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

                            SaveImage(oneSpLink, "c:/imgs/"+i + ext, returnImgFormat(ext));
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
      
        public void SaveImage(string imageURL,string filename, ImageFormat format)
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
