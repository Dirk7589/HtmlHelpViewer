using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace searchUpdater
{
    class Program
    {
        const string searchDataBasePath = "configuration\\tipuesearch_content.js";
        const string tipueTemplateStart = "var tipuesearch = {\"pages\": [";
        const string tipueTemplateEnd = "]};"; 
        static void Main(string[] args)
        {
            
            using (StreamWriter sw = new StreamWriter(searchDataBasePath))
            {
                sw.WriteLine(tipueTemplateStart);
                DirectoryInfo dirInfo = new DirectoryInfo("content");
                var files = dirInfo.EnumerateFiles("*.html");
                for (int i = 0; i < files.Count() - 1; i++)
                {
                    buildJSONEntry(files.ElementAt(i), sw);
                    sw.Write(",");
                }
                buildJSONEntry(files.Last(), sw);


                sw.WriteLine(tipueTemplateEnd);
            }
        }

        static void buildJSONEntry(FileInfo file, StreamWriter sw)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load(file.FullName);
            string jsonItem = "{";
            string title = "";
            string text = "";
            string tag = "";
            
            sw.Write(jsonItem);
            sw.Write("\"title\": \"");
            if (document.DocumentNode.SelectSingleNode("//title") != null)
            {
                var htmlTitle = document.DocumentNode.SelectSingleNode("//title").InnerText.Replace(System.Environment.NewLine, " ");
                title += (htmlTitle + "\"");
            }
            else
            {
                title += (file.Name + "\"");
            }
            sw.Write(title);
            sw.Write(",");
            sw.Write("\"text\": \"");

            string htmlString = "";
            HtmlNodeCollection nodes;
            nodes = document.DocumentNode.SelectNodes("//*[@class='searchAble']");
            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    htmlString += (" " +item.InnerText);
                }
                var uniqueWords = UniqueWordReader.findUniqueWords(htmlString);
                htmlString = "";
                foreach (var word in uniqueWords)
                {
                    htmlString += (" " + word);
                }
                text += (htmlString + "\"");
            }
            else
            {
                text += "\"";
            }
            sw.Write(text);
            sw.Write(",");
            sw.Write("\"tags\": \"");
            if (document.DocumentNode.SelectSingleNode("//keywords") != null)
            {
                var keywords = document.DocumentNode.SelectSingleNode("//keywords").InnerText.Replace(System.Environment.NewLine, " ");
                tag += keywords;
            }
            tag += "\"";
            sw.Write(tag);
            sw.Write(",");

            string link = file.FullName.Replace(Directory.GetCurrentDirectory() + "\\", "").Replace("\\", "/");
            string location = "\"loc\": \"";
            location += link + "\"";
            sw.Write(location);

            sw.Write("}");
        }
    }
}
