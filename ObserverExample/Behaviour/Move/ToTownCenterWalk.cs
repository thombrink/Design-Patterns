/*
   Coding             : M. Krop
   Date               : 2 juli 2015
   Purpose            : Examples of various Design Patterns
   Intended audience  : Students HBO-ICT of Windesheim University of Applied Sciences
   Copyright          : (c)2015 by M. Krop
*/

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
#endregion

namespace DesignPatternsExamples
{
	public class ToTownCenterWalk : MoveBase
	{
		TownCenter tc;

		public ToTownCenterWalk (TownCenter towncenter)
		{
			tc = towncenter;
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			float deltax, deltay;

			deltax = tc.position.X - pos.X;
			deltay = tc.position.Y - pos.Y;

			if (Math.Abs(deltax) > 5 || Math.Abs(deltay) > 5) {
				pos.X += 2*(deltax/70);
				pos.Y += 2*(deltay/70);
			}
			base.Move (ref pos,ref dir);
		}
	}
}

