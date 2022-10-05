using System.Collections.Generic;
using System.Xml;
using DocumentGenerator.Interfaces;

namespace DocumentGenerator.ParsingRules
{
    /// <summary>
    /// Rule for parsing <titile></titile> node
    /// </summary>
    public class TitleNodeParsingRule : BaseParsingRule
    {
        #region Constructors

        public TitleNodeParsingRule(Dictionary<string, object> modelValues)
            : base(modelValues)
        {
        }

        #endregion

        #region Overrides

        public override string NodeName => "title";

        public override void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
        {
            pdfGenerator.AddTitle(GetTextForNode(node));
        }

        #endregion
    }
}
