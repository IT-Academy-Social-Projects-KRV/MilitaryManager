using System;
using DocumentGenerator;
using DocumentGenerator.DataObjects;
using DocumentGenerator.Interfaces;
using PdfSharpCore.Fonts;

namespace BusinessLogic.Services.Documents
{
	/// <summary>
	/// Service for generating documents
	/// </summary>
	public class DocumentGenerationService : IDocumentGenerationService
	{
		#region Data Members

		private readonly IXmlToDocumentConverter _xmlToDocumentConverter;

		#endregion

		#region Constructors

		/// <summary>
		/// Create DocumentGenerationService
		/// </summary>
		public DocumentGenerationService()
			:this(new XmlToDocumentConverter())
		{
		}

		/// <summary>
		/// Create DocumentGenerationService
		/// </summary>
		/// <param name="xmlToDocumentConverter">XmlToDocumentConverter object</param>
		public DocumentGenerationService(IXmlToDocumentConverter xmlToDocumentConverter)
		{
			_xmlToDocumentConverter = xmlToDocumentConverter;
		}

		#endregion

		#region Statics

		public void ApplyFontResolver(string webRootPath)
		{
			
			if (GlobalFontSettings.FontResolver == null)
			{
				GlobalFontSettings.FontResolver = new FontResolver(webRootPath);
			}
		}

		#endregion

		#region Private Methods

		private string GenerateDocument(DocumentType documentType, string exportPath, string templateName, string templateData, string jsonData)
		{
			var documentData = new DocumentData
			{
				Name = templateName,
				Template = templateData,
				JsonData = jsonData
			};
			try
			{
				return _xmlToDocumentConverter.CreateDocument(documentType, exportPath, documentData);
			}
			catch (Exception exception)
			{
				return exception.Message;
			}
		}

		#endregion

		#region IDocumentGenerationService Members

		public string GeneratePdfDocument(string exportPath, string templateName, string templateData, string jsonData)
		{
			return GenerateDocument(DocumentType.Pdf, exportPath, templateName, templateData, jsonData);
		}

		public string GenerateWordDocument(string exportPath, string templateName, string templateData, string jsonData)
		{
			return GenerateDocument(DocumentType.Doc, exportPath, templateName, templateData, jsonData);
		}

		#endregion
	}
}
