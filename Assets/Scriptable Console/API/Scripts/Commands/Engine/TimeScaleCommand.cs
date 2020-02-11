using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/TimeScale Command")]
	public class TimeScaleCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			if (args.Length != 1) { return false; }

			if (!float.TryParse (args[0], out float value))
			{
				return false;
			}

			Time.timeScale = value;

			return true;
		}
	}
}