using System.IO;

namespace DocumentGenerator.Interfaces
{
	/// <summary>
	/// Contract for classes that is representing logic for creating document
	/// </summary>
	public interface IXmlToDocumentConverter
	{
		/// <summary>
		/// Create document by type and some datsa
		/// </summary>
		/// <param name="type">Docuemnt type</param>
		/// <param name="path">Path where document will be created</param>
		/// <param name="data">Doceumtn Data</param>
		/// <returns>Path for document</returns>
		string CreateDocument(DocumentType type, string path, IDocumentData data);

		byte[] CreateDocumentFile(DocumentType type, string path, IDocumentData data);
	}
}