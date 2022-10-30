using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DocumentGenerator.DataObjects;
using DocumentGenerator.Interfaces;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;

namespace DocumentGenerator
{
    public class PdfGenerator : IDocumentGenerator
    {
        #region Data Members

        private readonly string _path;
        private PdfPage _currentPage;
        private readonly PdfDocument _document;
        private readonly Dictionary<PdfPage, XGraphics> _availableGfx = new Dictionary<PdfPage, XGraphics>();
        private readonly DocumentParams _params;
        private double _activeTopPosition;

        #endregion

        #region Constructors

        /// <summary>
        /// Create PdfGenerator
        /// </summary>
        /// <param name="path">Path to file to be saved</param>
        /// <param name="params">Document parameters object</param>
        public PdfGenerator(string path, DocumentParams @params)
        {
            _params = @params;
            _path = path;
            _document = new PdfDocument();
            AddPage();
        }

        #endregion

        #region Private Methods

        private void AddPage()
        {
            _activeTopPosition = 0;
            _currentPage = _document.AddPage();
            SetUpPage(_currentPage);
        }

        private XGraphics Gfx
        {
            get
            {
                if (_availableGfx.ContainsKey(_currentPage)) return _availableGfx[_currentPage];
                var gfx = XGraphics.FromPdfPage(_currentPage);
                _availableGfx.Add(_currentPage, gfx);
                return gfx;
            }
        }

        private void SetUpPage(PdfPage page)
        {
            page.TrimMargins = _params.TrimMargins;
        }

        private static double GetTextHeight(XGraphics gfx, XFont font, string text, double rectWidth)
        {
            var fontHeight = font.GetHeight() * 0.667;
            var absoluteTextHeight = gfx.MeasureString(text, font).Height;
            var absoluteTextWidth = gfx.MeasureString(text, font).Width;

            if (absoluteTextWidth > rectWidth)
            {
                var linesToAdd = (int)Math.Ceiling(absoluteTextWidth / 380) - 1;
                return absoluteTextHeight + linesToAdd * fontHeight;
            }

            return absoluteTextHeight;
        }

        #endregion

        #region IDocumentGenerator Members

        public void AddTitle(string text)
        {
            AddTextBlock(text);
        }

        public void AddTextBlock(string text, int fontSize = 14, XFontStyle fontStyle = XFontStyle.Regular,
            XParagraphAlignment textAlign = XParagraphAlignment.Center)
        {
            var font = new XFont("Times New Roman", fontSize, fontStyle);
            var tf = new XTextFormatter(Gfx) { Alignment = textAlign };
            var height = GetTextHeight(Gfx, font, text, _currentPage.Width);
            var rect = new XRect(0, _activeTopPosition, _currentPage.Width, height);
            AddRetreat(height);
            tf.DrawString(text, font, XBrushes.Black, rect);

            if (_activeTopPosition > _currentPage.Height.Value - _currentPage.TrimMargins.Bottom) AddPage();
        }

        public void AddImage(string imagePath, double width, double height)
        {
            var wwwrootPath = Regex.Match(_path,
                                         String.Format(@".+{0}", "wwwroot"),
                                         RegexOptions.IgnoreCase).Value;
            XImage img = XImage.FromFile(Path.Combine(wwwrootPath, imagePath));
            var rect = new XRect((_currentPage.Width - width) / 2, _activeTopPosition, width, height);
            AddRetreat(height + 10);
            Gfx.DrawImage(img, rect);
            img.Dispose();
        }

        public void AddRetreat(double height)
        {
            _activeTopPosition += height;
        }

		public void SaveDocument()
		{
			_document.Save($"{_path}.pdf");
		}

		public byte[] SaveDocumentFile()
		{
			using (var ms = new MemoryStream())
			{
				_document.Save(ms);
				return ms.ToArray();
			}
		}

        #endregion
    }
}