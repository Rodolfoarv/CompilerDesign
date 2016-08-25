using System;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class SimpleScanner {
	public static void Main() {
		var regex = new Regex (@"/[*](.|\n)*?[*]/");
		var input = File.ReadAllText ("/home/rodolfo/Documents/CompilerDesign/SimpleScanner/Test.c");
		foreach (Match m in regex.Matches(input)) {
			Console.WriteLine ("{0} {1} {2}", m.Value, m.Index, m.Length);
		}
	}
}