using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        private void button5_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };
            var _listObjs = new List<string>();

            HtmlAgilityPack.HtmlDocument listLageDocument;
            for (int i = 1; i <= 48; i++)
            {
                var urlListPage = $"https://donglao.com.vn/anh";
                listLageDocument = htmlWeb.Load(urlListPage);

                var listLage = listLageDocument.DocumentNode.QuerySelector("div.td-container");
                var pages = listLage.QuerySelectorAll("div.td-module-thumb").ToList();
                foreach (var item in pages)
                {
                    var link = item.Attributes["href"].Value;
                    _listObjs.Add(link);
                }

                using (TextWriter tw = new StreamWriter(@"D:\ListL.txt"))
                {
                    foreach (String s in _listObjs.Distinct())
                        tw.WriteLine($"{s}");
                }
                System.Threading.Thread.Sleep(1000);

                label1.Text = i.ToString();
            }






            //GET LIST LINK IMGAGE IN 1 PAGE
            //var urlFile = File.ReadAllLines(@"D:\ListLi.txt");
            //var urlList = new List<string>(urlFile);
            //HtmlAgilityPack.HtmlDocument document;

            //int i = 0;
            //foreach (var urlString in urlList)
            //{
            //    document = htmlWeb.Load(urlString);

            //    //Load các tag li trong tag ul
            //    var detailContent = document.DocumentNode.QuerySelector("article");
            //    if (detailContent == null)
            //    {
            //        continue;
            //    }

            //    var threadItems = detailContent.QuerySelectorAll("img").ToList();
            //    foreach (var item in threadItems)
            //    {
            //        var link = item.Attributes["src"].Value;
            //        _listObjs.Add(link);
            //    }

            //    using (TextWriter tw = new StreamWriter(@"D:\ListLink.txt"))
            //    {
            //        foreach (String s in _listObjs.Distinct())
            //            tw.WriteLine($"{s}");
            //    }
            //    System.Threading.Thread.Sleep(500);
            //    ++i;
            //    label1.Text = i.ToString();
            //}

            //DOWNLOAD IMAGE
            //var urlFile = File.ReadAllLines(@"D:\UrlListFile_05.txt");
            //var urlList = new List<string>(urlFile);
            //foreach (var urlString in urlList)
            //{
            //    try
            //    {
            //        DownloadImage(urlString);
            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }

            //}

            //var urlFile = File.ReadAllLines(@"D:\ListLin.txt");
            //var urlList = new List<string>(urlFile);
            //var urlQueue = new Queue<string>(urlList);

            //while (urlQueue.Any())
            //{
            //    try
            //    {
            //        Parallel.Invoke(
            //            () => DownloadImage(urlQueue.Dequeue()),
            //            () => DownloadImage(urlQueue.Dequeue()),
            //            () => DownloadImage(urlQueue.Dequeue()),
            //            () => DownloadImage(urlQueue.Dequeue()),
            //            () => DownloadImage(urlQueue.Dequeue())
            //        );
            //    }
            //    catch (Exception)
            //    {
            //        continue;
            //    }
            //}
        }

        public static void DownloadImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return;
            }

            var fileName = Path.GetFileName(url);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri(url), $"D:/SocialSpace/ImgDrive02/{fileName}");
                    System.Threading.Thread.Sleep(300);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var pathFolder = @"D:\SocialSpace\ImgDrive09";
            DirectoryInfo d = new DirectoryInfo(pathFolder);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                if (!f.FullName.Contains("."))
                {
                    File.Move(f.FullName, f.FullName.Insert(f.FullName.Count(), ".jpg"));
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false
            //};

            var smtp = new SmtpClient
            {
                Host = "smtp-relay.sendinblue.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var urlFile = File.ReadAllLines(@"D:\email2.txt");
            var emailList = new List<string>(urlFile);

            var listProcess = SplitList(emailList);
            var i = 0;
            foreach (var item in listProcess)
            {
                try
                {
                    EmailHelper.SendMailToMultiAddress(item, smtp);
                    Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    continue;
                }
                ++i;
            }          

            MessageBox.Show("DFone");
        }

        public static List<List<string>> SplitList(List<string> locations, int nSize = 10)
        {
            var list = new List<List<string>>();

            for (int i = 0; i < locations.Count; i += nSize)
            {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(@"https://donglao.com.vn");
        }
    }
}
