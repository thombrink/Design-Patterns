/*
   Coding             : M. Krop
   Date               : 20 juli 2015
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
	public class Bird : GameEntity
	{
		public Bird (GraphicsDeviceManager g, Vector2 pos, Vector2 vel)
		{
			graphics = g;
			position = pos;
			velocity = vel;


			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.DarkSlateGray});

			moveBehaviour1 = new FlockingFly ();
			moveBehaviour2 = new SineWalk (new Vector2(0,0),5);
		}

		public override void Update (GameTime gt, List<GameEntity> game_elements)
		{
			base.Update (gt, game_elements);
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{
			base.Draw(sb, gt);
		}
	}
}

