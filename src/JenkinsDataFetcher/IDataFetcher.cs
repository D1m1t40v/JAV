using System.Collections.Generic;
using DataModel;

namespace JenkinsDataFetcher
{
    public interface IDataFetcher
    {
        bool CanFetch();
        List<TestResult> FetchResults();
    }
}
