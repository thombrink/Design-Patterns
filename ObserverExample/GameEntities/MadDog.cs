/*
   Coding             : M. Krop
   Date               : 8 juli 2015
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
	public class MadDog : GameEntity
	{
		public MadDog (GraphicsDeviceManager g, Vector2 pos, Vector2 dir, TownCenter tc)
		{
			graphics = g;
			position = pos;
			direction = dir;
			towncenter = tc;

			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.LightBlue});

			moveBehaviour = new SineWalk (position, 100);
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

