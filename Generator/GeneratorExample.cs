using System;
using System.Collections.Generic;

public class Pow2Generator {
	public IEnumerable<int> Start() {
		var c = 1;
		while (c < 1000000) {
			yield return c;
			c *= 2; 
		}
	}
}

public class GeneratorExample{

	public static void Main(String[] args) {

		IEnumerable<int> i = new Pow2Generator ().Start ();
		var e = i.GetEnumerator ();
		while (e.MoveNext ()) {
			Console.WriteLine (e.Current);
		}

	}

}


