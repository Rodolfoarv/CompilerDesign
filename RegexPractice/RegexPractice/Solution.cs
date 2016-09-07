using System;
using System.IO;
using System.Text.RegularExpressions;

public class Solution
{
	public Solution ()
	{
	
	}

	public static void Main(){
		string pattern = @"([a-zA-Z]+) (\d+)";
		Match result = Regex.Match("June 24", pattern);


		if (result.Success) {
			Console.WriteLine("Match at index [{0}, {1})", 
				result.Index,
				result.Index + result.Length);

			Console.WriteLine("Match: {0}", result.Value);

			while (result.Success) {
				Console.WriteLine("Match: {0}", result.Value);
				result = result.NextMatch();
			}
		}
	}
}


