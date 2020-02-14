using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/Vector3Event Command")]
	public class Vector3EventCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected Vector3Event vector3Event = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (vector3Event == null) return false;

			if (args.Length != 1) return false;

			if (!CommandArguments.TryParse (args[0], out Vector3 value)) return false;

			vector3Event.RaiseFromConsole (value, commandWord);

			return true;
		}
	}
}