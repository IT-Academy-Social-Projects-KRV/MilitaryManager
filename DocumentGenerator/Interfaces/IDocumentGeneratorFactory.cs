using DocumentGenerator.DataObjects;

namespace DocumentGenerator.Interfaces
{
    /// <summary>
    /// Represents access for creating document generator
    /// </summary>
    public interface IDocumentGeneratorFactory
    {
        /// <summary>
        /// Create Document Generator
        /// </summary>
        /// <param name="type">Document Type</param>
        /// <param name="documentPath">Path where documents should be created</param>
        /// <param name="parameters">Parameters for creating documents</param>
        /// <returns></returns>
        IDocumentGenerator CreateDocumentGenerator(DocumentType type, string documentPath, DocumentParams parameters);
    }
}
