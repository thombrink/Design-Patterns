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


namespace StrategyBanner
{
	public class Blue : GameEntity
	{
		public Blue (GraphicsDeviceManager g, Vector2 pos, Vector2 dir, int offset)
		{
			graphics = g;
			position = pos;
			direction = dir;

			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.Cyan });

			moveBehaviour = new CosineWalk (position, offset);

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

