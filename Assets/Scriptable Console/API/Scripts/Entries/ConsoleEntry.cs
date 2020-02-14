using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[RequireComponent (typeof (TextMeshProUGUI))]
	public class ConsoleEntry : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		protected TextMeshProUGUI entryText = null;

		/// <summary>
		/// 
		/// </summary>
		protected virtual void Awake ()
		{
			entryText = GetComponent<TextMeshProUGUI> ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commandText"></param>
		public virtual void SetText (string commandText)
		{
			if (entryText != null) entryText.text = commandText;
		}
	}
}