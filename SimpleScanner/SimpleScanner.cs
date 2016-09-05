using System;
using System.IO;
using System.Text.RegularExpressions;

public class SimpleScanner {
	public static void Main() {
		var regex = new Regex (@"(/[*]./?[*]/)|(.)", RegexOptions.Singleline);
		var input = File.ReadAllText ("/home/rodolfo/Documents/CompilerDesign/SimpleScanner/Test.c");
		foreach (Match m in regex.Matches(input)) {
			if (m.Groups [2].Length != 0) { //m.groups[1] refers to the first part (/[*]./?[*]/)|(.+)
				Console.Write (m.Groups [2].Value);
			}

			//Console.WriteLine ("{0} {1} {2}", m.Value, m.Index, m.Length);
		}
	}
}

//Group capturing


// A group that we will be able to define as an index