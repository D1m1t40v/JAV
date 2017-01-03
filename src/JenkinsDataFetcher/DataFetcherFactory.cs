using JenkinsDataFetcher.FetchByXmlFile;

namespace JenkinsDataFetcher
{
    public static class DataFetcherFactory
    {
        public static IDataFetcher GetDataFetcher(ParserType parserType, string fileName)
        {
            switch (parserType)
            {
                case ParserType.DefaultXml:
                    return new XmlFileFetcher(fileName, new DefaultXmlParser());
                case ParserType.MultiLineXml:
                    return new XmlFileFetcher(fileName, new MultiLineXmlParser());
                default:
                    return null;
            }
        }

        public enum ParserType
        {
            DefaultXml,
            MultiLineXml
        }
    }


}
