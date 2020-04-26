using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerHttp
{
    class StoreHtmlSource
    {

        private void button5_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };
            var _listObjs = new List<string>();

            //HtmlAgilityPack.HtmlDocument listLageDocument;
            //for (int i = 1; i <= 140; i++)
            //{
            //    var urlListPage = $"?page={i}";
            //    listLageDocument = htmlWeb.Load(urlListPage);

            //    var listLage = listLageDocument.DocumentNode.QuerySelector("div.listLage");
            //    var pages = listLage.QuerySelectorAll("a").ToList();
            //    foreach (var item in pages)
            //    {
            //        var link = item.Attributes["href"].Value;
            //        _listObjs.Add(link);
            //    }

            //    using (TextWriter tw = new StreamWriter(@"D:\SavedList.txt"))
            //    {
            //        foreach (String s in _listObjs.Distinct())
            //            tw.WriteLine($"{s}");
            //    }
            //    System.Threading.Thread.Sleep(1000);

            //    label1.Text = i.ToString();
            //}






            //GET LIST LINK IMGAGE IN 1 PAGE
            //var urlFile = File.ReadAllLines(@"D:\SocialSpace\Batch09.txt");
            //var urlList = new List<string>(urlFile);
            //HtmlAgilityPack.HtmlDocument document;

            //int i = 0;
            //foreach (var urlString in urlList)
            //{
            //    document = htmlWeb.Load(urlString);

            //    //Load các tag li trong tag ul
            //    var detailContent = document.DocumentNode.QuerySelector("div.contentDeatil");
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

            //    using (TextWriter tw = new StreamWriter(@"D:\UrlListFile_09.txt"))
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

            var urlFile = File.ReadAllLines(@"D:\UrlListFile_09.txt");
            var urlList = new List<string>(urlFile);
            var urlQueue = new Queue<string>(urlList);

            while (urlQueue.Any())
            {
                try
                {
                    Parallel.Invoke(
                        () => DownloadImage(urlQueue.Dequeue()),
                        () => DownloadImage(urlQueue.Dequeue()),
                        () => DownloadImage(urlQueue.Dequeue()),
                        () => DownloadImage(urlQueue.Dequeue()),
                        () => DownloadImage(urlQueue.Dequeue())
                    );
                }
                catch (Exception)
                {
                    continue;
                }
            }
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
                    client.DownloadFile(new Uri(url), $"D:/SocialSpace/ImgDrive/{fileName}");
                    System.Threading.Thread.Sleep(300);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
