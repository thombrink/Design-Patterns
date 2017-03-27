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
	#region Observer Pattern
	public class TownCenter : ISubject
	#endregion
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixel;
		public Vector2 position;
		protected Vector2 direction;
		protected IMoveBehaviour moveBehaviour;

		#region Observer Pattern
		protected List<IObserver> observers;
		#endregion

		KeyboardState previousState;


		public TownCenter (GraphicsDeviceManager g, Vector2 pos, Vector2 dir)
		{
			graphics = g;
			position = pos;
			direction = dir;
		
			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.Red });

			moveBehaviour = new CircleWalk (position, 280);

			#region Observer Pattern
			observers = new List<IObserver>();
			#endregion

			previousState = Keyboard.GetState();
		}

		public void Update (GameTime gt)
		{
			UpdateInput ();
			moveBehaviour.Move (ref position, ref direction);
		}

		private void UpdateInput()
		{
			KeyboardState state = Keyboard.GetState();
			int type;

			if (state.IsKeyDown(Keys.S) & !previousState.IsKeyDown(Keys.S))
				#region Observer Pattern
				NotifyObservers();
				#endregion
			if (state.IsKeyDown (Keys.B) & !previousState.IsKeyDown (Keys.B)) {
				type = new Random ().Next (1, 7 + 1);
				switch (type) {
				case 1:
					moveBehaviour = new CircleWalk (position,80);
					break;			
				case 2:
					moveBehaviour = new CosineWalk (position, 200);
					break;			
				case 3:
					moveBehaviour = new SineWalk (position, 200);
					break;			
				case 4:
					moveBehaviour = new XWalk ();
					break;			
				case 5:
					moveBehaviour = new YWalk ();
					break;			
				case 6:
					moveBehaviour = new XYWalk ();
					break;			
				case 7:
					moveBehaviour = new NoWalk ();
					break;			
				}
			}

			previousState = state;		
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{
			sb.Draw(pixel, position, null, Color.White, 0f, Vector2.Zero, 10f , SpriteEffects.None, 0f); 
		}

		// Implementing the ISubject interface

		#region Observer Pattern
		public void RegisterObserver (IObserver o)
		{
			observers.Add (o);
		}

		public void RemoveObserver (IObserver o)
		{
			observers.Remove(o);
		}

		public void NotifyObservers()
		{
			foreach (IObserver o in observers)
				o.SignalChange ();
		}
		#endregion
	}
}

