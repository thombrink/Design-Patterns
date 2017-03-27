/*
   Coding             : M. Krop
   Date               : 31 juli 2015
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
	public class TowerWalk : MoveBase
	{
		public TowerWalk ()
		{
		}

		public override void Move (ref Vector2 pos)
		{
			base.Move (ref pos);
		}
	}
	#endregion
}

