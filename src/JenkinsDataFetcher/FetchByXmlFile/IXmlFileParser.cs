using DataModel;
using System.Collections.Generic;
using System.Xml;

namespace JenkinsDataFetcher.FetchByFile
{
    interface IXmlFileParser
    {
        List<TestResult> ParseFile(XmlReader reader);
    }
}
