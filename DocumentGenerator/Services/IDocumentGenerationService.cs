using System.IO;

namespace BusinessLogic.Services.Documents
{
    /// <summary>
    /// Contract for all classes representing document generation functionality
    /// </summary>
    public interface IDocumentGenerationService
    {
        /// <summary>
        /// Generate Pdf document
        /// </summary>
        /// <param name="exportPath">Path for document</param>
        /// <param name="templateName">Tamplate name for document</param>
        /// <param name="templateData">Template data</param>
        /// <param name="jsonData">Data for template</param>
        /// <returns></returns>
        string GeneratePdfDocument(string exportPath, string templateName, string templateData, string jsonData);

		byte[] GeneratePdfDocumentFile(string exportPath, string templateName, string templateData, string jsonData);

		/// <summary>
		/// Generate Word document
		/// </summary>
		/// <param name="exportPath">Path for document</param>
		/// <param name="templateName">Tamplate name for document</param>
		/// <param name="templateData">Template data</param>
		/// <param name="jsonData">Data for template</param>
		/// <returns></returns>
		string GenerateWordDocument(string exportPath, string templateName, string templateData, string jsonData);

        /// <summary>
        /// Apply Font Resolver to use custom font for document generation
        /// </summary>
        /// <param name="webRootPath">Web root path</param>
        void ApplyFontResolver(string webRootPath);
    }
}
