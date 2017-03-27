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
	public class GameWorld
	{
		GraphicsDeviceManager graphics;
		Texture2D background, tekst;

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
			Bird bird;


			background = game.Content.Load<Texture2D>("beach.jpg");
			tekst = game.Content.Load<Texture2D>("tekst.png");


			int xpos, ypos, type;
			float xvel, yvel;
			const int Xoffset = 400;
			const int Yoffset = 200;
			Random rnd = new Random ();
			for (int i = 0; i<200; i++) {
				xpos = rnd.Next (0,200);
				ypos = rnd.Next (0, 200);

				xvel = 0f;
				yvel = 0f;
				type = new Random ().Next (1, 1 + 1);
				switch (type) {
				case 1:
					bird = new Bird (graphics, new Vector2 (xpos, ypos), new Vector2 (xvel, yvel));
					game_elements.Add (bird);
					break;
				}
				System.Threading.Thread.Sleep(1);
			}
		}


		public void Update (GameTime gt)
		{

			foreach (GameEntity ge in game_elements)
				ge.Update (gt, game_elements);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);

			foreach (GameEntity ge in game_elements) {
				ge.Draw (sb, gt);

			}

//			sb.Draw(tekst, new Vector2(Globals.left+5,Globals.top+6), Color.White);

		}



	}
}
