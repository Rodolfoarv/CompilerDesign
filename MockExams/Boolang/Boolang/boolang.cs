using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Boolang
{
  //---------------------------------------------------------------
  class SyntaxError: Exception {}
  //---------------------------------------------------------------

  enum Token {
    AND, OR, NOT, PAR_LEFT, PAR_RIGHT, ZERO, ONE, ILLEGAL_CHAR,EOF
  }

  //---------------------------------------------------------------

  class Scanner {
    readonly string input;
    static readonly Regex regex = new Regex(
      @"                             
                (?<And>             [&] )
              | (?<Or>              [|] )
              | (?<Not>             [!] )
              | (?<ParLeft>         [(] )
              | (?<ParRight>        [)] )
              | (?<Zero>            [0] )
              | (?<One>             [1] )
              | (?<Whitespace>      \s )
              | (?<Other>            . )
            ", 
            RegexOptions.IgnorePatternWhitespace 
                | RegexOptions.Compiled                
            );          
    static readonly IDictionary<string, Token> regexLabels =
      new Dictionary<string, Token>() {
      {"And", Token.AND},
      {"Or", Token.OR},
      {"Not", Token.NOT},
      {"ParLeft", Token.PAR_LEFT},
      {"ParRight", Token.PAR_RIGHT},
      {"Zero", Token.ZERO},
      {"One", Token.ONE}
    };
    public Scanner(string input) {
      this.input = input;
    }

    public IEnumerable<Token> Start() {
      foreach (Match m in regex.Matches(input)) {
        if (m.Groups["WhiteSpace"].Length > 0) {
          // Skip spaces.
        } else if (m.Groups["Other"].Length > 0) {
          yield return Token.ILLEGAL_CHAR;
        } else {
          foreach (var name in regexLabels.Keys) {
            if (m.Groups[name].Length > 0) {
              yield return regexLabels[name];
              break;
            }
          }
        }
      }
      yield return Token.EOF; 
    }

    //---------------------------------------------------------------
    class Driver {
      public static void Main(string[] args) {
        try {
          var inputPath = args[0];
          var input = File.ReadAllText(inputPath);

          Console.WriteLine(String.Format(
            "===== Tokens from: \"{0}\" =====", inputPath)
          );
          var count = 1;
          foreach (var tok in new Scanner(input).Start()) {
            Console.WriteLine(String.Format("[{0}] {1}",
              count++, tok)
            );
          }

        } catch (FileNotFoundException e) {
          Console.Error.WriteLine(e.Message);
          Environment.Exit(1);
        }
      }
    } 


      
  }

  
}

