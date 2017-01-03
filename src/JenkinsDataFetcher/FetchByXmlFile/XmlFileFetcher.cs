using System.Collections.Generic;
using DataModel;
using System.IO;
using System.Xml;
using System.Reflection;
using System;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    internal class XmlFileFetcher : IDataFetcher
    {
        private string _filePath;
        private XmlFileParser _xmlParser;

        internal XmlFileFetcher(string filePath, XmlFileParser xmlParser)
        {
            _filePath = filePath;
            _xmlParser = xmlParser;
        }

        public bool CanFetch()
        {
            File.Create(".\\TEST.XML");
            string toto = Environment.CurrentDirectory;
            return File.Exists(_filePath);
        }

        public List<TestResult> FetchResults()
        {
            using (XmlReader reader = XmlReader.Create(_filePath))
            {
                return _xmlParser.ParseFile(reader);
            }
        }
    }
}
