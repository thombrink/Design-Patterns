/*
   Coding             : M. Krop
   Date               : 1 augustus 2015
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
	#region Simple Factory
	public class EntityFactory
	{
		public GameEntity createEntity (string type, GraphicsDeviceManager g, Vector2 pos)
		{
			GameEntity entity = null;

			if (type.Equals ("bishop"))
				entity = new Bishop (g, pos);
			else if (type.Equals ("horse"))
				entity = new Horse (g, pos);
			else if (type.Equals ("king"))
				entity = new King (g, pos);
			else if (type.Equals ("pawn"))
				entity = new Pawn (g, pos);
			else if (type.Equals ("queen"))
				entity = new Queen (g, pos);
			else if (type.Equals ("tower"))
				entity = new Tower (g, pos);

			return entity;
		}
	}
	#endregion
}

