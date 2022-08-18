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
	/// Rule for parsing <p></p> node
	/// </summary>
	public class PNodeParsingRule : BaseParsingRule
	{
		#region Constructors

		public PNodeParsingRule(Dictionary<string, object> modelValues)
		: base(modelValues)
		{
		}

		#endregion

		#region Static Methods

		public static PNodeParams GetAttributesData(XmlAttributeCollection attributes)
		{
			var style = XFontStyle.Regular;
			var fontSize = 14;
			var alignment = XParagraphAlignment.Left;

			if (attributes != null)
			{
				var fontStyleAttribute = attributes["fontStyle"];
				if (fontStyleAttribute != null)
				{
					Enum.TryParse(fontStyleAttribute.Value, true, out style);
				}
				var fontSizeAttribute = attributes["fontSize"];
				if (fontSizeAttribute != null)
				{
					fontSize = Convert.ToInt32(fontSizeAttribute.Value);
				}
				var alignmentAttribute = attributes["alignment"];
				if (alignmentAttribute != null)
				{
					Enum.TryParse(alignmentAttribute.Value, true, out alignment);
				}
			}
			return new PNodeParams
			{
				Alignment = alignment,
				Style = style,
				FontSize = fontSize
			};
		}

		#endregion

		#region Overrides

		public override string NodeName => "p";

		public override void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
		{
			var atrData = GetAttributesData(node.Attributes);
			pdfGenerator.AddTextBlock(GetTextForNode(node), atrData.FontSize, atrData.Style, atrData.Alignment);
		} 

		#endregion
	}
}