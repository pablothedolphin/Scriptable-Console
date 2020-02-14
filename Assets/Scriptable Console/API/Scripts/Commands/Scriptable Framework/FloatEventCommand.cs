using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/FloatEvent Command")]
	public class FloatEventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected FloatEvent floatEvent = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (floatEvent == null) return false;

			if (args.Length != 1) return false;

			if (!float.TryParse (args[0], out float value)) return false;

			floatEvent.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}