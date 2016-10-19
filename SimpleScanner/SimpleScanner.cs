using System;
using System.IO;
using System.Text.RegularExpressions;

public class SimpleScanner {

	public static void Main ()
	{
		var pattern = @"(/[*].*?[*]/)|(.)";
		var input = File.ReadAllText ("/home/rodolfo/Documents/CompilerDesign/SimpleScanner/Test.c");
		MatchCollection matches = Regex.Matches (input,pattern, RegexOptions.Singleline);


		foreach (Match m in matches) {
			if (m.Groups [2].Length != 0) {
				Console.Write (m.Groups [2].Value);
			}
		}
	}
}
