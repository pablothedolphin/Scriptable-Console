using TMPro;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public class DeveloperConsoleBehaviour : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected List<ConsoleCommand> commands = new List<ConsoleCommand> ();

		/// <summary>
		/// 
		/// </summary>
		[Header ("UI")]
		[SerializeField] protected GameObject uiCanvas = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected TMP_InputField inputField = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected Transform entriesParent = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] [Range (20, 100)] protected int maxEntryCount = 20;

		/// <summary>
		/// 
		/// </summary>
		[Header ("Prefabs")]
		[SerializeField] protected ConsoleEntry logPrefab = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected ConsoleEntry warningPrefab = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected ConsoleEntry errorPrefab = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected ConsoleEntry commandPrefab = null;
		
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected ConsoleEntry failedCommandPrefab = null;


		/// <summary>
		/// 
		/// </summary>
		public static DeveloperConsoleBehaviour instance;

		/// <summary>
		/// 
		/// </summary>
		protected DeveloperConsole developerConsole;
		
		/// <summary>
		/// 
		/// </summary>
		protected DeveloperConsole DeveloperConsole
		{
			get
			{
				if (developerConsole != null) { return developerConsole; }
				return developerConsole = new DeveloperConsole (commands);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void Awake ()
		{
			if (instance != null && instance != this)
			{
				Destroy (gameObject);
				return;
			}

			instance = this;

			SortCommands ();

			DontDestroyOnLoad (gameObject);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SortCommands ()
		{
			commands = commands.OrderBy (c => c.commandWord).ToList ();
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void OnEnable ()
		{
			Application.logMessageReceived += HandleLog;
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void OnDisable ()
		{
			Application.logMessageReceived -= HandleLog;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logString"></param>
		/// <param name="stackTrace"></param>
		/// <param name="type"></param>
		protected virtual void HandleLog (string logString, string stackTrace, LogType type)
		{
			switch (type)
			{
				case LogType.Log:
					InstantiateNewEntry (logPrefab, logString);
					break;
				case LogType.Warning:
					InstantiateNewEntry (warningPrefab, logString);
					break;
				case LogType.Error:
					InstantiateNewEntry (errorPrefab, logString);
					break;
				case LogType.Exception:
					InstantiateNewEntry (errorPrefab, logString);
					break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="prefab"></param>
		/// <param name="entryText"></param>
		protected virtual void InstantiateNewEntry (ConsoleEntry prefab, string entryText)
		{
			ConsoleEntry entry = Instantiate (prefab, entriesParent);

			entry.SetText (entryText);

			entry.transform.SetSiblingIndex (0);

			if (entriesParent.childCount > maxEntryCount) StartCoroutine (ClearExcessChildren ());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual IEnumerator ClearExcessChildren ()
		{
			while (entriesParent.childCount > maxEntryCount)
			{
				Destroy (entriesParent.GetChild (entriesParent.childCount - 1).gameObject);
				yield return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		public virtual void Toggle (CallbackContext context)
		{
			if (!context.action.triggered) { return; }

			if (uiCanvas.activeSelf)
			{
				uiCanvas.SetActive (false);
			}
			else
			{
				uiCanvas.SetActive (true);
				inputField.ActivateInputField ();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputValue"></param>
		public virtual void ProcessCommand (string inputValue)
		{
			inputField.text = string.Empty;

			if (string.IsNullOrWhiteSpace (inputValue)) return;

			if (DeveloperConsole.ProcessCommand (inputValue))
			{
				InstantiateNewEntry (commandPrefab, inputValue);
			}
			else
			{
				InstantiateNewEntry (failedCommandPrefab, inputValue);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newText"></param>
		public virtual void SetInputFieldText (string newText)
		{
			inputField.text = newText;
			inputField.caretPosition = inputField.text.Length;
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void ClearConsoleEntries ()
		{
			entriesParent.DestroyChildren ();
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void ShowCommandHelp ()
		{
			for (int i = commands.Count - 1; i >= 0; i--)
			{
				string helpText = string.Format ("{0}: {1}", MakeBold (commands[i].commandWord), commands[i].description);

				InstantiateNewEntry (logPrefab, helpText);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		protected virtual string MakeBold (string value)
		{
			return "<b>" + value + "</b>";
		}
	}
}