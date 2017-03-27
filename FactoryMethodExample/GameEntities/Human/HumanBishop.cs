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
	public class HumanBishop : GameEntity
	{
		public HumanBishop (GraphicsDeviceManager g, Vector2 pos)
		{
			graphics = g;
			position = pos;

			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.Yellow});

			#region Strategy Pattern
			moveBehaviour = new BishopWalk ();
			#endregion
		}

		public override void Update (GameTime gt)
		{
			base.Update (gt);
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{
			base.Draw(sb, gt);
		}
	}
}

