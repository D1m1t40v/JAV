using System.Collections.Generic;
using DataModel;
using System.Xml;
using static DataModel.Enums;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    internal class DefaultXmlParser : XmlFileParser
    {        
        /* 
        expected format : 
            <Test name="ThisIsATest" result="KO" timeFailing="15">
        */
        internal override IEnumerable<TestResult> GetTestResults(XmlReader source)
        {
            while (source.Read())
            {
                if (source.NodeType == XmlNodeType.Element &&
                    source.Name == "Test")
                {
                    string name = source.GetAttribute("name");

                    Status status = GetStatusFromString(source.GetAttribute("result"));

                    int timeFailing;
                    int.TryParse(source.GetAttribute("timeFailing"), out timeFailing);

                    yield return new TestResult
                    {
                        Name = name,
                        Status = status,
                        FailingTime = timeFailing
                    };
                }
            }
        }
    }    
}
