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
	public class CosineWalk : MoveBase
	{
		int degree;
		bool first;
		Vector2 center;
		int length;

		public CosineWalk (Vector2 absolutePos, int l)
		{
			center = absolutePos;
			degree = 0;
			first = false;
			length = l;
		}

		public override void Move (ref Vector2 pos, ref Vector2 dir)
		{
			if (!first) {
				center = pos;
				first = true;
			}

			degree++;
			if (degree == 359)
				degree = 0;

			double rad = (Math.PI / 180) * degree;
			pos.Y = ((float)(Math.Sin (rad))*length)+center.Y;
			base.Move (ref pos,ref dir);
		}
	}
}

