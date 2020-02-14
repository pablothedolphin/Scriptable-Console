using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="appEvent"></param>
		/// <param name="commandWord"></param>
		public static void RaiseFromConsole (this AppEvent appEvent, string commandWord)
		{
			appEvent.RaiseEvent ("ScriptableConsole", commandWord, -1);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="appEvent"></param>
		/// <param name="value"></param>
		/// <param name="commandWord"></param>
		public static void RaiseFromConsole<T> (this AppEvent<T> appEvent, T value, string commandWord)
		{
			appEvent.RaiseEvent (value, "ScriptableConsole", commandWord, -1);
		}
	}
}