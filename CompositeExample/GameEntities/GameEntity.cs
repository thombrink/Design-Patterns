/*
   Coding             : M. Krop
   Date               : 21 juli 2015
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
	#region Composite Pattern
	public abstract class GameEntity
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixel;
		public Vector2 position;
		public Vector2 direction;
		public MoveBehaviour moveBehaviour;
		public MoveBehaviour oldBehaviour;
//		public int Left, Top, Right, Bottom;

		public virtual void Update (GameTime gt)
		{
			if(moveBehaviour != null)
				moveBehaviour.Move (ref position, ref direction);
		}

		public virtual void Draw (SpriteBatch sb, GameTime gt)
		{
			sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, 3f , SpriteEffects.None, 0f); 
		}

		public virtual void Translate (Vector2 translateVector)
		{
			position.X += (int)translateVector.X;
			position.Y += (int)translateVector.Y;

		}

		public virtual bool ClickInArea(Vector2 pos)
		{
			throw new MissingMethodException ();
		}


		public virtual void Add (GameEntity ge)
		{
			throw new MissingMethodException ();
		}

		public virtual void Remove (GameEntity ge)
		{
			throw new MissingMethodException ();
		}

		public virtual GameEntity GetChild (int i)
		{
			throw new MissingMethodException ();
		}


	}
	#endregion
}

