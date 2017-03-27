/*
   Coding             : M.V. Krop
   Date               : 2 juli 2015
   Purpose            : Examples of various Design Patterns
   Intended audience  : Students HBO-ICT of Windesheim University of Applied Sciences
   Copyright          : (c)2015 by M.V. Krop
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
	public class GameWorld
	{
		Texture2D background, pixel;
		Game game;
		GraphicsDeviceManager graphics;

		#region Singleton Pattern
		private static readonly GameWorld instance = new GameWorld();

		private GameWorld ()
		{			

		}

		public static GameWorld Instance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		public void LoadContent(GraphicsDeviceManager g, Game ga)
		{
			graphics = g;
			game = ga;

			background = game.Content.Load<Texture2D>("grass.jpg");

			pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixel.SetData(new Color[] { Color.LightGreen});

	
		}


		public void Update (GameTime gt)
		{
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{
			Rectangle square = new Rectangle ();
			square.X = 0;
			square.Width = 20;
			square.Y = 0;
			square.Height = 20;

			sb.Draw(background, new Vector2(0,0), Color.White);

			// Draw the square
			sb.Draw(pixel, new Vector2(400,300), square, Color.White, 0f, Vector2.Zero, 1f , SpriteEffects.None, 0f); 


		}


	}
}

