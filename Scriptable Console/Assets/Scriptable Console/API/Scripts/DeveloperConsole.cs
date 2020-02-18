using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public class DeveloperConsole
	{
		/// <summary>
		/// 
		/// </summary>
		protected readonly IEnumerable<IConsoleCommand> commands;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commands"></param>
		public DeveloperConsole (IEnumerable<IConsoleCommand> commands)
		{
			this.commands = commands;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inputValue"></param>
		/// <returns></returns>
		public bool ProcessCommand (string inputValue)
		{
			string[] inputSplit = inputValue.Split (' ');

			string commandInput = inputSplit[0];
			string[] args = inputSplit.Skip (1).ToArray ();

			return ProcessCommand (commandInput, args);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="commandInput"></param>
		/// <param name="args"></param>
		/// <returns></returns>
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