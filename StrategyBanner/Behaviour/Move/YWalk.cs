#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion
namespace StrategyBanner
{
	public class YWalk : MoveBase
	{
		public YWalk ()
		{
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			if (dir.Y == Globals.positiveDirection)
				pos.Y++;
			else
				pos.Y--;
			base.Move (ref pos,ref dir);
		}
	}
}

