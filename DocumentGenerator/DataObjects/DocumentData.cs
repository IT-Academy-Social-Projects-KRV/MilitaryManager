using DocumentGenerator.Interfaces;

namespace DocumentGenerator.DataObjects
{
	/// <summary>
	/// Represents data for generating pdf document
	/// </summary>
	public class DocumentData : IDocumentData
	{
		/// <summary>
		/// Document name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Template for document (xml file)
		/// </summary>
		public string Template { get; set; }

		/// <summary>
		/// Data for document (json file)
		/// </summary>
		public string JsonData { get; set; }
	}
}