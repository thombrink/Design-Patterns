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

namespace DesignPatternsExamples
{
	#region Observer Pattern
	public abstract class GameEntity : IObserver
	{
	#endregion
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixel;
		protected Vector2 position, old_position;
		protected Vector2 direction, old_direction;
		protected IMoveBehaviour moveBehaviour, old_behaviour;

		protected TownCenter towncenter;

		bool flip;

		public GameEntity()
		{
			flip = true;
		}

		public virtual void Update (GameTime gt)
		{
			if(moveBehaviour != null)
				moveBehaviour.Move (ref position, ref direction);
		}

		public virtual void Draw (SpriteBatch sb, GameTime gt)
		{
			sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, 3f , SpriteEffects.None, 0f); 
		}

		#region Observer Pattern
		public void SignalChange()
		{
			if (flip) {
				old_behaviour = moveBehaviour;
				moveBehaviour = new ToTownCenterWalk (towncenter);
				old_position = position;
				old_direction = direction;
				flip = false;
			} else {
				// Herpositioneren op de kaart
				position = old_position;
				direction = old_direction;
				moveBehaviour = old_behaviour;
				flip = true;
			}
		}
		#endregion
	}
}

