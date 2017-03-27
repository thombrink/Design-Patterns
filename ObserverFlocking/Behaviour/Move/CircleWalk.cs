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
	public class CircleWalk : MoveBase
	{
		Vector2 center;
		bool first;

		int degree;
		int radius;

		public CircleWalk (Vector2 absolutePos, int r)
		{
			degree = 0;
			radius = r;
			first = false;
			center = absolutePos;
		}

		public override void Move (GameEntity ge, List<GameEntity>game_elements)
		{
			if (!first) {
				center = ge.position;
				first = true;
			}

			degree++;
			if (degree == 359)
				degree = 0;

			double rad = (Math.PI / 180) * degree;
			ge.position.X = ((float)(Math.Sin (rad))*radius)+center.X;
			ge.position.Y = ((float)(Math.Cos (rad))*radius)+center.Y;
			base.Move (ge, game_elements);
		}
	}
}

