﻿using System;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Xml;
using System.Runtime.InteropServices;

namespace TournamentApp
{
    public class FileHandler
    {
        static public void DownloadFileTxt(List<Match> matches, string path, string fileName)
        {
            try
            {
                string txtPath = Path.Combine(path, $"{fileName}.txt");
                using (StreamWriter sw =
                        File.CreateText(txtPath))
                {
                    if (matches == null) UIController.ErrorHandler("No matches !");
                    else
                    {
                        foreach (Match m in matches)
                        {
                            sw.WriteLine(m.id + " : " + m.team1.name + " : "
                                + m.team2.name + " - " + m.result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UIController.ErrorHandler(ex);
            }
        }

        static public void DownloadFileCsv(List<Match> matches, string path, string fileName)
        {
            try
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
            catch (Exception ex)
            {
                UIController.ErrorHandler(ex);
            }
        }

        static public void DownloadFileXml(List<Match> matches, string path, string fileName)
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = false;
                string pathXml = Path.Combine(path, $"{fileName}.xml");
                if (matches == null) UIController.ErrorHandler("No matches !");
                else
                {
                    using (XmlWriter w = XmlWriter.Create(pathXml, settings))
                    {
                        w.WriteStartDocument();
                        w.WriteStartElement("MatchesResults");
                        foreach (Match m in matches)
                        {
                            w.WriteStartElement("Match");
                            w.WriteElementString("first_team", m.team1.name);
                            w.WriteElementString("second_team", m.team2.name);
                            w.WriteElementString("result", m.result);

                            w.WriteStartElement("OtherInfo");
                            w.WriteStartElement("Stadion");
                            w.WriteValue(m.location); ;
                            w.WriteEndElement();

                            w.WriteStartElement("Date");
                            w.WriteValue(m.date.ToString());
                            w.WriteEndElement();
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
            catch (Exception ex)
            {
                UIController.ErrorHandler(ex);
            }
        }

        static public List<Match> ReadFileCsv(string path)
        {
            try
            {
                using(var streamReader = new StreamReader(path))
                {
                    using(var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Context.RegisterClassMap<MatchesInfoClass>();
                        var records = csvReader.GetRecords<Match>().ToList();
                        Console.WriteLine(records);
                        return records;
                    }
                }
            }
            catch (Exception ex)
            {
                UIController.ErrorHandler(ex);
                return null;
            }
        }

        static public void ReadFileXml(string path)
        {
            try
            {
                using XmlReader reader = XmlReader.Create(path);

                while (reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element && reader.Name == "Match")
                    {
                        reader.ReadToFollowing("first_team");
                        string team1 = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("second_team");
                        string team2 = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("result");
                        string result = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("OtherInfo");

                        reader.ReadToFollowing("Stadion");
                        string location = reader.ReadElementContentAsString();

                        reader.ReadToFollowing("Date");
                        DateOnly date = DateOnly.Parse(reader.ReadElementContentAsString());

                        Console.WriteLine("First team: " + team1 + "vs." + 
                            "Second team: " + team2 + "\n" + "Location: " 
                            + location + "\n" + "Date: " + date + "\n" + "Result: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                UIController.ErrorHandler(ex);
            }

        }

        static public void ReadFileTxt(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                UIController.ErrorHandler(ex);
            }
        }
    }
}
