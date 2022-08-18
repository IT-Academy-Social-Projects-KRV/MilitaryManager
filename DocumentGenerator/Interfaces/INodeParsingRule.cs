using System.Xml;

namespace DocumentGenerator.Interfaces
{
	/// <summary>
	/// Contract for all node parsing rules
	/// </summary>
	public interface INodeParsingRule
	{
		/// <summary>
		/// Name for node to be parsed
		/// </summary>
		string NodeName { get; }

		/// <summary>
		/// Parse xml node
		/// </summary>
		/// <param name="documentGenerator">Object for generating document</param>
		/// <param name="node">Xml node to be parsed</param>
		void ParseNode(IDocumentGenerator documentGenerator, XmlNode node);
	}
}