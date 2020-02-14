using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScriptableFramework.DeveloperConsole
{
	[RequireComponent (typeof (TextMeshProUGUI))]
	public class ConsoleEntry : MonoBehaviour
	{
		protected TextMeshProUGUI entryText = null;

		protected virtual void Awake ()
		{
			entryText = GetComponent<TextMeshProUGUI> ();
		}

		public virtual void SetText (string commandText)
		{
			if (entryText != null) entryText.text = commandText;
		}
	}
}