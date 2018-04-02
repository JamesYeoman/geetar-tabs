using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

using GeetarTabs.DataTypes;
using GeetarTabs.Utilities;

namespace GeetarTabs
{
	public partial class FormMain : Form
	{
		#region Fields
		protected OpenFileDialog openFile;
		private Queue<List<TabItem>> tabs;
		#endregion
		#region Constants
		const string OPEN_FILE_TITLE = "Choose File To Open";
		const string ERR_MSG = "Invalid Syntax";
		const string FILE_FILTER = "GeetarTabFile files (*.gtf)|*.gtf";
		#endregion

		public FormMain ( )
		{
			InitializeComponent ( );
			openFile = new OpenFileDialog ( );
		}

		private void fileOpenClickHandler ( object sender, EventArgs e )
		{
			initOpenFile ( );

			if ( openFile.ShowDialog ( ) == DialogResult.OK )
			{
				tabs = FileUtilities.LoadFile ( openFile.FileName );

				bool isEmpty = tabs.Count == 0;
				int currentChord = 1;
				while ( !isEmpty )
				{
					List<TabItem> curChord = tabs.Dequeue ( );
					string curToString = "Chord " + currentChord + "\n";

					foreach ( TabItem tabItem in curChord )
						curToString += tabItem + "\n";

					MessageBox.Show ( curToString, "Debug", MessageBoxButtons.OK );

					currentChord++;
					isEmpty = tabs.Count == 0;
				}
			}
		}

		private void initOpenFile ( )
		{
			this.openFile.Reset ( );
			this.openFile.Title = OPEN_FILE_TITLE;
			this.openFile.Multiselect = false;
			this.openFile.CheckFileExists = true;
			this.openFile.CheckPathExists = true;
			this.openFile.DereferenceLinks = true;
			this.openFile.Filter = FILE_FILTER;
		}
	}
}
