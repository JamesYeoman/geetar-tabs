using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GeetarTabs.Utilities
{
	public static class FileUtilities
	{
		/// <summary>
		/// Parses the file so you don't have to handle interpretation
		/// </summary>
		/// <param name="path">Absolute file paths only</param>
		// <exception cref="System.FormatException">Thrown if the file has a Syntax Error</exception>
		public static Queue<List<TabItem>> LoadFile ( string path )
		{
			Queue<List<TabItem>> tab = new Queue<List<TabItem>> ( );

			//try
			//{
			using ( var reader = new StreamReader ( path ) )
			{
				string currentLine;
				while ( ( currentLine = reader.ReadLine ( ) ) != null )
				{
					const string regex = @"\[.*\]";
					MatchCollection matchCollection = Regex.Matches ( currentLine, regex );
					foreach ( Match m in matchCollection )
					{
						tab.Enqueue ( getTabItems ( m.Value ) );
					}
				}
			}

			return tab;
			//}
			//catch ( FormatException ex )
			//{

			//}
		}

		private static List<TabItem> getTabItems(string definition)
		{
			const string regex = @"\d\s*,\s*\d";
			List<TabItem> curChord = new List<TabItem>();
			MatchCollection matchCollection = Regex.Matches ( definition, regex );
			string [ ] strings;
			foreach(Match m in matchCollection)
			{
				strings = m.Value.Split ( ',' );
				for(int i = 0 ; i < strings.Length ; i++ )
				{
					strings [ i ] = strings [ i ].Trim ( ' ' );
				}
				curChord.Add
				(
					new TabItem ( uint.Parse ( strings [ 0 ] ), uint.Parse ( strings [ 1 ] ) )
				);
			}

			return curChord;
		}
	}
}
