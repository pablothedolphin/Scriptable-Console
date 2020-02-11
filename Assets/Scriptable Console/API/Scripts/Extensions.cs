using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	public static class Extensions
	{
		public static void RaiseFromConsole (this AppEvent appEvent, string commandWord)
		{
			appEvent.RaiseEvent ("ScriptableConsole", commandWord, -1);
		}

		public static void RaiseFromConsole<T> (this AppEvent<T> appEvent, T value, string commandWord)
		{
			appEvent.RaiseEvent (value, "ScriptableConsole", commandWord, -1);
		}
	}
}