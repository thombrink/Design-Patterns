/*
   Coding             : M.V. Krop
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

//			game_elements.Add (new Knight (graphics, new Vector2 (0,30), new Vector2(1,1)));
//			game_elements.Add (new Horseman (graphics, new Vector2(200,30), new Vector2(1,1)));

			Random rnd = new Random ();

			int xpos, ypos, xdir, ydir ,type;
			for (int i = 0; i<=1000; i++) {
				xpos = rnd.Next (Globals.left, Globals.right);
				ypos = rnd.Next (Globals.top, Globals.bottom);
				xdir = 1;
				ydir = 1;
				type = rnd.Next (1, 4 + 1);
				switch (type) {
				case 1:
					game_elements.Add (new Knight (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				case 2:
					game_elements.Add (new Horseman (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				case 3:
					game_elements.Add (new Bishop (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				case 4:
					game_elements.Add (new Clockworkbeast (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				}
				System.Threading.Thread.Sleep(1);
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

			foreach (GameEntity ge in game_elements) {
				ge.Draw (sb, gt);

			}

		}



	}
}

