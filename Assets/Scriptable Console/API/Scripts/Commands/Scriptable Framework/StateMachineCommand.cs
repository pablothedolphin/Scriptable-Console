using UnityEngine;

namespace ScriptableFramework.DeveloperConsole
{
	[CreateAssetMenu (menuName = "Console Commands/Scriptable Framework/StateMachine Command")]
	public class StateMachineCommand : ConsoleCommand
	{
		[SerializeField] protected StateMachineBase stateMachine = null;

		public override bool Process (string[] args)
		{
			if (stateMachine == null) return false;

			if (args.Length != 1) return false;

			if (!int.TryParse (args[0], out int index)) return false;

			stateMachine.UpdateState (index);

			return true;
		}
	}
}