using JenkinsDataFetcher.FetchByFile;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using System.Xml;
using static DataModel.Enums;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    public class DefaultXmlParser : IXmlFileParser
    {
        public List<TestResult> ParseFile(XmlReader reader)
        {
            return reader.GetTestResults().ToList();
        }
    }

    internal static class DefaultHelper
    {
        /* 
        expected format : <Test name="ThisIsATest" result="KO" timeFailing="15">
        /!\ this might (will) change
       */
        public static IEnumerable<TestResult> GetTestResults(this XmlReader source)
        {
            while (source.Read())
            {
                if (source.NodeType == XmlNodeType.Element &&
                    source.Name == "Test")
                {
                    string name = source.GetAttribute("name");

                    Status status;
                    string result = source.GetAttribute("result");
                    if (StringReferences.StringToStatus.ContainsKey(result))
                    {
                        status = StringReferences.StringToStatus[result];
                    }
                    else
                    {
                        status = Status.ERROR;
                        // TODO : log error
                    }

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
