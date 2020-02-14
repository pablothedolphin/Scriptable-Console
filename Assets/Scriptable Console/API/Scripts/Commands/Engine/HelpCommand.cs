using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Help Command")]
	public class HelpCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			if (args.Length != 0) { return false; }

			DeveloperConsoleBehaviour.instance.ShowCommandHelp ();

			return true;
		}
	}
}