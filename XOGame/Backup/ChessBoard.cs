using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinChess
{
	/// <summary>
	/// Summary description for ChessBoard.
	/// </summary>
	public class ChessBoard : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChessBoard()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// ChessBoard
			// 
			this.Name = "ChessBoard";
			this.Load += new System.EventHandler(this.ChessBoard_Load);
			this.Paint += new PaintEventHandler ( this.OnPaint ) ;

		}
		#endregion

		private void ChessBoard_Load(object sender, System.EventArgs e)
		{
		}

		private void OnPaint ( object sender , PaintEventArgs e )
		{
			Graphics g = e.Graphics ;

			int SquareWidth = this.Size.Width / 8 ;
			int SquareHeight = this.Size.Height / 8 ;

			for ( int i = 0 ; i < 8 ; i++ )
			{
				for ( int j = 0 ; j < 8 ; j++ )
				{
					Rectangle rec = new Rectangle ( SquareWidth * i , SquareHeight * j , SquareWidth , SquareHeight ) ;

					//System.Drawing.TextureBrush t = new TextureBrush ( 
				}
			}
		}

		public void Draw ()
		{
		}
	}
}