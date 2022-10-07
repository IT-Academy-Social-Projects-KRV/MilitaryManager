namespace DocumentGenerator.Interfaces
{
    /// <summary>
    /// Contract for all classes that is representing data for document generating
    /// </summary>
    public interface IDocumentData
    {
        /// <summary>
        /// Field data (json) object
        /// </summary>
        string JsonData { get; set; }

        /// <summary>
        /// Template and document Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Template for generating document (xml file)
        /// </summary>
        string Template { get; set; }
    }
}
