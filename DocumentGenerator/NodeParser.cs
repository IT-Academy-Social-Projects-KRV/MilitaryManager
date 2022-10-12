using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DocumentGenerator.Interfaces;
using DocumentGenerator.ParsingRules;
using Newtonsoft.Json;

namespace DocumentGenerator
{
    /// <summary>
    /// Contains logic for parsing document template
    /// </summary>
    public class NodeParser : INodeParser
    {
        #region Data Members

        private readonly List<INodeParsingRule> _nodeParsingRules;

        #endregion

        #region Constructors

        /// <summary>
        /// Create NodeParser
        /// </summary>
        /// <param name="jsonModel">Json data for document</param>
        public NodeParser(string jsonModel)
        {
            var modelValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonModel);
            _nodeParsingRules = new List<INodeParsingRule>
            {
                new TitleNodeParsingRule(modelValues),
                new PNodeParsingRule(modelValues),
                new RetNodeParsingRule(modelValues),
                new ListNodeParsingRule(modelValues)
            };
        }

        #endregion

        #region INodeParser Members

        public void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
        {
            var rule = _nodeParsingRules.FirstOrDefault(i => i.NodeName == node.Name);
            rule?.ParseNode(pdfGenerator, node);
        }

        #endregion
    }
}
