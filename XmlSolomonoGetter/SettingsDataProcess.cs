using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlXPath;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Collections;

namespace XmlSolomonoGetter
{
    class SettingsDataProcess
    {
        private static String settingsFilePath = String.Concat(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "\\Settings.xml");

        public static SettingsData CreateSettingsData()
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    SettingsData settingsData = new SettingsData();

                    XPathDataReader xPathDataReader = XPathDataReader.newInstance(new FileInfo(settingsFilePath), new KeyValuePair<String, String>("", StaticData.XmlSchemaForSettings));
                    ArrayList xPathDataReaderResult = xPathDataReader.ReadData("/settings/mainForm/location/x/text()");
                    if (xPathDataReaderResult.Count > 0)
                    {
                        settingsData.MainFormX = Convert.ToInt32(xPathDataReaderResult[0]);
                    }
                    xPathDataReaderResult = xPathDataReader.ReadData("/settings/mainForm/location/y/text()");
                    if (xPathDataReaderResult.Count > 0)
                    {
                        settingsData.MainFormY = Convert.ToInt32(xPathDataReaderResult[0]);
                    }
                    xPathDataReaderResult = xPathDataReader.ReadData("/settings/fileDialog/urlListFile/initialDirectory/text()");
                    if (xPathDataReaderResult.Count > 0)
                    {
                        settingsData.UrlListFileFolder = Convert.ToString(xPathDataReaderResult[0]);
                    }
                    xPathDataReaderResult = xPathDataReader.ReadData("/settings/fileDialog/csvFile/initialDirectory/text()");
                    if (xPathDataReaderResult.Count > 0)
                    {
                        settingsData.CsvFileFolder = Convert.ToString(xPathDataReaderResult[0]);
                    }

                    return settingsData;
                }
                else
                {
                    return new SettingsData();
                }
            }
            catch
            {
                return new SettingsData();
            }
        }

        public static void SaveSettingsData(SettingsData settingsData)
        {
            try
            {
                XDocument xDocument = new XDocument(
                    new XElement("settings",
                        new XElement("mainForm",
                            new XElement("location",
                                new XElement("x", settingsData.MainFormX),
                                new XElement("y", settingsData.MainFormY)
                                )
                            ),
                        new XElement("fileDialog",
                            new XElement("urlListFile",
                                new XElement("initialDirectory", settingsData.UrlListFileFolder)
                                ),
                            new XElement("csvFile",
                                new XElement("initialDirectory", settingsData.CsvFileFolder)
                                )
                            )
                        )
                    );

                xDocument.Save(settingsFilePath);
            }
            catch
            { }
        }
    }
}
