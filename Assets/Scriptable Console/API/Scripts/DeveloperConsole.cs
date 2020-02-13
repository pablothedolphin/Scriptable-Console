using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptableFramework.DeveloperConsole
{
	public class DeveloperConsole
	{
		protected readonly IEnumerable<IConsoleCommand> commands;

		public DeveloperConsole (IEnumerable<IConsoleCommand> commands)
		{
			this.commands = commands;
		}

		public bool ProcessCommand (string inputValue)
		{
			string[] inputSplit = inputValue.Split (' ');

			string commandInput = inputSplit[0];
			string[] args = inputSplit.Skip (1).ToArray ();

			return ProcessCommand (commandInput, args);
		}

		public bool ProcessCommand (string commandInput, string[] args)
		{
			foreach (var command in commands)
			{
				if (!commandInput.Equals (command.CommandWord, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}

				return command.Process (args);
			}

			return false;
		}
	}
}