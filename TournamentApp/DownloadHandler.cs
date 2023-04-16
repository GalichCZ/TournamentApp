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
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            string pathXml = Path.Combine(path, $"{fileName}.xml");
            using (XmlWriter w = XmlWriter.Create(pathXml, settings))
            {
                w.WriteStartDocument();
                    w.WriteStartElement("MatchesResults");
                        foreach (Match m in matches)
                        {
                            w.WriteAttributeString("first_team", m.team1.name);
                            w.WriteAttributeString("second_team", m.team2.name);
                            w.WriteAttributeString("result", m.result);

                            w.WriteStartElement("OtherInfo");
                                w.WriteStartElement("Stadion");
                                    w.WriteValue(m.location);;
                                w.WriteEndElement();

                                w.WriteStartElement("Date");
                                    w.WriteValue(m.date.ToString());
                                w.WriteEndElement();
                            w.WriteEndElement();
                        }
                    w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();
                w.Close();
            }
        }
    }
}
