using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CrawlerHttp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };

            //Load trang web, nạp html vào document
            //HtmlAgilityPack.HtmlDocument document = htmlWeb.Load("http://www.webtretho.com/forum/f26/");

            ////Load các tag li trong tag ul
            //var threadItems = document.DocumentNode.SelectNodes("//ul[@id='threads']/li").ToList();

            //var items = new List<object>();
            //foreach (var item in threadItems)
            //{
            //    //Extract các giá trị từ các tag con của tag li
            //    var linkNode = item.SelectSingleNode(".//a[contains(@class,'title')]");
            //    var link = linkNode.Attributes["href"].Value;
            //    var text = linkNode.InnerText;
            //    var readCount = item.SelectSingleNode(".//div[@class='folTypPost']/ul/li/b").InnerText;

            //    items.Add(new { text, readCount, link });
            //}


            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(textBox1.Text);
            var _listObjs = new List<object>();
            //Load các tag li trong tag ul
            var threadItems = document.DocumentNode.QuerySelectorAll("div.search-productItem").ToList();

            foreach (var item in threadItems)
            {
                var link = item.QuerySelector("a").Attributes["href"].Value;
                var text = item.QuerySelector("a").InnerText;
                var price = item.QuerySelector(".product-price").InnerText;
                var area = item.QuerySelector(".product-area").InnerText;
                var dictrict = item.QuerySelector(".product-city-dist").InnerText;
                var content = item.QuerySelector(".p-main-text").InnerText;
                var date = item.QuerySelector(".uptime").InnerText;

                _listObjs.Add(new { link, text, price, area, dictrict, content, date });
            }

            dataGridView1.DataSource = _listObjs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };

            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(textBox1.Text);
            var _listObjs = new List<object>();
            //Load các tag li trong tag ul
            var threadItems = document.DocumentNode.QuerySelectorAll("a.ctAdListingItem").ToList();

            foreach (var item in threadItems)
            {
                var link = item.Attributes["href"].Value;
                var text = item.InnerText;
                var price = item.QuerySelector(".adPriceNormal").InnerText;
                var area = item.QuerySelector(".areaName").InnerText;
                var dictrict = item.QuerySelector(".areaName").InnerText;
                var content = item.QuerySelector(".ctAdListingTitle").InnerText;
                var date = item.QuerySelector(".uptime").InnerText;

                _listObjs.Add(new { link, text, price, area, dictrict, content, date });
            }

            dataGridView1.DataSource = _listObjs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument test = new XmlDocument();
            test.Load("file.xml");
            test.InnerXml = SetValues(test.InnerXml, new Dictionary<string, string>
            {
                {Constants.XmlParams.MEO_ID, "21212121"},
            });
            test.Save("test1.xml");
        }

        public string SetValues(string input, Dictionary<string,string> parameters)
        {
            foreach (var entry in parameters)
            {
                input = input.Replace(entry.Key, entry.Value);
            }
            IEnumerable<byte> vs = new List<byte>();
            vs.ToArray();
            return input;
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("D:\\dsdsqa\\vvv");
        }
    }
}
