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
	public abstract class MoveBase :  MoveBehaviour
	{
		public MoveBase ()
		{

		}

		public virtual void Move(ref Vector2 pos, ref Vector2 dir)
		{
			if (pos.X >= Globals.right)
				dir.X = -dir.X;
			else if (pos.X <= Globals.left)
				dir.X = -dir.X;

			if (pos.Y >= Globals.bottom)
				dir.Y = -dir.Y;
			else if (pos.Y <= Globals.top)
				dir.Y = -dir.Y;

		}
	}
}

