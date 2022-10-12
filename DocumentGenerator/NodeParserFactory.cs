using DocumentGenerator.Interfaces;

namespace DocumentGenerator
{
    /// <summary>
    /// Factory for creating node parser
    /// </summary>
    public class NodeParserFactory : INodeParserFactory
    {
        #region INodeParserFactory Members

        public INodeParser CreateNodeParser(string jsonDataModel)
        {
            return new NodeParser(jsonDataModel);
        }

        #endregion
    }
}
