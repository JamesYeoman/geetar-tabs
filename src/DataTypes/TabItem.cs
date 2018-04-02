using System;

namespace GeetarTabs.DataTypes
{
	/* Sealed classes cannot be inherited */
	public sealed class TabItem
	{
		public const uint MAX_FRETS = 12;
		public const uint MAX_STRINGS = 6;

		public readonly uint fret;
		public readonly uint fretString;

		public TabItem ( uint _fretString, uint _fret )
		{
			if ( _fret > MAX_FRETS || _fretString > MAX_STRINGS )
			{
				throw new ArgumentOutOfRangeException ( );
			}

			this.fret = _fret;
			this.fretString = _fretString;
		}

		public override bool Equals ( object obj )
		{
			TabItem tabItem = null;
			if ( obj is TabItem )
				tabItem = ( TabItem ) obj;

			return tabItem != null && fret == tabItem.fret && fretString == tabItem.fretString;
		}

		public override string ToString ( )
		{
			return "TabItem:" + "\n\t" +
				"String: " + fretString.ToString ( ) + "\n\t" +
				"Fret: " + fret.ToString ( ) ;
		}
	}
}
