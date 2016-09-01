using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostfixEvaluator
{
	public enum TokenCategory
	{
		NUMBER,
		ADD,
		SUB,
		MUL,
		DIV,
		BAD_TOKEN
	}

	public class Token
	{
		public string Lexeme { get; }

		public TokenCategory Category { get; }

		public Token (String lexeme, TokenCategory category)
		{
			Lexeme = lexeme;
			Category = category;
		}

		public override String ToString ()
		{
			return String.Format ("[{0} \"{1}\"]", Category, Lexeme);
		}
	}

	public class Scanner
	{
		public String Input { get; }

		public Scanner (String input)
		{
			Input = input;
		}

		public IEnumerable<Token> Start ()
		{
			var regex = new Regex (
				@"(\d+([.]\d+)?)|([+])|(-)|([*])|(/)|(\s)|(.)");
			foreach (Match m in regex.Matches(Input)) {
				if (m.Groups [1].Length > 0) {
					yield return new Token (m.Value, TokenCategory.NUMBER);

				} else if (m.Groups [3].Length > 0) {
					yield return new Token (m.Value, TokenCategory.ADD);

				} else if (m.Groups [4].Length > 0) {
					yield return new Token (m.Value, TokenCategory.SUB);

				} else if (m.Groups [5].Length > 0) {
					yield return new Token (m.Value, TokenCategory.MUL);

				} else if (m.Groups [6].Length > 0) {
					yield return new Token (m.Value, TokenCategory.DIV);

				} else if (m.Groups [7].Length > 0) {
					continue;

				} else {
					yield return new Token (m.Value, TokenCategory.BAD_TOKEN);
				}
			}
		}
	}

	public class Driver
	{
		public static void Main ()
		{
			Console.Write ("Input prefix expression: ");
			var line = Console.ReadLine ();

			foreach (Token t in new Scanner (line).Start ()) {
				Console.WriteLine (t);
			}
		}
	}
}
