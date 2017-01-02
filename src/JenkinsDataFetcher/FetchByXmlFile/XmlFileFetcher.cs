using System.Collections.Generic;
using DataModel;
using System.IO;
using System.Xml;

namespace JenkinsDataFetcher.FetchByFile
{
    public class XmlFileFetcher : IDataFetcher
    {
        private string _filePath;
        private IXmlFileParser _xmlParser;

        public XmlFileFetcher(string filePath)
        {
            _filePath = filePath;
        }

        public bool CanFetch()
        {
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
