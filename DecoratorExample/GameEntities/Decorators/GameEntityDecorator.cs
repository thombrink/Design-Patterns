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
	public abstract class GameEntityDecorator : GameEntity
	{
		protected GameEntity gameEntity;
		protected Vector2 decoration_pos;
		protected Texture2D decoration_pixel;


		public void SetGameEntity(GameEntity gameEntity)
		{
			this.gameEntity = gameEntity;
		}

		public override void Update (GameTime gt)
		{
			if (gameEntity != null) {


				gameEntity.Update (gt);
			}
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{
			if (gameEntity != null && decoration_pixel != null) {
				gameEntity.Draw (sb, gt);
				sb.Draw(decoration_pixel, decoration_pos, null, Color.White, 0f, Vector2.Zero, 5f , SpriteEffects.None, 0f); 
			}
		}

	}
	#endregion
}

