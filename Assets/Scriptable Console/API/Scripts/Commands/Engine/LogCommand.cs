using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Log Command")]
	public class LogCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			if (args.Length == 0) return false;

			string logText = string.Join (" ", args);

			if (string.IsNullOrWhiteSpace (logText)) return false;

			Debug.Log (logText);

			return true;
		}
	}
}