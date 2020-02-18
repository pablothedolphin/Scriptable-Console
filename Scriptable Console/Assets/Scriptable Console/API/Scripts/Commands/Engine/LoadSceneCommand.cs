using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Engine/Load Scene Command")]
	public class LoadSceneCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
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