using System ;

namespace XOGame
{
	/// <summary>
	/// Summary description for XOGame.
	/// </summary>
	public class XOGame
	{
		public enum EvaluationResult
		{
			Win = 1 , Draw = 0 , Loss  = -1 , None = -2
		}

		public int[,] Board ;

		public XOGame()
		{
			this.Board = new int[3,3] ;
			this.Reset () ;
		}

		public void Reset ()
		{
			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
					this.Board[i,j] = -1 ;
		}

		public void MiniMax ( out int x , out int y )
		{
			EvaluationResult TopEvaluation = EvaluationResult.None ;
			int TopX = -1 , TopY = -1 ;
			bool Initialized = false ;

			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
				{
					if ( this.Board[i,j] == -1 )
					{
						this.Board[i,j] = 1 ;

						EvaluationResult Evaluation = this.MiniMax ( false ) ;

						if ( !Initialized )
						{
							TopEvaluation = Evaluation ;
							TopX = i ; TopY = j ;
							Initialized = true ;
						}
						else
						{
							if ( Evaluation > TopEvaluation )
							{
								TopEvaluation = Evaluation ;
								TopX = i ; TopY = j ;
							}
						}

						this.Board[i,j] = -1 ;
					}
				}

			x = TopX ;
			y = TopY ;
		}

		public EvaluationResult MiniMax ( bool IsComputer )
		{
			EvaluationResult TopEvaluation = EvaluationResult.None ;
			EvaluationResult Evaluation = this.Evaluate () ;
			bool Initialized = false ;

			if ( Evaluation != EvaluationResult.None ) return ( Evaluation ) ;
			
			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
				{
					if ( this.Board[i,j] == -1 )
					{
						this.Board[i,j] = IsComputer ? 1 : 0 ;

						Evaluation = this.MiniMax ( !IsComputer ) ;

						if ( !Initialized )
						{
							TopEvaluation = Evaluation ;
							Initialized = true ;
						}
						else
						{
							if ( !IsComputer && Evaluation < TopEvaluation ) TopEvaluation = Evaluation ;
							else if ( IsComputer && Evaluation > TopEvaluation ) TopEvaluation = Evaluation ;
						}

						this.Board[i,j] = -1 ;
					}
			}

			return ( TopEvaluation ) ;
		}

		public EvaluationResult Evaluate ()
		{
			for ( int i = 0 ; i < 3 ; i++ )
			{
				if ( this.Board[i,0] == this.Board[i,1] &&
					 this.Board[i,1] == this.Board[i,2] &&
					 this.Board[i,0] != -1 )
				{
					return ( this.Board[i,0] == 1 ? EvaluationResult.Win :
													EvaluationResult.Loss ) ;
				}

				if ( this.Board[0,i] == this.Board[1,i] &&
					 this.Board[1,i] == this.Board[2,i] &&
					 this.Board[0,i] != -1 )
				{
					return ( this.Board[0,i] == 1 ? EvaluationResult.Win :
													EvaluationResult.Loss ) ;
				}
			}

			if ( this.Board[0,0] == this.Board[1,1] &&
				 this.Board[1,1] == this.Board[2,2] &&
				 this.Board[0,0] != -1 )
			{
				return ( this.Board[0,0] == 1 ? EvaluationResult.Win :
												EvaluationResult.Loss ) ;
			}

			if ( this.Board[0,2] == this.Board[1,1] &&
				 this.Board[1,1] == this.Board[2,0] &&
				 this.Board[0,2] != -1 )
			{
				return ( this.Board[0,2] == 1 ? EvaluationResult.Win :
												EvaluationResult.Loss ) ;
			}

			for ( int i = 0 ; i < 3 ; i++ )
				for ( int j = 0 ; j < 3 ; j++ )
					if ( this.Board[i,j] == -1 ) return ( EvaluationResult.None ) ;

			return ( EvaluationResult.Draw ) ;
		}
	}
}