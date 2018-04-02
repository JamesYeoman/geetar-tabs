using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

namespace GeetarTabs
{
	public partial class FormMain : Form
	{
		#region Fields
		protected OpenFileDialog openFile;
		private string currentFile;
		private List<List<TabItem>> tabs;
		#endregion
		#region Constants
		const string OPEN_FILE_TITLE = "Choose File To Open";
		const string ERR_MSG = "Invalid Syntax";
		const string FILE_FILTER = "*.txt";
		#endregion

		public FormMain ( )
		{
			InitializeComponent ( );
		}

		private void openToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			initOpenFile ( );

			if ( openFile.ShowDialog ( ) == DialogResult.OK)
			{
				currentFile = openFile.FileName;
				using ( StreamReader reader = new StreamReader ( openFile.OpenFile() ))
				{

					try
					{
						while ( !reader.EndOfStream )
						{
							
						}
					}
					catch(Exception ex)
					{
						if(ex is InvalidDataException)
						{
							MessageBox.Show ( "Uwu you made a fuckywucky in your file", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error );
						}
					}
				}
			}
		}

		private void initOpenFile()
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
