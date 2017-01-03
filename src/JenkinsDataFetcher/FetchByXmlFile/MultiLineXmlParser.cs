using DataModel;
using System;
using System.Collections.Generic;
using System.Xml;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    internal class MultiLineXmlParser : XmlFileParser
    {
        /* 
        expected format : 
            <Test>
                <Name value="ThisIsATest" />
                <Result value="KO" /> 
                <TimeFailing value="15" />
            </Test>
        */
        internal override IEnumerable<TestResult> GetTestResults(XmlReader source)
        {
            while (source.Read())
            {
                if (source.NodeType == XmlNodeType.Element && source.Name == "Test")
                {
                    if (source.NodeType != XmlNodeType.Element)
                    {
                        throw new Exception("Xml file has an unexpected format");
                    }

                    var result = new TestResult();

                    switch (source.Name)
                    {
                        case "Name":
                            result.Name = source.GetAttribute("value");
                            break;
                        case "Result":
                            result.Status = this.GetStatusFromString(source.GetAttribute("value"));
                            break;
                        case "TimeFailing":
                            int timeFailing;
                            int.TryParse(source.GetAttribute("timeFailing"), out timeFailing);
                            result.FailingTime = timeFailing;
                            break;
                    }

                    if (source.NodeType == XmlNodeType.Element && source.Name == "Test" && result.IsValid())
                    {
                        yield return result;
                    }
                }
            }
        }
    }
}
