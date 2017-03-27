/*
   Coding             : M. Krop
   Date               : 6 juli 2015
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
	#region Decorator Pattern
	public class RedDecorator : GameEntityDecorator
	{

		public RedDecorator (GraphicsDeviceManager g)
		{
			decoration_pixel = new Texture2D (g.GraphicsDevice, 1, 1);
			decoration_pixel.SetData (new Color[] { Color.Red});


		}

		public override void Update (GameTime gt)
		{
			if (gameEntity != null) {
				decoration_pos.X = gameEntity.position.X + 10;
				decoration_pos.Y = gameEntity.position.Y + 10;
				position = gameEntity.position;


				base.Update (gt);
			}
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{

			if (gameEntity != null) {

				base.Draw (sb, gt);
			}		


		}
	}
	#endregion
}
