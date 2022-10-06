using System.Xml;

namespace DocumentGenerator.Interfaces
{
    /// <summary>
    /// Contracts for all class that can parse nodes for generating pdf document
    /// </summary>
    public interface INodeParser
    {
        /// <summary>
        /// Parse xml node and add data into document 
        /// </summary>
        /// <param name="pdfGenerator">Pdf generator object</param>
        /// <param name="node">Node for parsing</param>
        void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node);
    }
}
