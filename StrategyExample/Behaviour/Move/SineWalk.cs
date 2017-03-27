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
	#region Strategy Pattern
	public class SineWalk : MoveBase
	{
		int degree;
		Vector2 center;

		public SineWalk (Vector2 absolutePos)
		{
			center = absolutePos;
			degree = 0;
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			degree++;
			if (degree == 359)
				degree = 0;

			double rad = (Math.PI / 180) * degree;
			pos.X = ((float)(Math.Sin (rad))*50)+center.X;
			base.Move (ref pos,ref dir);
		}
	}
	#endregion
}

