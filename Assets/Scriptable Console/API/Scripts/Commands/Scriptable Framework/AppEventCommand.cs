using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/Raise App Event")]
	public class AppEventCommand : ConsoleCommand
	{
		[SerializeField] private AppEvent appEvent = null;

		public override bool Process (string[] args)
		{
			if (appEvent == null) return false;

			appEvent.RaiseFromConsole (commandWord);

			return true;
		}
	}
}