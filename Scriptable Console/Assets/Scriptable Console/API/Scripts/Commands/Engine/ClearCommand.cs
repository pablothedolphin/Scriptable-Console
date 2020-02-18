using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Engine/Clear Command")]
	public class ClearCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (args.Length > 0) return false;

			DeveloperConsoleBehaviour.instance.ClearConsoleEntries ();

			return true;
		}
	}
}