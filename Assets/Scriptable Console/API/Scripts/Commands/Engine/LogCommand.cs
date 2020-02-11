using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Log Command")]
	public class LogCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			string logText = string.Join (" ", args);

			Debug.Log (logText);

			return true;
		}
	}
}