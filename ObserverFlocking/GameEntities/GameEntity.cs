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
		public Vector2 position;
		public Vector2 velocity;
		protected IMoveBehaviour moveBehaviour1, moveBehaviour2;



		public GameEntity()
		{
			velocity = new Vector2 (0, 0);
		}

		public virtual void Update (GameTime gt, List<GameEntity> game_elements)
		{
			if(moveBehaviour1 != null)
			{
				moveBehaviour1.Move (this, game_elements);
			}
			if(moveBehaviour2 != null)
			{
				moveBehaviour2.Move (this, game_elements);
			}
		}

		public virtual void Draw (SpriteBatch sb, GameTime gt)
		{
			sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, 3f , SpriteEffects.None, 0f); 
		}

	
	}

}

