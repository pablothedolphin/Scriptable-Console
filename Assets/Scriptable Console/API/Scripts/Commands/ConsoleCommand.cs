using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
	{
		[SerializeField] internal string commandWord = string.Empty;
		[SerializeField] [TextArea (3, 50)] internal string description = string.Empty;

		public string CommandWord => commandWord;

		public abstract bool Process (string[] args);
	}
}