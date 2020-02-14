using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Engine/Gravity Command")]
	public class GravityCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (args.Length != 1) { return false; }

			if (!float.TryParse (args[0], out float value))
			{
				return false;
			}

			Physics.gravity = new Vector3 (Physics.gravity.x, value, Physics.gravity.z);

			return true;
		}
	}
}