using System;
using System.IO;
using System.Xml;
using DocumentGenerator.DataObjects;
using DocumentGenerator.Interfaces;
using PdfSharpCore.Pdf;

namespace DocumentGenerator
{
	/// <summary>
	/// Represets logic for converting xml data to document
	/// </summary>
	public class XmlToDocumentConverter : IXmlToDocumentConverter
	{
		#region Data Members

		private readonly IDocumentGeneratorFactory _documentGeneratorFactory;
		private readonly INodeParserFactory _nodeParserFactory;

		#endregion

		#region Constructors

		/// <summary>
		/// Create XmlToDocumentConverter
		/// </summary>
		public XmlToDocumentConverter() 
			: this(new DocumentGeneratorFactory(), new NodeParserFactory())
		{
		}

		/// <summary>
		/// Create XmlToDocumentConverter
		/// </summary>
		/// <param name="documentGeneratorFactory">Factory for create document generator</param>
		/// <param name="nodeParserFactory">Factory for creating node praser</param>
		public XmlToDocumentConverter(IDocumentGeneratorFactory documentGeneratorFactory, INodeParserFactory nodeParserFactory)
		{
			_documentGeneratorFactory = documentGeneratorFactory;
			_nodeParserFactory = nodeParserFactory;
		}

		#endregion

		#region Properties

		public XmlDocument GetXmlTemplate(string templateData)
		{
			var xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(templateData);
			return xmlDoc;
		}

		#endregion

		#region Private Methods

		private DocumentParams GetDocumentParameters(XmlDocument xmlDoc)
		{
			var trimMargins = new TrimMargins
			{
				Bottom = 80,
				Left = 80,
				Top = 20,
				Right = 20
			};

			var docNode = xmlDoc.FirstChild.Name == "documnet" ? xmlDoc.FirstChild : null;
			var attributes = docNode?.Attributes;
			if (attributes != null)
			{
				var bottomAttribute = docNode.Attributes?["bottom"];
				if (bottomAttribute != null)
				{
					trimMargins.Bottom = Convert.ToInt32(bottomAttribute.Value);
				}
				var leftAttribute = docNode.Attributes?["left"];
				if (leftAttribute != null)
				{
					trimMargins.Left = Convert.ToInt32(leftAttribute.Value);
				}
				var topAttribute = docNode.Attributes?["top"];
				if (topAttribute != null)
				{
					trimMargins.Top = Convert.ToInt32(topAttribute.Value);
				}
				var rightAttribute = docNode.Attributes?["right"];
				if (rightAttribute != null)
				{
					trimMargins.Right = Convert.ToInt32(rightAttribute.Value);
				}
			}
			return new DocumentParams
			{
				TrimMargins = trimMargins
			};
		}

		#endregion

		#region IXmlToDocumentConverter Members

		/// <summary>
		/// Generate Pdf document
		/// </summary>
		/// <param name="type">Document type</param>
		/// <param name="path">Path to save new document</param>
		/// <param name="data">Document data object</param>
		/// <returns></returns>
		public string CreateDocument(DocumentType type, string path, IDocumentData data)
		{
			var docName = DateTime.Now.Ticks.ToString();
			var xml = GetXmlTemplate(data.Template);
			var documentGenerator =
				_documentGeneratorFactory.CreateDocumentGenerator(type, $"{path}\\{docName}",
					GetDocumentParameters(xml));

			var nodeParser = _nodeParserFactory.CreateNodeParser(data.JsonData);

			foreach (XmlNode node in xml.FirstChild.ChildNodes)
			{
				nodeParser.ParseNode(documentGenerator, node);
			}

			documentGenerator.SaveDocument();
			return $"{docName}.pdf";
		}

		public byte[] CreateDocumentFile(DocumentType type, string path, IDocumentData data)
		{
			var docName = DateTime.Now.Ticks.ToString();
			var xml = GetXmlTemplate(data.Template);
			var documentGenerator =
				_documentGeneratorFactory.CreateDocumentGenerator(type, $"{path}\\{docName}",
					GetDocumentParameters(xml));

			var nodeParser = _nodeParserFactory.CreateNodeParser(data.JsonData);

			foreach (XmlNode node in xml.FirstChild.ChildNodes)
			{
				nodeParser.ParseNode(documentGenerator, node);
			}

			return documentGenerator.SaveDocumentFile();
		}

		#endregion
	}
}