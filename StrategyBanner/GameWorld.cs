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
namespace StrategyBanner
{
	public class GameWorld
	{
		GraphicsDeviceManager graphics;
		Texture2D background;
		Game game;

		List<GameEntity> game_elements = new List<GameEntity> ();

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

		public void LoadContent(GraphicsDeviceManager g, Game ga)
		{
			graphics = g;
			graphics.IsFullScreen = false;
			game = ga;

			background = game.Content.Load<Texture2D>("grass.jpg");


			// game_element: graphicsdevice, position vector, direction vector, rotation_offset

			for (int j=0; j<=15; j++) {
				for (int i = 0; i<=80; i++) {
					game_elements.Add (new Red (graphics, new Vector2 (400 + (i*Globals.pixelspace), 200 + (j*Globals.pixelspace)), new Vector2 (1, 1), (i * 5) % Globals.maxdegree));

				}
			}

			for (int j=15; j<=30; j++) {
				for (int i = 0; i<=80; i++) {
					game_elements.Add (new White (graphics, new Vector2 (400 + (i*Globals.pixelspace), 200 + (j*Globals.pixelspace)), new Vector2 (1, 1), (i * 5) % Globals.maxdegree));

				}
			}

			for (int j=30; j<=45; j++) {
				for (int i = 0; i<=80; i++) {
					game_elements.Add (new Blue (graphics, new Vector2 (400 + (i*Globals.pixelspace), 200 + (j*Globals.pixelspace)), new Vector2 (1, 1), (i * 5) % Globals.maxdegree));

				}
			}

		}


		public void Update (GameTime gt)
		{

			foreach (GameEntity ge in game_elements)
				ge.Update (gt);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);

			foreach (GameEntity ge in game_elements) 
				ge.Draw (sb, gt);

		}


	}
}

