using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using GeetarTabs.DataTypes;

namespace GeetarTabs.Utilities
{
	public static class FileUtilities
	{
		/* 
		 * \s* is the regex for all whitespace
		 * and is used because I don't know any other way to ignore whitespace
		 * hence the ugly and hard to read regex
		 */
		const string TABITEM_REGEX = @"\s*\d\s*,\s*\d\s*";
		const string CHORD_CONTENT = @"\s*(\s*\(" + TABITEM_REGEX + @"\)\s*,*)+\s*";
		const string CHORD_REGEX = @"\[" + CHORD_CONTENT + @"\]";

		/// <summary>
		/// Parses the file so you don't have to handle interpretation.
		/// Currently has no error handling so if you forget a try-catch,
		/// don't say I didn't warn you...
		/// </summary>
		/// <param name="path">Absolute file paths only</param>
		public static Queue<List<TabItem>> LoadFile ( string path )
		{
			Queue<List<TabItem>> tab = new Queue<List<TabItem>> ( );

			using ( var reader = new StreamReader ( path ) )
			{
				string file = reader.ReadToEnd ( );
				MatchCollection matchCollection = Regex.Matches ( file, CHORD_REGEX );

				/* Iterate through all of the chords */
				foreach ( Match m in matchCollection )
					tab.Enqueue ( getTabItems ( m.Value ) );
			}

			return tab;
		}

		/// <summary>
		/// Converts a chord definition into a List of TabItem
		/// </summary>
		/// <param name="definition">The contents of a chord</param>
		/// <returns>A chord in the form of a List of TabItem</returns>
		private static List<TabItem> getTabItems ( string definition )
		{
			List<TabItem> curChord = new List<TabItem> ( );

			MatchCollection matchCollection = Regex.Matches ( definition, TABITEM_REGEX );
			foreach ( Match m in matchCollection )
				curChord.Add ( createTabItem ( m.Value.Split(',' ) ) );

			return curChord;
		}

		private static TabItem createTabItem ( string [ ] values )
		{
			for ( int i = 0 ; i < values.Length ; i++ )
				values [ i ] = values [ i ].Trim ( ' ' );

			return new TabItem ( uint.Parse ( values [ 0 ] ), uint.Parse ( values [ 1 ] ) );
		}
	}
}
