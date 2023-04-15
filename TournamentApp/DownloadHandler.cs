using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Xml;

namespace TournamentApp
{
    public class DownloadHandler
    {
        static public void DownloadFileTxt(List<Match> matches, string path, string fileName)
        {
            string txtPath = Path.Combine(path, $"{fileName}.txt");
            using (StreamWriter sw =
                    File.CreateText(txtPath))
            {
                foreach (Match m in matches)
                {
                    sw.WriteLine(m.id + " : " + m.team1.name + " : "
                        + m.team2.name + " - " + m.result);
                }
            }
        }

        static public void DownloadFileCsv(List<Match> matches, string path, string fileName)
        {
            string csvPath = Path.Combine(path, $"{fileName}.csv");
            using (var streamWriter = new StreamWriter(csvPath)) 
            {
                using(var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.Context.RegisterClassMap<MatchesInfoClass>();
                    csvWriter.WriteRecords(matches);
                }
            }
        }

        static public void DownloadFileXml(List<Match> matches, string path, string fileName)
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            StreamWriter streamWriter = new StreamWriter($"{path}/{fileName}.xml");
            using (XmlWriter w = XmlWriter.Create(streamWriter, set))
            {

            }
        }
    }
}
