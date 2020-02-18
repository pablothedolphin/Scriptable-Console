using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ScriptableFramework.DeveloperConsole
{
	/// <summary>
	/// 
	/// </summary>
	public static class CommandArguments
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool TryParse (string argument, out Vector2 value)
		{
			value = Vector2.zero;

			if (!TryStripBrackets(argument, out string strippedArgument)) return false;

			if (!TrySplitComponents (strippedArgument, 2, out string[] components)) return false;

			if (!float.TryParse (components[0], out float x) || 
				!float.TryParse (components[1], out float y)) return false;

			value = new Vector2 (x, y);

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool TryParse (string argument, out Vector3 value)
		{
			value = Vector3.zero;

			if (!TryStripBrackets (argument, out string strippedArgument)) return false;

			if (!TrySplitComponents (strippedArgument, 3, out string[] components)) return false;

			if (!float.TryParse (components[0], out float x) || 
				!float.TryParse (components[1], out float y) ||
				!float.TryParse (components[2], out float z)) return false;

			value = new Vector3 (x, y, z);

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool TryParse (string argument, out Bounds value)
		{
			value = new Bounds ();

			if (!TryStripBrackets (argument, out string strippedArgument)) return false;

			string[] vectors = strippedArgument.Split ("),(".ToCharArray ());

			if (vectors.Length != 2) return false;

			vectors[0] = vectors[0] + ")";
			vectors[1] = "(" + vectors[1];

			if (!TryParse (vectors[0], out Vector3 center)) return false;
			if (!TryParse (vectors[1], out Vector3 size)) return false;

			value = new Bounds (center, size);

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argument"></param>
		/// <param name="strippedArgument"></param>
		/// <returns></returns>
		private static bool TryStripBrackets (string argument, out string strippedArgument)
		{
			strippedArgument = "";

			if (!argument.StartsWith ("(") || !argument.EndsWith (")")) return false;

			strippedArgument = argument.Remove (0).Remove (argument.Length - 1);

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strippedArgument"></param>
		/// <param name="componentCount"></param>
		/// <param name="components"></param>
		/// <returns></returns>
		private static bool TrySplitComponents (string strippedArgument, int componentCount, out string[] components)
		{
			components = new string[0];

			string[] tempComponents = strippedArgument.Split (',');

			if (tempComponents.Length != componentCount) return false;

			components = tempComponents;

			return true;
		}
	}
}