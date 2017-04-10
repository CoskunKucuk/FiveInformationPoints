using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetWikiData
{
    public class WikiData
    {
        private readonly string _companyName;
        public WikiData(string CompanyName) { _companyName = CompanyName; }

        public string Title { get; set; }
        public string Description { get; set; }

        public void GetWikiData()
        {
            try
            {
                Uri url = new Uri("https://wikipedia.org/wiki/" + _companyName);

                WebClient client = new WebClient();
                string html = client.DownloadString(url);
                HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
                dokuman.LoadHtml(html);

                HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//title");
                HtmlNodeCollection description = dokuman.DocumentNode.SelectNodes("//div[@id='mw-content-text']/p");

                foreach (var baslik in basliklar)
                {
                    if (baslik.LastChild == null) { break; }
                    else { Title = baslik.FirstChild.InnerText.Trim(); }
                }
                foreach (var baslik in description)
                {
                    if (baslik.LastChild == null) { break; }
                    else { Description += baslik.InnerText; }
                }
            }
            catch (Exception ex) {
                /* veri bulamadığı durum*/
                Description = "";
                Title = "";
            }
        }
    }
}

///<summary>Kullanış</summary>
/*
            WikiData asd = new WikiData("Toyota");
            asd.GetWikiData();
           
            Console.WriteLine(asd.Title);
            Console.WriteLine(asd.Description);

            Console.ReadLine();
*/
