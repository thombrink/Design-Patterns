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
	public abstract class GameEntity
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixel;
		protected Vector2 direction;

		public Vector2 position;

		protected MoveBehaviour moveBehaviour;

		public virtual void Update (GameTime gt)
		{
			if(moveBehaviour != null)
				moveBehaviour.Move (ref position, ref direction);
		}

		public virtual void Draw (SpriteBatch sb, GameTime gt)
		{
			if(pixel!=null)
				sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, 10f , SpriteEffects.None, 0f); 
		}
	}
}

