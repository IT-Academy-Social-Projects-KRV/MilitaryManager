using System;
using DocumentGenerator.DataObjects;
using DocumentGenerator.Interfaces;

namespace DocumentGenerator
{
	/// <summary>
	/// Represents logic for creating document generator
	/// </summary>
	public class DocumentGeneratorFactory : IDocumentGeneratorFactory
	{
		#region IDocumentGeneratorFactory Members

		public IDocumentGenerator CreateDocumentGenerator(DocumentType type, string documentPath, DocumentParams parameters)
		{
			switch (type)
			{
				case DocumentType.Pdf:
					return new PdfGenerator(documentPath, parameters);
				case DocumentType.Doc:
					throw new NotImplementedException();
			}
			return null;
		}

		#endregion
	}
}