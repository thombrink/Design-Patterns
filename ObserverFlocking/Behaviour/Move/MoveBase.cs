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
	public abstract class MoveBase :  IMoveBehaviour
	{
		public MoveBase ()
		{

		}

		public virtual void Move(GameEntity ge, List<GameEntity>game_elements)
		{
		}
	}
}

