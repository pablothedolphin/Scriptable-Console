using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Engine/Load Scene Command")]
	public class LoadSceneCommand : ConsoleCommand
	{
		public override bool Process (string[] args)
		{
			string sceneName = string.Join (" ", args);

			try
			{
				SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}