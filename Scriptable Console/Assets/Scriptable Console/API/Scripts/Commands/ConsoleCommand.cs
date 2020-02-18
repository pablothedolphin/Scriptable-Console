using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] internal string commandWord = string.Empty;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] [TextArea (3, 50)] internal string description = string.Empty;

		/// <summary>
		/// 
		/// </summary>
		public string CommandWord => commandWord;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public abstract bool Process (string[] args);
	}
}