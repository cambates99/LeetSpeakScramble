using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Scramble
{
    public class LeetScramble
    {
        /// <summary>
        /// Allows for multiple inputs via the comand line
        /// </summary>
        /// <param name="args">inputed string from console</param>
        static void Main(string[] args)
        {
            LeetScramble ls = new LeetScramble();

            string line = string.Empty;
            while(true)
            {
                line = Console.ReadLine();
                if (line != string.Empty)
                {
                    ls.Encode(line);
                }
            }
        }

        /// <summary>
        /// Transcribes each word in a string such that it has the first letter, number of characters, and last letter. i.e. hello, world -> h2w, w3d 
        /// </summary>
        /// <param name="input">The string to be 'encoded'</param>
        /// <returns>the transcribed string</returns>
        public string Encode(string input)
        {
            string pattern = @"(\w+|[^a-zA-Z]+)";
            Regex regex = new Regex(pattern);

            string replaced = regex.Replace(input, match => ReplaceMatch(match));
            return Display(replaced);
        }

        /// <summary>
        /// replaces the matched word with its leet transcribed version
        /// </summary>
        /// <param name="match">the regex match</param>
        /// <returns>the replaced string with the first letter followed by the number of distinct char's then the last letter</returns>
        private string ReplaceMatch(Match match)
        {
            string value = match.Value;

            if (char.IsLetter(value[0]))
            {
                if (value.Length == 1)
                {
                    return value;
                }
                else if (value.Length == 2)
                {
                    return $"{value[0]}{"0"}{value[value.Length - 1]}";
                }
                else if (value.Length == 3)
                {
                    return $"{value[0]}{"1"}{value[value.Length - 1]}";
                }
                else
                {
                    int distinctChars = GetDistrinctCharCount(value);
                    return $"{value[0]}{distinctChars}{value[value.Length - 1]}";
                }
            }

            return value;
        }


        /// <summary>
        /// Finds the number of distinct characters between first and last letter of a string
        /// </summary>
        /// <param name="str">the string to be used</param>
        /// <returns>a count of how many distinct characters</returns>
        private int GetDistrinctCharCount(string str)
        {
            HashSet<char> distinctChars = new HashSet<char>();

            // ignore first and last letter
            for(int i = 1; i < str.Length - 1; i++)
            {
                distinctChars.Add(str[i]);
            }
            return distinctChars.Count();   
        }

        /// <summary>
        /// Displays the transcribed line
        /// </summary>
        /// <param name="str">the string that has been transcribed</param>
        private string Display(string str)
        {
            Console.WriteLine("Transcribed Line: " + str);
            return str;
        }
    }
}