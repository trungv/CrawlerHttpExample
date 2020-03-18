using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CrawlerHttp
{
    class Helper
    {
        private void button2_Click(object sender, EventArgs e)
        {
            var x = new
            {
                One = 1,
                Two = 2,
                Three = 3
            };

            var y = new
            {
                Four = 4,
                Five = 5
            };

            //CopyValues<object>(y, x);

            var fields = new JObject();
            var value = new JObject { { "value", "NNNNNN" } };

            fields.Add("FORUN", value);

            var fields02 = new JObject();
            var value1 = new JObject { { "value", "NNNNNN02" } };
            var value2 = new JObject { { "value", "NNNNNN03" } };

            fields02.Add("FORUN02", value1);
            fields02.Add("FORUN03", value2);

            foreach (var item in fields02.AsJEnumerable())
            {
                fields.Add(item);
            }

        }

        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xcx = new Item();

            var x = xcx.Key;
            var xsSubmit = new XmlSerializer(typeof(Stack));
            //string x = "";
            var details = new Stack
            {
                Id = "ID091",
                ImageId = "Image_ECP_pdf",
                Age = 12,
                Name = "Vai liz",
                //Items = new Item[]
                //{
                //    new Item
                //    {
                //        Key = "Key01",
                //        Value = "Value01"
                //    },
                //    new Item
                //    {
                //        Key = "Key02",
                //        Value = "Value02"
                //    },
                //    new Item
                //    {
                //        Key = "Key03",
                //        Value = "Value03"
                //    }
                //}

            };

            using (XmlWriter writer = XmlWriter.Create(x, new XmlWriterSettings
            {

            }))
            {
                writer.WriteProcessingInstruction("xml", @"version='1.0' encoding='UTF-8' standalone='yes'");
                xsSubmit.Serialize(writer, details);
            }
        }
    }

    public class Stack
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string ImageId { get; set; }

        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public int Age { get; set; }
        [XmlArrayItem]
        public Item[] Items { get; set; }
    }

    public class Item
    {
        public Item()
        {
            Key = "dsadsa";
        }

        [XmlAttribute]
        public string Key { get; }

        [XmlAttribute]
        public string Value { get; set; }
    }
}
