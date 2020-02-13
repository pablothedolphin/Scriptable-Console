using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScriptableFramework.DeveloperConsole
{
	public class ConsoleCommandEntry : ConsoleEntry
	{
		public virtual void GetText ()
		{
			DeveloperConsoleBehaviour.instance.SetInputFieldText (entryText.text);
		}
	}
}