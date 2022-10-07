using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;

namespace DocumentGenerator.DataObjects
{
    /// <summary>
    /// Represents attributes for <p></p>
    /// </summary>
    public class PNodeParams
    {
        public PNodeParams()
        {
            FontSize = 14;
        }

        /// <summary>
        /// Font style for text
        /// </summary>
        public XFontStyle Style { get; set; }

        /// <summary>
        /// Font size
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Font alignment
        /// </summary>
        public XParagraphAlignment Alignment { get; set; }
    }
}
