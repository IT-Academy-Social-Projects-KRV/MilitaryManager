namespace DocumentGenerator.Interfaces
{
	/// <summary>
	/// Represents access for creating node parser objects
	/// </summary>
	public interface INodeParserFactory
	{
		/// <summary>
		/// Create Node Parser
		/// </summary>
		/// <param name="jsonDataModel">Data model (json file)</param>
		/// <returns>Node parser object</returns>
		INodeParser CreateNodeParser(string jsonDataModel);
	}
}