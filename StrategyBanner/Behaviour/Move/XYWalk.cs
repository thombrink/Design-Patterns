#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion
namespace StrategyBanner
{
	public class XYWalk : MoveBase
	{
		public XYWalk ()
		{
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			if (dir.X == Globals.positiveDirection)
				pos.X++;
			else
				pos.X--;
			if (dir.Y == Globals.positiveDirection)
				pos.Y++;
			else
				pos.Y--;

			base.Move (ref pos,ref dir);
		}
	}
}

