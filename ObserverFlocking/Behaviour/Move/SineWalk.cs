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
using System.Collections.Generic;

#endregion
namespace DesignPatternsExamples
{
	public class SineWalk : MoveBase
	{
		int degree, shift;
		bool first;
		Vector2 offset;
		int length;

		public SineWalk (Vector2 pOffset, int l)
		{
			offset = pOffset;

			degree = 0;
			shift = 0;
			first = true;
			length = l;
		}

		public override void Move (GameEntity ge, List<GameEntity>game_elements)
		{
			double rad;

			if (first) {
				first = false;
				ge.position.X += offset.X;
				ge.position.Y += offset.Y;
			}
			degree++;
			if (degree == 360) {
				degree = 0;
				shift++;
			}
			if (shift == 5) {
				shift = 0;
			}

			rad = (Math.PI / 180) * degree;
			ge.position.X += (float)((Math.Sin (rad)) * length) ;
			ge.position.Y += (float)((Math.Sin (rad+(shift))) * 1.5) ;
			base.Move (ge, game_elements);

		}
	}
}

