using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/IntEvent Command")]
	public class IntEventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected IntEvent intEvent = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (intEvent == null) return false;

			if (args.Length != 1) return false;

			if (!int.TryParse (args[0], out int value)) return false;

			intEvent.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}