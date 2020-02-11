﻿namespace ScriptableFramework.DeveloperConsole
{
	public interface IConsoleCommand
	{
		string CommandWord { get; }
		bool Process (string[] args);
	}
}