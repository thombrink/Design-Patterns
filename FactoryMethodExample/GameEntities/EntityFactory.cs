/*
   Coding             : M. Krop
   Date               : 3 augustus 2015
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
	#region Factory Method Pattern
	public abstract class EntityFactory
	{
		public abstract GameEntity createEntity (string type, GraphicsDeviceManager g, Vector2 pos);
	}
	#endregion


	#region Factory Method Pattern
	public class OrcEntityFactory : EntityFactory
	{
		public override GameEntity createEntity (string type, GraphicsDeviceManager g, Vector2 pos)
		{
			GameEntity entity = null;

			if (type.Equals ("bishop"))
				entity = new OrcBishop (g, pos);
			else if (type.Equals ("horse"))
				entity = new OrcHorse (g, pos);
			else if (type.Equals ("king"))
				entity = new OrcKing (g, pos);
			else if (type.Equals ("pawn"))
				entity = new OrcPawn (g, pos);
			else if (type.Equals ("queen"))
				entity = new OrcQueen (g, pos);
			else if (type.Equals ("tower"))
				entity = new OrcTower (g, pos);

			return entity;
		}
	}
	#endregion

	#region Factory Method Pattern
	public class HumanEntityFactory : EntityFactory
	{
		public override GameEntity createEntity (string type, GraphicsDeviceManager g, Vector2 pos)
		{
			GameEntity entity = null;

			if (type.Equals ("bishop"))
				entity = new HumanBishop (g, pos);
			else if (type.Equals ("horse"))
				entity = new HumanHorse (g, pos);
			else if (type.Equals ("king"))
				entity = new HumanKing (g, pos);
			else if (type.Equals ("pawn"))
				entity = new HumanPawn (g, pos);
			else if (type.Equals ("queen"))
				entity = new HumanQueen (g, pos);
			else if (type.Equals ("tower"))
				entity = new HumanTower (g, pos);

			return entity;
		}
	}
	#endregion
}

