using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsoleCommandEntry : ConsoleEntry
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual void GetText ()
		{
			DeveloperConsoleBehaviour.instance.SetInputFieldText (entryText.text);
		}
	}
}