using System.Collections.Generic;
using static DataModel.Enums;

namespace JenkinsDataFetcher.FetchByXmlFile
{
    internal static class StringReferences
    {
        /// <summary>
        /// This is for performance issues, parsing to an enum is too slow
        /// </summary>
        internal static Dictionary<string, Status> StringToStatus = new Dictionary<string, Status>
        {
            {"OK", Status.OK },
            {"KO", Status.KO },
            {"Ignored", Status.Ignored }
        };
    }
}
