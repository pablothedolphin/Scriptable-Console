using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/AppEvent Command")]
	public class AppEventCommand : ConsoleCommand
	{
		[SerializeField] protected AppEvent appEvent = null;

		public override bool Process (string[] args)
		{
			if (appEvent == null) return false;

			appEvent.RaiseFromConsole (commandWord);

			return true;
		}
	}
}