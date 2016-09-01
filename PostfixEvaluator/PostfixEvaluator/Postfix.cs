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
		public String Lexeme { get; }

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


			var s = new Stack<double> ();

			foreach (Token t in new Scanner (line).Start ()) {
				double x = 0;
				double y = 0;
				try{
					switch (t.Category) {

					case TokenCategory.NUMBER:
						s.Push (Convert.ToDouble (t.Lexeme));
						break;
					case TokenCategory.ADD:
						x = s.Pop ();
						y = s.Pop ();
						s.Push (y + x);
						break;
					case TokenCategory.SUB:
						x = s.Pop ();
						y = s.Pop ();
						s.Push (y - x);
						break;
					case TokenCategory.MUL:
						x = s.Pop ();
						y = s.Pop ();
						s.Push (y * x);
						break;
					case TokenCategory.DIV:
						x = s.Pop ();
						y = s.Pop ();
						s.Push (y / x);
						break;

					}	
					}catch(InvalidOperationException){
						Console.Write ("The operation is incorrect");
						return;
					}

			}
			if (s.Count > 1 || s.Count == 0) {
				Console.Write ("The operation is incorrect");
				return;
			}

			var result = s.Pop ();
			Console.Write (result);
		}

	}
}
