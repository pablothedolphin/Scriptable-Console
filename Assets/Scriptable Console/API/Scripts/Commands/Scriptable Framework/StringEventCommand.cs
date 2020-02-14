using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/StringEvent Command")]
	public class StringEventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected StringEvent stringEvent = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (stringEvent == null) return false;

			if (args.Length == 0) return false;

			string value = string.Join (" ", args);

			stringEvent.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}