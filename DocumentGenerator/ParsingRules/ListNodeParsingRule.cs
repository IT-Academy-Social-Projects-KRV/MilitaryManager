using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DocumentGenerator.Interfaces;
using Newtonsoft.Json;

namespace DocumentGenerator.ParsingRules
{
	/// <summary>
	/// Rule for parsing <list> node
	/// </summary>
	public class ListNodeParsingRule : BaseParsingRule
	{
		#region Constructors

		public ListNodeParsingRule(Dictionary<string, object> modelValues) 
			: base(modelValues)
		{
		}

		#endregion

		#region Overrides

		public override string NodeName => "list";

		public override void ParseNode(IDocumentGenerator pdfGenerator, XmlNode node)
		{
			var attributes = node.Attributes;
			if (attributes != null)
			{
				var dataPropName = attributes["data"].Value;

				if (ModelValues.ContainsKey(dataPropName))
				{
					var data = ModelValues[dataPropName].ToString();
					var jsonArray = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(data);
					var retAttribute = attributes["ret"];

					var atrData = PNodeParsingRule.GetAttributesData(attributes);
					var id = 1;
					foreach (var item in jsonArray)
					{
						var text = GetTextForNode(node, item);
						text = text.Replace("[#]", id.ToString());
						pdfGenerator.AddTextBlock(GetDataForText(text), atrData.FontSize, atrData.Style, atrData.Alignment);
						if (retAttribute != null)
						{
							pdfGenerator.AddRetreat(Convert.ToDouble(retAttribute.Value));
						}
						id++;
					}
				}
				
			}
		} 

		#endregion
	}
}
