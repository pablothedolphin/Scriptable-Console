using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/BoundsEvent Command")]
	public class BoundsEventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected BoundsEvent boundsEvent = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (boundsEvent == null) return false;

			if (args.Length != 1) return false;

			if (!CommandArguments.TryParse (args[0], out Bounds value)) return false;

			boundsEvent.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}