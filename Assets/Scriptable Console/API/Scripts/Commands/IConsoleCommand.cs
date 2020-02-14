namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public interface IConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		string CommandWord { get; }
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		bool Process (string[] args);
	}
}