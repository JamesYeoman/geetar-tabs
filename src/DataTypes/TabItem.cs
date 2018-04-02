using System;

namespace GeetarTabs
{
	/* Sealed classes cannot be inherited */
	public sealed class TabItem
	{
		public const uint MAX_FRETS = 12;
		public const uint MAX_STRINGS = 6;

		public readonly uint fret;
		public readonly uint fretString;

		public TabItem ( uint _fret, uint _fretString )
		{
			if(_fret > MAX_FRETS || _fretString > MAX_STRINGS )
			{
				throw new ArgumentOutOfRangeException ( );
			}

			this.fret = _fret;
			this.fretString = _fretString;
		}
	}
}
