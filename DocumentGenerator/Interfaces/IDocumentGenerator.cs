using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using System.IO;

namespace DocumentGenerator.Interfaces
{
    /// <summary>
    /// Contract for class that is representing logic for pdf generating
    /// </summary>
    public interface IDocumentGenerator
    {
        /// <summary>
        /// Add tittle into the document
        /// </summary>
        /// <param name="title">Tittle text</param>
        void AddTitle(string title);

        /// <summary>
        /// Add text block into document
        /// </summary>
        /// <param name="text">Text to be added</param>
        /// <param name="fontSize">Font size fot text</param>
        /// <param name="fontStyle">Font style for text</param>
        /// <param name="textAlign">Text alignment</param>
        void AddTextBlock(string text, int fontSize = 14, XFontStyle fontStyle = XFontStyle.Regular,
            XParagraphAlignment textAlign = XParagraphAlignment.Center);

        /// <summary>
        /// Add image block into document
        /// </summary>
        /// <param name="imagePath">Path in wwwroot to image</param>
        /// <param name="width">Image block width</param>
        /// <param name="height">Image block height</param>
        void AddImage(string imagePath, double width, double height);

        /// <summary>
        /// Add retreat
        /// </summary>
        /// <param name="height">Retreat height</param>
        void AddRetreat(double height);

		/// <summary>
		/// Save Pdf document
		/// </summary>
		void SaveDocument();

		byte[] SaveDocumentFile();
	}
}