using System ;
using System.Drawing ;
using System.Windows.Forms ;

namespace XOGame
{
	/// <summary>
	/// Summary description for XoGameGui.
	/// </summary>
	public class XoGameGui
	{
		private Form WinForm ;
		private Button[,] Buttons ;
		private XOGame Game ;

		public XoGameGui ( Form WinForm )
		{
			this.WinForm = WinForm ;
			this.Buttons = new Button[3,3] ;
			this.Game = new XOGame () ;
		}

		public void Initialize ()
		{
			this.WinForm.Size = new Size ( 240 , 265 ) ;

			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
				{
					this.Buttons[i,j] = new Button () ;
					this.Buttons[i,j].Text = "" ;
					this.Buttons[i,j].Location = new Point ( 30 + 60 * j , 30 + 60 * i ) ;
					this.Buttons[i,j].Size = new Size ( 60 , 60 ) ;
					this.Buttons[i,j].FlatStyle = FlatStyle.Popup ;
					this.Buttons[i,j].Font = new Font ( "" , 20 , FontStyle.Bold ) ;
					this.Buttons[i,j].Tag = new Point ( i , j ) ;
					this.Buttons[i,j].Click += new EventHandler ( this.OnButtonClick ) ;
					this.WinForm.Controls.Add ( this.Buttons[i,j] ) ;
				}
		}

		private void OnButtonClick ( object sender , System.EventArgs e )
		{
			XOGame.EvaluationResult Eval = this.Game.Evaluate () ;

			int X , Y ;

			Button button = ( Button ) sender ;

			button.Text = "O" ;
			button.Enabled = false ;

			Point point = ( Point ) button.Tag ;

			this.Game.Board[point.X,point.Y] = 0 ;

			this.Game.MiniMax ( out X , out Y ) ;

			Eval = this.Game.Evaluate () ;

			switch ( Eval )
			{
				case XOGame.EvaluationResult.Win :
					MessageBox.Show ( "Computer Wins." ) ;
					break ;
				case XOGame.EvaluationResult.Loss :
					MessageBox.Show ( "You Win." ) ;
					break ;
				case XOGame.EvaluationResult.Draw :
					MessageBox.Show ( "Draw." ) ;
					break ;
				default :
					break ;
			}

			if ( Eval != XOGame.EvaluationResult.None )
			{
				this.Reset () ;
			}

			if ( X != -1 )
			{
				this.Game.Board[X,Y] = 1 ;
				this.Buttons[X,Y].Text = "X" ;
				this.Buttons[X,Y].Enabled = false ;

				Eval = this.Game.Evaluate () ;

				switch ( Eval )
				{
					case XOGame.EvaluationResult.Win :
						MessageBox.Show ( "Computer Wins." ) ;
						break ;
					case XOGame.EvaluationResult.Loss :
						MessageBox.Show ( "You Win." ) ;
						break ;
					case XOGame.EvaluationResult.Draw :
						MessageBox.Show ( "Draw." ) ;
						break ;
					default :
						break ;
				}

				if ( Eval != XOGame.EvaluationResult.None )
				{
					this.Reset () ;
				}
			}
			else
			{
				this.Reset () ;
				return ;
			}
		}

		private void Reset ()
		{
			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
				{
					this.Buttons[i,j].Text = "" ;
					this.Buttons[i,j].Enabled = true ;
				}

			this.Game.Reset () ;
		}
	}
}