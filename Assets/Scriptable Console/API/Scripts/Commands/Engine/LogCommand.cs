using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Engine/Log Command")]
	public class LogCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
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