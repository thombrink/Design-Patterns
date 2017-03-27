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
	public class PurpleDecorator : GameEntityDecorator
	{

		public PurpleDecorator (GraphicsDeviceManager g)
		{
			pixel = new Texture2D (g.GraphicsDevice, 1, 1);
			pixel.SetData (new Color[] { Color.White });
		}

		public override void Update (GameTime gt)
		{
			if(gameEntity!=null)
				base.Update (gt);
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{

			if (gameEntity != null) {
				decoration_pos.X = gameEntity.position.X - 10;
				decoration_pos.Y = gameEntity.position.Y - 10;
				sb.Draw(pixel, decoration_pos, null, Color.White, 0f, Vector2.Zero, 4f , SpriteEffects.None, 0f); 
				base.Draw (sb, gt);
			}		


		}
	}
}
