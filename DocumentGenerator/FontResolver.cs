using System;
using System.IO;
using PdfSharpCore.Fonts;

namespace DocumentGenerator
{
    /// <summary>
    /// Contains logic for getting custom fonts for document
    /// </summary>
    public class FontResolver : IFontResolver
    {
        #region Data Members

        private readonly string _rootPath;

        #endregion

        #region Constructors

        /// <summary>
        /// FontResolver
        /// </summary>
        /// <param name="rootPath">Root web path</param>
        public FontResolver(string rootPath)
        {
            _rootPath = rootPath;
        }

        #endregion

        #region IFontResolver Members

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Ignore case of font names.
            var name = familyName.ToLower().TrimEnd('#');

            // Deal with the fonts we know.
            switch (name)
            {
                case "times new roman":
                    if (isBold)
                    {
                        if (isItalic)
                            return new FontResolverInfo("Times#bi");
                        return new FontResolverInfo("Times#b");
                    }

                    if (isItalic)
                        return new FontResolverInfo("Times#i");
                    return new FontResolverInfo("Times#");
            }

            // We pass all other font requests to the default handler.
            // When running on a web server without sufficient permission, you can return a default font at this stage.
            return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
        }

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "Times#":
                    return LoadFontData("times.ttf");
                    ;

                case "Times#b":
                    return LoadFontData("timesbd.ttf");
                    ;

                case "Times#i":
                    return LoadFontData("timesi.ttf");

                case "Times#bi":
                    return LoadFontData("timesbi.ttf");
            }

            return null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the specified font from an embedded resource.
        /// </summary>
        private byte[] LoadFontData(string name)
        {
            try
            {
                using (var stream = new FileStream($"{_rootPath}\\fonts\\{name}", FileMode.Open, FileAccess.Read))
                {
                    var count = (int)stream.Length;
                    var data = new byte[count];
                    stream.Read(data, 0, count);
                    return data;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException($"Can not find font {name}");
            }
        }

        public string DefaultFontName => "times new roman";

        #endregion
    }
}
