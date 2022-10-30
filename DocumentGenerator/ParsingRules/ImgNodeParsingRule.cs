using System;
using System.Collections.Generic;
using System.Xml;
using DocumentGenerator.DataObjects;
using DocumentGenerator.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;

namespace DocumentGenerator.ParsingRules
{
    /// <summary>
    /// Rule for parsing <img></img> node
    /// </summary>
    public class ImgNodeParsingRule : BaseParsingRule
    {
        #region Constructors

        public ImgNodeParsingRule(Dictionary<string, object> modelValues)
            : base(modelValues)
        {
        }

        #endregion

        #region Overrides

        public override string NodeName => "img";

        public override void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
        {
            var imgPath = node.Attributes["path"].Value;
            var width = Convert.ToDouble(node.Attributes["width"].Value);
            var height = Convert.ToDouble(node.Attributes["height"].Value);
            pdfGenerator.AddImage(imgPath, width, height);
        }

        #endregion
    }
}
