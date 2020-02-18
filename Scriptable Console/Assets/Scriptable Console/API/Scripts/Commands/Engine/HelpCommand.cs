using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Engine/Help Command")]
	public class HelpCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (args.Length != 0) { return false; }

			DeveloperConsoleBehaviour.instance.ShowCommandHelp ();

			return true;
		}
	}
}