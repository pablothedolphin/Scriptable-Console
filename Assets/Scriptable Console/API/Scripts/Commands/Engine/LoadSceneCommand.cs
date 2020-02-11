using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Load Scene Command")]
	public class LoadSceneCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			if (args.Length != 1) { return false; }

			try
			{
				SceneManager.LoadScene (args[0], LoadSceneMode.Single);
			}
			catch
			{
				Debug.LogError ("Couldn't load scene: " + args[0]);

				return false;
			}

			return true;
		}
	}
}