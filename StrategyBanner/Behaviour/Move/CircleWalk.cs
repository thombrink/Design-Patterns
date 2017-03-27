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
namespace StrategyBanner
{
	public class CircleWalk : MoveBase
	{
		Vector2 center;

		int degree;

		public CircleWalk (Vector2 absolutePos)
		{
			degree = 0;
			center = absolutePos;
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			degree++;
			if (degree == 359)
				degree = 0;

			double rad = (Math.PI / 180) * degree;
			pos.X = ((float)(Math.Sin (rad))*50)+center.X;
			pos.Y = ((float)(Math.Cos (rad))*50)+center.Y;
			base.Move (ref pos,ref dir);
		}
	}
}

