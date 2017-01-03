using DataFetcherTest.Properties;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Linq;
using static JenkinsDataFetcher.DataFetcherFactory;
using static DataModel.Enums;

namespace DataFetcherTest.FetchByXmlTests
{
    [TestFixture]
    public class DefaultXmlParserTest
    {
        [Test]
        public void ParseFileTest()
        {
            var toto = Path.Combine(new FileInfo((Assembly.GetExecutingAssembly().Location)).Directory.FullName, Resources.DefaultXmlParserTestPath);
            var fetcher = GetDataFetcher(ParserType.DefaultXml, toto);
            Assert.IsNotNull(fetcher);

            Assert.IsTrue(fetcher.CanFetch());

            var testResults = fetcher.FetchResults();

            Assert.AreEqual(4, testResults.Count);
            Assert.AreEqual(4, testResults.Select(t => t.Name).Distinct().Count());
            Assert.AreEqual(2, testResults.Count(t => t.Status == Status.OK));
            Assert.AreEqual(1, testResults.Count(t => t.Status == Status.KO));
            Assert.AreEqual(1, testResults.Count(t => t.Status == Status.Ignored));

            Assert.AreEqual(15, testResults.First(t => t.Status == Status.KO).FailingTime);

        }
    }
}
