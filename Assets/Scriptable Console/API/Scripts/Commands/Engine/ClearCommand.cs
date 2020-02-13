using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Clear Command")]
	public class ClearCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			if (args.Length > 0) return false;

			DeveloperConsoleBehaviour.instance.ClearConsoleEntries ();

			return true;
		}
	}
}