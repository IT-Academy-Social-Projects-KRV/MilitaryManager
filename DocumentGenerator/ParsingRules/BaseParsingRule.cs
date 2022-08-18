using System.Collections.Generic;
using System.Xml;
using DocumentGenerator.Interfaces;

namespace DocumentGenerator.ParsingRules
{
	/// <summary>
	/// Base rule for parsing xml nodes from document template
	/// </summary>
	public abstract class BaseParsingRule : INodeParsingRule
	{
		#region Data Members

		protected readonly Dictionary<string, object> ModelValues;

		#endregion

		#region Constructors

		protected BaseParsingRule(Dictionary<string, object> modelValues)
		{
			ModelValues = modelValues;
		}

		#endregion

		#region Methods

		protected string GetTextForNode(XmlNode node)
		{
			return GetTextForNode(node, ModelValues);
		}

		protected string GetTextForNode(XmlNode node, Dictionary<string, object> modelValues)
		{
			var result = node.InnerText;
			return GetDataForText(result, modelValues);
		}

		protected string GetDataForText(string text)
		{
			return GetDataForText(text, ModelValues);
		}

		protected string GetDataForText(string text, Dictionary<string, object> modelValues)
		{
			foreach (var modelKeyPair in modelValues)
			{
				var valueToReplace = "[" + modelKeyPair.Key + "]";
				text = text.Replace(valueToReplace, modelKeyPair.Value.ToString());
			}
			return text;
		}

		#endregion

		#region INodeParsingRule Members

		public abstract string NodeName { get; }

		public abstract void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node);

		#endregion
	}
}