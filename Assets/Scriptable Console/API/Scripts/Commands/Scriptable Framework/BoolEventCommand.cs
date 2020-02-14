using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/BoolEvent Command")]
	public class BoolEventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected BoolEvent boolEvent = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (boolEvent == null) return false;

			if (args.Length != 1) return false;

			if (!bool.TryParse (args[0], out bool value)) return false;

			boolEvent.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}