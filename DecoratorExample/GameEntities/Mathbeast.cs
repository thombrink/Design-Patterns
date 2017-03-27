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
	public class Mathbeast : GameEntity
	{

		public Mathbeast (GraphicsDeviceManager g, Vector2 pos, Vector2 dir)
		{
			graphics = g;
			position = pos;
			direction = dir;

			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.LightGreen});

			moveBehaviour = new CosineWalk (position);

		}

		public override void Update (GameTime gt)
		{
			if(moveBehaviour!=null && pixel != null)
				base.Update (gt);
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{
			if(moveBehaviour!=null && pixel != null)
				base.Draw(sb, gt);
		}


	}
}

