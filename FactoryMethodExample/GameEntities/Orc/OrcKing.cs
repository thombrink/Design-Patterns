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
////using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion


namespace DesignPatternsExamples
{
	public class OrcKing : GameEntity
	{
		Texture2D orcMarkPixel;

		public OrcKing (GraphicsDeviceManager g, Vector2 pos)
		{
			graphics = g;
			position = pos;

		
			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.Red });

			orcMarkPixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			orcMarkPixel.SetData(new Color[] { Color.LawnGreen});

			#region Strategy Pattern
			moveBehaviour = new KingWalk ();
			#endregion
		}

		public override void Update (GameTime gt)
		{
			base.Update (gt);
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{
			Vector2 tempPos = position;
			tempPos.X += 24;
			tempPos.Y += 24;
			base.Draw(sb, gt);
			sb.Draw(orcMarkPixel, tempPos, null, Color.White, 0f, Vector2.Zero, 16, SpriteEffects.None, 0f); 
		}
	}
}

