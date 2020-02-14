using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/StateMachine Command")]
	public class StateMachineCommand : ConsoleCommand
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField] protected StateMachineBase stateMachine = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public override bool Process (string[] args)
		{
			if (stateMachine == null) return false;

			if (args.Length != 1) return false;

			if (int.TryParse (args[0], out int index))
			{ 
				stateMachine.UpdateState (index);
				return true;
			}
			else if (bool.TryParse (args[0], out bool state))
			{
				stateMachine.UpdateState (state);
				return true;
			}

			return false;
		}
	}
}