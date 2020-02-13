using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ScriptableFramework.DeveloperConsole
{
	public class DeveloperConsoleBehaviour : MonoBehaviour
	{
		[SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

		[Header ("UI")]
		[SerializeField] private GameObject uiCanvas = null;
		[SerializeField] private TMP_InputField inputField = null;

		private static DeveloperConsoleBehaviour instance;

		private DeveloperConsole developerConsole;
		private DeveloperConsole DeveloperConsole
		{
			get
			{
				if (developerConsole != null) { return developerConsole; }
				return developerConsole = new DeveloperConsole (commands);
			}
		}

		private void Awake ()
		{
			if (instance != null && instance != this)
			{
				Destroy (gameObject);
				return;
			}

			instance = this;

			DontDestroyOnLoad (gameObject);
		}

		public void Toggle (CallbackContext context)
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

		public void ProcessCommand (string inputValue)
		{
			DeveloperConsole.ProcessCommand (inputValue);

			inputField.text = string.Empty;
		}
	}
}