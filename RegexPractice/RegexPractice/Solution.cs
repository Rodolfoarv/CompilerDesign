using System;
using System.IO;
using System.Text.RegularExpressions;

public class Solution
{
	public Solution ()
	{
	
	}

	public static void Main(){
		string pattern = @"([a-zA-z]+) (\d+)";
		MatchCollection matches = Regex.Matches ("June 24, August 9, Dec 12", pattern);

		Console.WriteLine ("{0} matches", matches.Count);

		foreach (Match match in matches) {
			Console.WriteLine ("Match {0} at index [{1}, {2}]", 
				match.Value,
				match.Index,
				match.Index + match.Length);
		}

		foreach (Match match in matches) {
			GroupCollection data = match.Groups;
			Console.WriteLine("{0} groups captured in {1}", data.Count, match.Value);
			Console.WriteLine("Month: " + data[1] + ", Day: " + data[2]);
			Console.WriteLine("Month found at[{0}, {1})", 
				data[1].Index, 
				data[1].Index + data[1].Length);

		}
	}
}


