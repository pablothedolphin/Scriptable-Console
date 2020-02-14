using TMPro;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ScriptableFramework.DeveloperConsole
{
	public class DeveloperConsoleBehaviour : MonoBehaviour
	{
		[SerializeField] protected List<ConsoleCommand> commands = new List<ConsoleCommand> ();

		[Header ("UI")]
		[SerializeField] protected GameObject uiCanvas = null;
		[SerializeField] protected TMP_InputField inputField = null;
		[SerializeField] protected Transform entriesParent = null;
		[SerializeField] [Range (20, 100)] protected int maxEntryCount = 20;

		[Header ("Prefabs")]
		[SerializeField] protected ConsoleEntry logPrefab = null;
		[SerializeField] protected ConsoleEntry warningPrefab = null;
		[SerializeField] protected ConsoleEntry errorPrefab = null;
		[SerializeField] protected ConsoleEntry commandPrefab = null;
		[SerializeField] protected ConsoleEntry failedCommandPrefab = null;



		public static DeveloperConsoleBehaviour instance;

		protected DeveloperConsole developerConsole;
		protected DeveloperConsole DeveloperConsole
		{
			get
			{
				if (developerConsole != null) { return developerConsole; }
				return developerConsole = new DeveloperConsole (commands);
			}
		}

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

		protected virtual void SortCommands ()
		{
			commands = commands.OrderBy (c => c.commandWord).ToList ();
		}

		protected virtual void OnEnable ()
		{
			Application.logMessageReceived += HandleLog;
		}

		protected virtual void OnDisable ()
		{
			Application.logMessageReceived -= HandleLog;
		}

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

		protected virtual void InstantiateNewEntry (ConsoleEntry prefab, string entryText)
		{
			ConsoleEntry entry = Instantiate (prefab, entriesParent);

			entry.SetText (entryText);

			entry.transform.SetSiblingIndex (0);

			if (entriesParent.childCount > maxEntryCount) StartCoroutine (ClearExcessChildren ());
		}

		protected virtual IEnumerator ClearExcessChildren ()
		{
			while (entriesParent.childCount > maxEntryCount)
			{
				Destroy (entriesParent.GetChild (entriesParent.childCount - 1).gameObject);
				yield return null;
			}
		}

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

		public virtual void SetInputFieldText (string newText)
		{
			inputField.text = newText;
			inputField.caretPosition = inputField.text.Length;
		}

		public virtual void ClearConsoleEntries ()
		{
			entriesParent.DestroyChildren ();
		}

		public virtual void ShowCommandHelp ()
		{
			for (int i = commands.Count - 1; i >= 0; i--)
			{
				string helpText = string.Format ("{0}: {1}", MakeBold (commands[i].commandWord), commands[i].description);

				InstantiateNewEntry (logPrefab, helpText);
			}
		}

		protected virtual string MakeBold (string value)
		{
			return "<b>" + value + "</b>";
		}
	}
}