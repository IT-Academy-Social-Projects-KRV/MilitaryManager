using System;
using System.Collections.Generic;
using System.Xml;
using DocumentGenerator.Interfaces;

namespace DocumentGenerator.ParsingRules
{
    /// <summary>
    /// Rule for parsing <ret></ret> node
    /// </summary>
    public class RetNodeParsingRule : BaseParsingRule
    {
        #region Constructors

        public RetNodeParsingRule(Dictionary<string, object> modelValues)
            : base(modelValues)
        {
        }

        #endregion

        #region Overrides

        public override string NodeName => "ret";

        public override void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
        {
            pdfGenerator.AddRetreat(Convert.ToDouble(node.InnerText));
        }

        #endregion
    }
}
