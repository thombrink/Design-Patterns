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
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace DesignPatternsExamples
{
	public abstract class GameEntity
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixel;
		protected Vector2 position;

		#region Strategy Pattern
		protected MoveBehaviour moveBehaviour;
		#endregion

		public virtual void Update (GameTime gt)
		{
			#region Strategy Pattern
			moveBehaviour.Move (ref position);
			#endregion
		}

		public virtual void Draw (SpriteBatch sb, GameTime gt)
		{
			sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, Globals.pieceSize /2, SpriteEffects.None, 0f); 
		}
	}

}

