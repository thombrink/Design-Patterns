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
	#endregion
}

