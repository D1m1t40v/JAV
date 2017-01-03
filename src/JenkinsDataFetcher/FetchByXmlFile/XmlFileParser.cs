using DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static DataModel.Enums;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    internal abstract class XmlFileParser
    {
        internal List<TestResult> ParseFile(XmlReader reader)
        {
            return GetTestResults(reader).ToList();
        }

        internal abstract IEnumerable<TestResult> GetTestResults(XmlReader source);

        protected Status GetStatusFromString(string statusAsString)
        {
            if (StringReferences.StringToStatus.ContainsKey(statusAsString))
            {
                return StringReferences.StringToStatus[statusAsString];
            }
            else
            {
                return Status.ERROR;
                // TODO : log error
            }
        }
    }
}
