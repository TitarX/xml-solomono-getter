using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlSolomonoGetter
{
    class StaticData
    {
        private static String xmlSolomonoUrlString = "http://xml.solomono.ru/?url=";
        private static String listSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
        private static String newLine = Environment.NewLine;
        private static String xmlSchemaForSettings =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<schema xmlns=\"http://www.w3.org/2001/XMLSchema\">" +
            "<element name=\"settings\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"mainForm\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"location\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"x\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "<element name=\"y\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "<element name=\"fileDialog\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"urlListFile\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"initialDirectory\" type=\"string\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "<element name=\"csvFile\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"initialDirectory\" type=\"string\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</schema>";


        public static String XmlSolomonoUrlString
        {
            get
            {
                return xmlSolomonoUrlString;
            }
        }

        public static String ListSeparator
        {
            get
            {
                return listSeparator;
            }
        }

        public static String NewLine
        {
            get
            {
                return newLine;
            }
        }

        public static String XmlSchemaForSettings
        {
            get
            {
                return xmlSchemaForSettings;
            }
        }
    }
}
